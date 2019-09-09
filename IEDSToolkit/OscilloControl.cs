using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Drawing.Printing;

namespace IEDSToolkit
{
    public partial class OscilloControl : UserControl
    {
        public String FileName;
        private int FileType = 0;
        private String PreTitle0 = "";
        private String PreTitle1 = "";

        private int m_X = 0;                        // Chart绘制曲线区域的左上角X坐标
        private int m_Y = 0;                        // Chart绘制曲线区域的左上角Y坐标
        private int m_Width = 0;                    // Chart绘制曲线区域的宽度
        private int m_Height = 0;                   // Chart绘制曲线区域的高度
        private PointF m_CursorPointY1 = new PointF(0, 0);             // 游标Y方向线1鼠标像素点
        private PointF m_CursorPointY2 = new PointF(20, 0);             // 游标Y方向线1鼠标像素点
        private int Start_Tigger_Span = 81;          // 开始时间与触发时间的间隔
        private double MicrosecondPerPoint = 0;     // 每个采样点间隔多少微秒
        private double XValue1 = 0;
        private double XValue2 = 20;
        private int MouseDownIndex = 0;
        private DateTime time_of_first_data;        //第一点的时刻
        private CursorAction cursorAction = CursorAction.Unknown;
        public OscilloControl()
        {
            InitializeComponent();
        }
        public void PrintContent()
        {
            if (FileName == "")
            {
                if (FileType == 8)
                    chart.Titles[0].Text = "起动录波";
                else
                    chart.Titles[0].Text = "故障录波";
            }
            else
            {
                if (FileType == 8)
                    chart.Titles[0].Text = "起动录波文件 - [" + FileName + "]";
                else
                    chart.Titles[0].Text = "故障录波文件 - [" + FileName + "]";
            }            

            chart.Titles[1].Text = "";
            foreach (ListViewItem item in listViewFile.Items)
            {
                if (item.SubItems[0].Text == "")
                    break;
      
                chart.Titles[1].Text += item.SubItems[0].Text + "：" + item.SubItems[1].Text + "     ";
            }

            chart.Titles[0].Text = this.PreTitle0 + chart.Titles[0].Text;
            chart.Titles[1].Text = this.PreTitle1 + chart.Titles[1].Text;

            chart.Printing.PrintDocument.PrintPage += PrintDocument_PrintPage;
            chart.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
            chart.Printing.PageSetup();

            chart.Titles[0].Visible = true;
            chart.Titles[1].Visible = true;

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = this.chart.Printing.PrintDocument;
            (ppd as Form).WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
            //chart.Printing.PrintPreview();  
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            //chart.Printing.PrintPaint(e.Graphics, e.MarginBounds);
            chart.Titles[0].Visible = false;
            chart.Titles[1].Visible = false;
        }
        public void SetChartPreTitle(String Title0, String Title1)
        {
            this.PreTitle0 = Title0;
            this.PreTitle1 = Title1;
        }
        public void LoadOscilloString(String Base64Value)
        {
            this.FileName = "";
            try
            {
                byte[] buffer = Convert.FromBase64String(Base64Value);
                DrawOscillogram(buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("录波文件加载错误！\n错误信息：" + ex.Message);
            }
        }
        public void LoadOscilloFile(String _FileName)
        {
            this.FileName = System.IO.Path.GetFileName(_FileName);
            try
            {
                FileStream fs = new FileStream(_FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                byte[] buffer = br.ReadBytes((int)fs.Length);
                fs.Dispose();

                DrawOscillogram(buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("录波文件加载错误！\n错误信息：" + ex.Message);
            }
        }
        private void DrawOscillogram(byte[] buffer)
        {
            this.listViewFile.Items.Clear();
            this.chart.Series.Clear();
            this.chart.ChartAreas.Clear();

            int[] FileData = new int[776 * 2 + 4];

            for (int i = 0; i < FileData.Length; i++)
            {
                FileData[i] = CommonUtility.ByteToInt(buffer[i]);
            }

            float Ratio = CommonUtility.Byte2Float(buffer, FileData.Length - 4);
            FileType = FileData[0];

            int TotalPoints = 0;
            int RunningPoint = 0;
            int DataIndex = 0;
            if (FileType == 8)
            {
                //读取起动录波标识
                DataIndex += 2;

                TotalPoints = FileData[DataIndex] * 256 + FileData[DataIndex + 1];
                ListViewItem itemVar = new ListViewItem();
                itemVar.Text = "录波时间长度";
                itemVar.SubItems.Add((TotalPoints * 60).ToString() + "ms");
                listViewFile.Items.Add(itemVar);
                DataIndex += 2;

                RunningPoint = FileData[DataIndex] * 256 + FileData[DataIndex + 1];
                DataIndex += 2;

                itemVar = new ListViewItem();
                itemVar.Text = "起动时间";
                itemVar.SubItems.Add((RunningPoint * (FileData[DataIndex] * 256 + FileData[DataIndex + 1]) * 20).ToString() + "ms");
                listViewFile.Items.Add(itemVar);
                DataIndex += 2;
            }
            else
            {
                //读取故障录波标识
                int FaultType = FileData[0] * 256 + FileData[1];
                DataIndex += 8;

                String FaultName = CommonUtility.GetFaultName(FaultType);
                ListViewItem itemVar = new ListViewItem();
                itemVar.Text = "故障类别";
                itemVar.SubItems.Add(FaultName.Substring(0, FaultName.IndexOf("_")));
                listViewFile.Items.Add(itemVar);

                itemVar = new ListViewItem();
                itemVar.Text = "故障原因";
                itemVar.SubItems.Add(FaultName.Substring(FaultName.IndexOf("_") + 1));
                listViewFile.Items.Add(itemVar);

                itemVar = new ListViewItem();
                itemVar.SubItems.Add("");
                listViewFile.Items.Add(itemVar);

                itemVar = new ListViewItem();
                itemVar.Text = "游标间隔";
                itemVar.SubItems.Add("20ms");
                listViewFile.Items.Add(itemVar);

                itemVar = new ListViewItem();
                itemVar.Text = "蓝色游标处通道值";
                itemVar.SubItems.Add("");
                listViewFile.Items.Add(itemVar);

                itemVar = new ListViewItem();
                itemVar.Text = "绿色游标处通道值";
                itemVar.SubItems.Add("");
                listViewFile.Items.Add(itemVar);
            }

            byte[] Date = new byte[3];
            Date[0] = (byte)(FileData[DataIndex + 1]);
            Date[1] = (byte)(FileData[DataIndex + 2]);
            Date[2] = (byte)(FileData[DataIndex + 3]);
            String DateStr = CommonUtility.Bcd2Str(Date);
            String DateValue = "20" + DateStr.Substring(0, 2) + "-" + DateStr.Substring(2, 2) + "-" + DateStr.Substring(4, 2);
            DataIndex += 4;

            Date[0] = (byte)(FileData[DataIndex + 1]);
            Date[1] = (byte)(FileData[DataIndex + 2]);
            Date[2] = (byte)(FileData[DataIndex + 3]);
            DateStr = CommonUtility.Bcd2Str(Date);
            DateValue = DateValue + " " + DateStr.Substring(0, 2) + ":" + DateStr.Substring(2, 2) + ":" + DateStr.Substring(4, 2);
            DataIndex += 4;

            ListViewItem itemDate = new ListViewItem();
            itemDate.Text = "记录时间";
            itemDate.SubItems.Add(DateValue);
            listViewFile.Items.Insert(0, itemDate);

            //绘制曲线
            ((System.ComponentModel.ISupportInitialize)(chart)).BeginInit();            

            ChartArea chartArea1 = new ChartArea();
            chartArea1.Name = "ChartArea1";
            chartArea1.AxisY.Title = "电流";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart.ChartAreas.Add(chartArea1);
            if (FileType == 8)
            {
                float MaxStarter = DrawStarterOscillogram(chart, TotalPoints, RunningPoint, FileData, DataIndex);

                ListViewItem itemVar = new ListViewItem();
                itemVar.Text = "起动最大电流";
                itemVar.SubItems.Add(MaxStarter.ToString("0.00"));
                listViewFile.Items.Add(itemVar);
            }
            else
            {
                this.chart.Paint += new System.Windows.Forms.PaintEventHandler(this.chart_Paint);
                DrawFaultOscillogram(chart, FileData, DataIndex, Ratio);
            }

            ((System.ComponentModel.ISupportInitialize)(chart)).EndInit();
        }
        private float DrawStarterOscillogram(Chart chart, int TotalPoints, int RunningPoint, int[] FileData, int DataIndex)
        {
            float MaxStarter = 0;

            chart.ChartAreas[0].AxisY.Title = "起动电流";
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.Title = "ms";

            Series series1 = new Series();
            series1.ChartArea = "ChartArea1";
            //series1.Name = "Series1";
            series1.ChartType = SeriesChartType.Line;
            series1.Color = Color.Red;

            for (int i = 0; i < TotalPoints; i++)
            {
                float value = 0.1F * (FileData[DataIndex] * 256 + FileData[DataIndex + 1]);
                DataIndex += 2;

                int runningIndex = series1.Points.AddXY((i + 1) * 60, value);

                if (i == RunningPoint)
                {
                    series1.Points[runningIndex].IsValueShownAsLabel = true;
                    series1.Points[runningIndex].LabelBackColor = Color.Blue;
                    series1.Points[runningIndex].LabelForeColor = Color.White;
                    series1.Points[runningIndex].MarkerColor = Color.Blue;
                    series1.Points[runningIndex].MarkerStyle = MarkerStyle.Circle;
                    series1.Points[runningIndex].LabelFormat = "0.000";
                }

                if (i <= RunningPoint && MaxStarter < value)
                    MaxStarter = value;
            }

            series1.ToolTip = "#VALX, #VAL{0.##}";
            series1.Font = new System.Drawing.Font("微软雅黑", 8F);
            chart.Series.Add(series1);

            return MaxStarter;
        }

        enum CursorAction
        {
            Unknown,                                // 未知
            Y1,                                     // 游标Y方向线1移动
            Y2                                      // 游标Y方向线1移动
        };
        
        private void chart_Paint(object sender, PaintEventArgs e)
        {
            if (FileType == 8)
                return;

            Chart chart = (Chart)sender;
            //游标X最大值
            int iMaxCursorX = 0;
            int X = 0;
            int Y = 0;
            //if (m_Width == 0 || m_Height == 0)
            {
                ChartArea area = chart.ChartAreas[0];
                // Chart绘制曲线区域的左上角坐标
                m_X = (int)(area.Position.X * chart.Width / 100 + area.InnerPlotPosition.X * area.Position.Width * chart.Width / 10000);
                m_Y = (int)(area.Position.Y * chart.Height / 100 + area.InnerPlotPosition.Y * area.Position.Height * chart.Height / 10000);
                // Chart绘制曲线区域的高度和宽度
                area = chart.ChartAreas[chart.ChartAreas.Count - 1];
                X = (int)(area.Position.X * chart.Width / 100 + area.InnerPlotPosition.X * area.Position.Width * chart.Width / 10000);
                Y = (int)(area.Position.Y * chart.Height / 100 + area.InnerPlotPosition.Y * area.Position.Height * chart.Height / 10000);
                m_Width = X - m_X + (int)(area.InnerPlotPosition.Width * area.Position.Width * chart.Width / 10000);
                m_Height = Y - m_Y + (int)(area.InnerPlotPosition.Height * area.Position.Height * chart.Height / 10000);

                iMaxCursorX = X + m_Width;
            }

            double dx = (chart.ChartAreas[0].AxisX.Maximum - chart.ChartAreas[0].AxisX.Minimum) / m_Width;
            //float fscale = (float)hsbCursor1.Maximum / (hsbCursor1.Maximum - 9);

            //if (tbxCursor1.Text != "")
            m_CursorPointY1.X = (float)((XValue1 - chart.ChartAreas[0].AxisX.Minimum) / dx);

            //if (tbxCursor2.Text != "")
            m_CursorPointY2.X = (float)((XValue2 - chart.ChartAreas[0].AxisX.Minimum) / dx);


            //绘制触发时间线
            //Pen penTrigger = new Pen(Color.Red);
            //penTrigger.Width = 1;
            //float TriggerX = (float)chart.ChartAreas[0].AxisX.GetPosition(Start_Tigger_Span) * chart.Width / 100;
            //PointF TriggerStartPoint = new PointF(TriggerX, m_Y);
            //PointF TriggerEndPoint = new PointF(TriggerX, m_Y + m_Height);
            //e.Graphics.DrawLine(penTrigger, TriggerStartPoint, TriggerEndPoint);
            //System.Drawing.Font TriggerFont = new System.Drawing.Font("微软雅黑", 7);
            //Brush TriggerBrush = new SolidBrush(Color.Red);
            //SizeF TextSize = e.Graphics.MeasureString(this.textBoxTriggerTime.Text, TriggerFont);
            //PointF TriggerTime = new PointF(TriggerX - TextSize.Width / 2, m_Y - TextSize.Height - 1);
            //e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            //e.Graphics.DrawString(this.textBoxTriggerTime.Text, TriggerFont, TriggerBrush, TriggerTime);

            //游标Y方向线1
            Pen penCursor1 = new Pen(Color.Blue);
            float iCursor1X = m_X + m_CursorPointY1.X;
            if (iCursor1X > iMaxCursorX)
                iCursor1X = iMaxCursorX;
            if (iCursor1X < X)
                iCursor1X = X;
            PointF yStartPoint = new PointF(iCursor1X, m_Y + 5);
            PointF yEndPoint = new PointF(iCursor1X, m_Y + m_Height - 5);
            e.Graphics.DrawLine(penCursor1, yStartPoint, yEndPoint);

            //游标指针
            PointF YSecondpf = new PointF(iCursor1X - 5, m_Y);
            PointF YThirdpf = new PointF(iCursor1X - 5, m_Y - 10);
            PointF YFourthpf = new PointF(iCursor1X + 5, m_Y - 10);
            PointF YFifthpf = new PointF(iCursor1X + 5, m_Y);
            PointF[] Yarpf = { new PointF(iCursor1X, m_Y + 5), YSecondpf, YThirdpf, YFourthpf, YFifthpf };
            e.Graphics.DrawPolygon(penCursor1, Yarpf);

            //游标Y方向线2
            float iCursor2X = m_X + m_CursorPointY2.X;
            if (iCursor2X > iMaxCursorX)
                iCursor2X = iMaxCursorX;
            if (iCursor2X < X)
                iCursor2X = X;
            Pen penCursor2 = new Pen(Color.Green);
            PointF yStartPoint2 = new PointF(iCursor2X, m_Y + 5);
            PointF yEndPoint2 = new PointF(iCursor2X, m_Y + m_Height - 5);
            e.Graphics.DrawLine(penCursor2, yStartPoint2, yEndPoint2);

            //游标指针
            PointF YSecondpf2 = new PointF(iCursor2X - 5, m_Y);
            PointF YThirdpf2 = new PointF(iCursor2X - 5, m_Y - 10);
            PointF YFourthpf2 = new PointF(iCursor2X + 5, m_Y - 10);
            PointF YFifthpf2 = new PointF(iCursor2X + 5, m_Y);
            PointF[] Yarpf2 = { new PointF(iCursor2X, m_Y + 5), YSecondpf2, YThirdpf2, YFourthpf2, YFifthpf2 };
            e.Graphics.DrawPolygon(penCursor2, Yarpf2);

            //游标1
            double Cursor1XValue = dx * m_CursorPointY1.X + chart.ChartAreas[0].AxisX.Minimum;
            if (Cursor1XValue > chart.ChartAreas[0].AxisX.Maximum)
                Cursor1XValue = chart.ChartAreas[0].AxisX.Maximum;
            if (Cursor1XValue < chart.ChartAreas[0].AxisX.Minimum)
                Cursor1XValue = chart.ChartAreas[0].AxisX.Minimum;

            //if (tbxCursor1.Text != "")
            //{
            //    if (XValue1 > chart.ChartAreas[0].AxisX.Maximum)
            //        XValue1 = chart.ChartAreas[0].AxisX.Maximum;
            //    if (XValue1 < chart.ChartAreas[0].AxisX.Minimum)
            //        XValue1 = chart.ChartAreas[0].AxisX.Minimum;
            //    hsbCursor1.Value = (int)XValue1;
            //}
            //else
            //{
            //    hsbCursor1.Value = (int)Cursor1XValue;
            //    XValue1 = hsbCursor1.Value;
            //}

            ////游标2
            double Cursor2XValue = dx * m_CursorPointY2.X + chart.ChartAreas[0].AxisX.Minimum;
            if (Cursor2XValue > chart.ChartAreas[0].AxisX.Maximum)
                Cursor2XValue = chart.ChartAreas[0].AxisX.Maximum;
            if (Cursor2XValue < chart.ChartAreas[0].AxisX.Minimum)
                Cursor2XValue = chart.ChartAreas[0].AxisX.Minimum;
            //if (tbxCursor1.Text != "")
            //{
            //    if (XValue2 > chart.ChartAreas[0].AxisX.Maximum)
            //        XValue2 = chart.ChartAreas[0].AxisX.Maximum;
            //    if (XValue2 < chart.ChartAreas[0].AxisX.Minimum)
            //        XValue2 = chart.ChartAreas[0].AxisX.Minimum;
            //    hsbCursor2.Value = (int)XValue2;
            //}
            //else
            //{
            //    hsbCursor2.Value = (int)Cursor2XValue;
            //    XValue2 = hsbCursor2.Value;
            //}

            //游标间隔
            this.listViewFile.Items[4].SubItems[1].Text = Math.Abs(Cursor1XValue - Cursor2XValue).ToString("0.##") + " ms";

            //游标处通道值
            int Cursor1PointIndex = GetNearPointIndex(Cursor1XValue);
            int Cursor2PointIndex = GetNearPointIndex(Cursor2XValue);
            String BlueCursorValue = "";
            String GreenCursorValue = "";
            for (int i = 0; i < this.chart.Series.Count; i++)
            {
                if (Cursor1PointIndex >= 0)
                    BlueCursorValue += this.chart.Series[i].Name + ": " + this.chart.Series[i].Points[Cursor1PointIndex].YValues[0].ToString("0.##") + ", ";

                if (Cursor2PointIndex >= 0)
                    GreenCursorValue += this.chart.Series[i].Name + ": " + this.chart.Series[i].Points[Cursor2PointIndex].YValues[0].ToString("0.##") + ", ";
            }
            if (BlueCursorValue != "")
                this.listViewFile.Items[5].SubItems[1].Text = BlueCursorValue.Remove(BlueCursorValue.Length - 2);
            else
                this.listViewFile.Items[5].SubItems[1].Text = "";

            if (GreenCursorValue != "")
                this.listViewFile.Items[6].SubItems[1].Text = GreenCursorValue.Remove(GreenCursorValue.Length - 2);
            else
                this.listViewFile.Items[6].SubItems[1].Text = "";
        }

        private void DrawFaultOscillogram(Chart chart, int[] FileData, int DataIndex, float Ratio)
        {
            //chart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart.ChartAreas[0].AxisY.Title = "三相电流";
            chart.ChartAreas[0].BackColor = Color.FromArgb(150, Color.WhiteSmoke);

            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            chart.ChartAreas[0].AxisY.LineColor = Color.Black;
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0}";
            chart.ChartAreas[0].AxisX.LineWidth = 1;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorGrid.Interval = 20;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 160;

            Color[] colorABC = { Color.Gold, Color.Green, Color.Red };
            String[] stringI = { "Ia", "Ib", "Ic" };
            String[] stringU = { "Ua", "Ub", "Uc" };
            //电流
            for (int Phase = 0; Phase < 3; Phase++)
            {
                Series series1 = new Series();
                series1.ChartArea = "ChartArea1";
                series1.Name = stringI[Phase];
                series1.ChartType = SeriesChartType.Line;
                series1.Color = colorABC[Phase];

                for (int i = 0; i < 128; i++)
                {
                    float value = 1.65F / 2048 * (FileData[DataIndex] * 256 + FileData[DataIndex + 1] - 2048) / 38.3F * Ratio;
                    DataIndex += 2;

                    int dataIndex = series1.Points.AddXY(i * 1.25, value);

                    if (i == 80)
                    {
                        series1.Points[dataIndex].IsValueShownAsLabel = true;
                        series1.Points[dataIndex].LabelBackColor = colorABC[Phase];
                        series1.Points[dataIndex].LabelForeColor = Color.White;
                        series1.Points[dataIndex].MarkerColor = colorABC[Phase];
                        series1.Points[dataIndex].MarkerStyle = MarkerStyle.Circle;
                        series1.Points[dataIndex].LabelFormat = "0.000";
                    }
                }

                series1.ToolTip = "#VALX, #VAL{0.##}";
                series1.Font = new System.Drawing.Font("微软雅黑", 8F);

                chart.Series.Add(series1);
            }

            //电压
            ChartArea chartArea2 = new ChartArea();
            chartArea2.Name = "ChartArea2";            
            chartArea2.BackColor = Color.FromArgb(150, Color.WhiteSmoke);

            chartArea2.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            chartArea2.AxisY.LineColor = Color.Black;
            chartArea2.AxisY.LabelStyle.Format = "{0:0}";
            chartArea2.AxisX.LineWidth = 1;
            chartArea2.AxisX.MajorGrid.Enabled = true;
            chartArea2.AxisX.MajorGrid.Interval = 20;
            chartArea2.AxisX.MajorGrid.LineColor = Color.Gainsboro;
            chartArea2.AxisX.LabelStyle.Enabled = true;
            chartArea2.AxisX.LabelStyle.Interval = 20;
            chartArea2.AxisX.MajorTickMark.Enabled = true;
            chartArea2.AxisX.MajorTickMark.Interval = 20;
            chartArea2.AxisX.Minimum = 0;
            chartArea2.AxisX.Maximum = 160;
            chartArea2.AxisX.Title = "ms";

            chartArea2.AlignWithChartArea = "ChartArea1";
            chartArea2.AxisY.Title = "三相电压";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart.ChartAreas.Add(chartArea2);

            for (int Phase = 0; Phase < 3; Phase++)
            {
                Series series1 = new Series();
                series1.ChartArea = "ChartArea2";
                series1.Name = stringU[Phase];
                series1.ChartType = SeriesChartType.Line;
                series1.Color = colorABC[Phase];

                for (int i = 0; i < 128; i++)
                {
                    float value = 1.65F / 2048 * (FileData[DataIndex] * 256 + FileData[DataIndex + 1] - 2048) * 560F;
                    DataIndex += 2;

                    int dataIndex = series1.Points.AddXY(i * 1.25, value);

                    if (i == 80)
                    {
                        series1.Points[dataIndex].IsValueShownAsLabel = true;
                        series1.Points[dataIndex].LabelBackColor = colorABC[Phase];
                        series1.Points[dataIndex].LabelForeColor = Color.White;
                        series1.Points[dataIndex].MarkerColor = colorABC[Phase];
                        series1.Points[dataIndex].MarkerStyle = MarkerStyle.Circle;
                        series1.Points[dataIndex].LabelFormat = "0.000";
                    }
                }

                series1.ToolTip = "#VALX, #VAL{0.##}";
                series1.Font = new System.Drawing.Font("微软雅黑", 8F);

                chart.Series.Add(series1);
            }

            chart.ChartAreas[0].Position.Width = 100;
            chart.ChartAreas[0].Position.Height = 45f;
            chart.ChartAreas[0].Position.X = 2;
            chart.ChartAreas[0].Position.Y = 1;
            chart.ChartAreas[1].Position.Width = 100;
            chart.ChartAreas[1].Position.Height = 54f;
            chart.ChartAreas[1].Position.X = 2;
            chart.ChartAreas[1].Position.Y = 48.5f;
        }

        public void DockChart()
        {
            chart.BringToFront();
            try
            {
                chart.Dock = DockStyle.Fill;
            }
            catch
            { }
        }

        private int GetNearPointIndex(double CursorXValue)
        {
            int iIndex = -1;
            for (int index = 0; index < chart.Series[0].Points.Count; index++)
            {
                DataPoint data = chart.Series[0].Points[index];
                if (data.XValue >= CursorXValue)
                {
                    iIndex = index;
                    break;
                }
            }
            if (iIndex == -1)
                iIndex = chart.Series[0].Points.Count - 1;

            return iIndex;
        }

        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            if (FileType == 8)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if ((e.X >= m_X) && (e.Y >= m_Y) && (e.X <= (m_X + m_Width)) && (e.Y <= (m_Y + m_Height))
                    && e.X > (m_X + m_CursorPointY1.X - 5) && e.X < (m_X + m_CursorPointY1.X + 5)
                    && e.Y > (m_Y + m_CursorPointY1.Y - 5) && e.Y < (m_Y + m_CursorPointY1.Y + 5))
                {
                    m_CursorPointY1.X = e.X - m_X;
                    m_CursorPointY1.Y = e.Y - m_Y;
                    cursorAction = CursorAction.Y1;
                }
                else if (e.Y > (m_Y - 10) && e.Y < m_Y
                    && e.X < (m_X + m_CursorPointY1.X + 5) && e.X > (m_X + m_CursorPointY1.X - 5))
                {
                    m_CursorPointY1.X = e.X - m_X;
                    cursorAction = CursorAction.Y1;
                }
                else if ((e.X >= m_X) && (e.Y >= m_Y) && (e.X <= (m_X + m_Width)) && (e.Y <= (m_Y + m_Height))
                    && e.X > (m_X + m_CursorPointY2.X - 5) && e.X < (m_X + m_CursorPointY2.X + 5)
                    && e.Y > (m_Y + m_CursorPointY2.Y - 5) && e.Y < (m_Y + m_CursorPointY2.Y + 5))
                {
                    m_CursorPointY2.X = e.X - m_X;
                    m_CursorPointY2.Y = e.Y - m_Y;
                    cursorAction = CursorAction.Y2;
                }
                else if (e.Y > (m_Y - 10) && e.Y < m_Y
                    && e.X < (m_X + m_CursorPointY2.X + 5) && e.X > (m_X + m_CursorPointY2.X - 5))
                {
                    m_CursorPointY2.X = e.X - m_X;
                    cursorAction = CursorAction.Y2;
                }
                else
                {
                    cursorAction = CursorAction.Unknown;
                }
            }
        }

