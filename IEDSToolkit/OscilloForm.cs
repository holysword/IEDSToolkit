using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IEDSToolkit
{
    public partial class OscilloForm : WeifenLuo.WinFormsUI.Docking.DockContent, AnalyzeFormInterface
    {
        public String FileName;

        private int FileType = 0;
        public OscilloForm()
        {
            InitializeComponent();
        }
        
        public void PrintContent()
        {
            if (FileType == 8)
                chart.Titles[0].Text = "起动录波文件 - [" + this.TabText + "]";
            else
                chart.Titles[0].Text = "故障录波文件 - [" + this.TabText + "]";

            chart.Titles[1].Text = "";
            foreach (ListViewItem item in listViewFile.Items)
            {
                chart.Titles[1].Text += item.SubItems[0].Text + "：" + item.SubItems[1].Text + "     ";
            }

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
        
        private void OscilloForm_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();

            this.TabText = System.IO.Path.GetFileName(FileName);
                        
            int[] FileData = new int[776 * 2 + 4];
            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Open);           
                BinaryReader br = new BinaryReader(fs);                            
                byte[] buffer = br.ReadBytes((int)fs.Length);
                fs.Dispose();

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
                    itemVar.Text = "总点数";
                    itemVar.SubItems.Add(TotalPoints.ToString());
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
                chartArea1.AxisX.MajorGrid.Enabled = false;
                chartArea1.AxisY.MajorGrid.Enabled = false;
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
                    DrawFaultOscillogram(chart, FileData, DataIndex, Ratio);

                ((System.ComponentModel.ISupportInitialize)(chart)).EndInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("录波文件加载错误！\n错误信息：" + ex.Message);
            }

            this.ResumeLayout(false);
        }

        public static float DrawStarterOscillogram(Chart chart, int TotalPoints, int RunningPoint, int[] FileData, int DataIndex)
        {
            float MaxStarter = 0;

            chart.ChartAreas[0].AxisY.Title = "起动电流";

            Series series1 = new Series();
            series1.ChartArea = "ChartArea1";
            //series1.Name = "Series1";
            series1.ChartType = SeriesChartType.Line;
            series1.Color = Color.Red;

            for (int i = 0; i < TotalPoints; i++)
            {
                float value = 0.1F * (FileData[DataIndex] * 256 + FileData[DataIndex + 1]);
                DataIndex += 2;

                int runningIndex = series1.Points.AddXY(i + 1, value);

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

            chart.Series.Add(series1);

            return MaxStarter;
        }

        public static void DrawFaultOscillogram(Chart chart, int[] FileData, int DataIndex, float Ratio)
        {
            chart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart.ChartAreas[0].AxisY.Title = "三相电流";

            Color[] colorABC = { Color.Gold, Color.Green, Color.Red };
            //电流
            for (int Phase = 0; Phase < 3; Phase++)
            {
                Series series1 = new Series();
                series1.ChartArea = "ChartArea1";
                //series1.Name = "Series1";
                series1.ChartType = SeriesChartType.Line;
                series1.Color = colorABC[Phase];

                for (int i = 0; i < 128; i++)
                {
                    float value = 1.65F / 2048 * (FileData[DataIndex] * 256 + FileData[DataIndex + 1] - 2048) / 38.3F * Ratio;
                    DataIndex += 2;

                    int dataIndex = series1.Points.AddXY(i + 1, value);

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

                chart.Series.Add(series1);
            }

            //电压
            ChartArea chartArea2 = new ChartArea();
            chartArea2.Name = "ChartArea2";
            chartArea2.AlignWithChartArea = "ChartArea1";
            chartArea2.AxisX.Enabled = AxisEnabled.False;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.Title = "三相电压";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart.ChartAreas.Add(chartArea2);

            for (int Phase = 0; Phase < 3; Phase++)
            {
                Series series1 = new Series();
                series1.ChartArea = "ChartArea2";
                //series1.Name = "Series1";
                series1.ChartType = SeriesChartType.Line;
                series1.Color = colorABC[Phase];

                for (int i = 0; i < 128; i++)
                {
                    float value = 1.65F / 2048 * (FileData[DataIndex] * 256 + FileData[DataIndex + 1] - 2048) * 560F;
                    DataIndex += 2;

                    int dataIndex = series1.Points.AddXY(i + 1, value);

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

                chart.Series.Add(series1);
            }
        }

        private void timerDock_Tick(object sender, EventArgs e)
        {
            timerDock.Enabled = false;

            chart.BringToFront();
            try
            {
                chart.Dock = DockStyle.Fill;
            }
            catch
            { }
        }        
    }
}