        private void chart_MouseUp(object sender, MouseEventArgs e)
        {
            if (FileType == 8)
                return;

            chart.Invalidate();
            //chart.Cursor = System.Windows.Forms.Cursors.Cross;
            cursorAction = CursorAction.Unknown;
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (FileType == 8)
                return;

            if (e.Button == MouseButtons.None)
            {
                if ((e.X >= m_X) && (e.Y >= m_Y) && (e.X <= (m_X + m_Width)) && (e.Y <= (m_Y + m_Height))
                    && e.X > (m_X + m_CursorPointY1.X - 5) && e.X < (m_X + m_CursorPointY1.X + 5)
                    && e.Y > (m_Y + m_CursorPointY1.Y - 5) && e.Y < (m_Y + m_CursorPointY1.Y + 5))
                {
                    chart.Cursor = System.Windows.Forms.Cursors.SizeWE;
                }
                else if (e.Y > (m_Y - 10) && e.Y < m_Y
                    && e.X < (m_X + m_CursorPointY1.X + 5) && e.X > (m_X + m_CursorPointY1.X - 5))
                {
                    chart.Cursor = System.Windows.Forms.Cursors.SizeWE;
                }
                else if ((e.X >= m_X) && (e.Y >= m_Y) && (e.X <= (m_X + m_Width)) && (e.Y <= (m_Y + m_Height))
                    && e.X > (m_X + m_CursorPointY2.X - 5) && e.X < (m_X + m_CursorPointY2.X + 5)
                    && e.Y > (m_Y + m_CursorPointY2.Y - 5) && e.Y < (m_Y + m_CursorPointY2.Y + 5))
                {
                    chart.Cursor = System.Windows.Forms.Cursors.SizeWE;
                }
                else if (e.Y > (m_Y - 10) && e.Y < m_Y
                    && e.X < (m_X + m_CursorPointY2.X + 5) && e.X > (m_X + m_CursorPointY2.X - 5))
                {
                    chart.Cursor = System.Windows.Forms.Cursors.SizeWE;
                }
                else
                {
                    chart.Cursor = System.Windows.Forms.Cursors.Cross;
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (cursorAction != CursorAction.Y1 && cursorAction != CursorAction.Y2)
                {
                    chart.Cursor = System.Windows.Forms.Cursors.Cross;
                    return;
                }
                double dx = (chart.ChartAreas[0].AxisX.Maximum - chart.ChartAreas[0].AxisX.Minimum) / m_Width;

                if (cursorAction == CursorAction.Y1)
                {
                    if ((e.X >= m_X) && (e.Y >= m_Y) && (e.X <= (m_X + m_Width)) && (e.Y <= (m_Y + m_Height)))
                    {
                        //chart.Cursor = System.Windows.Forms.Cursors.Cross;
                        m_CursorPointY1.X = e.X - m_X;
                        m_CursorPointY1.Y = e.Y - m_Y;
                    }
                    else if ((e.X >= m_X) && (e.X <= (m_X + m_Width)))
                    {
                        chart.Cursor = System.Windows.Forms.Cursors.SizeWE;
                        m_CursorPointY1.X = e.X - m_X;
                    }
                    else if ((e.Y >= m_Y) && (e.Y <= (m_Y + m_Height)))
                    {
                        chart.Cursor = System.Windows.Forms.Cursors.SizeNS;
                        m_CursorPointY1.Y = e.Y - m_Y;
                    }
                    XValue1 = m_CursorPointY1.X * dx + chart.ChartAreas[0].AxisX.Minimum;
                }
                else if (cursorAction == CursorAction.Y2)
                {
                    if ((e.X >= m_X) && (e.Y >= m_Y) && (e.X <= (m_X + m_Width)) && (e.Y <= (m_Y + m_Height)))
                    {
                        //chart.Cursor = System.Windows.Forms.Cursors.Cross;
                        m_CursorPointY2.X = e.X - m_X;
                        m_CursorPointY2.Y = e.Y - m_Y;

                    }
                    else if ((e.X >= m_X) && (e.X <= (m_X + m_Width)))
                    {
                        chart.Cursor = System.Windows.Forms.Cursors.SizeWE;
                        m_CursorPointY2.X = e.X - m_X;
                    }
                    else if ((e.Y >= m_Y) && (e.Y <= (m_Y + m_Height)))
                    {
                        chart.Cursor = System.Windows.Forms.Cursors.SizeNS;
                        m_CursorPointY2.Y = e.Y - m_Y;
                    }
                    XValue2 = m_CursorPointY2.X * dx + chart.ChartAreas[0].AxisX.Minimum;
                }

                chart.Invalidate();
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                
            }
        }
    }
}
