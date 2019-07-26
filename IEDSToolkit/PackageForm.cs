using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace IEDSToolkit
{
    public partial class PackageForm : WeifenLuo.WinFormsUI.Docking.DockContent, AnalyzeFormInterface
    {
        public String FileName;

        private List<Chart> chartList = new List<Chart>();

        public PackageForm()
        {
            InitializeComponent();
        }

        private void PackageForm_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();

            this.TabText = System.IO.Path.GetFileName(FileName);

            XmlDocument doc = new XmlDocument();
            doc.Load(FileName);
            XmlNode root = doc.SelectSingleNode("Data");
            this.textBoxIEDType.Text = root.Attributes["Name"].Value;
            this.textBoxCreateTime.Text = root.Attributes["CreateTime"].Value;

            XmlNode DataNode = root.SelectSingleNode("RealTime");
            if (DataNode != null)
            {
                this.listViewRealTime.BeginUpdate();

                foreach (XmlNode message in DataNode.ChildNodes)
                {
                    ListViewGroup groupMessage = new ListViewGroup();
                    groupMessage.Header = message.Attributes["Name"].Value;
                    this.listViewRealTime.Groups.Add(groupMessage);

                    foreach (XmlNode var in message.ChildNodes)
                    {
                        ListViewItem itemVar = new ListViewItem();
                        itemVar.Text = (groupMessage.Items.Count + 1).ToString();
                        itemVar.SubItems.Add(var.Attributes["Name"].Value);
                        itemVar.SubItems.Add(var.Attributes["Value"].Value);
                        itemVar.Group = groupMessage;

                        this.listViewRealTime.Items.Add(itemVar);
                    }
                }

                this.listViewRealTime.EndUpdate();
            }
            else
                tabPageRealtime.Parent = null;

            DataNode = root.SelectSingleNode("CommonParam");
            if (DataNode != null)
            {
                this.listViewCommonParam.BeginUpdate();

                foreach (XmlNode message in DataNode.ChildNodes)
                {
                    ListViewGroup groupMessage = new ListViewGroup();
                    groupMessage.Header = message.Attributes["Name"].Value;
                    this.listViewCommonParam.Groups.Add(groupMessage);

                    foreach (XmlNode var in message.ChildNodes)
                    {
                        ListViewItem itemVar = new ListViewItem();
                        itemVar.Text = (groupMessage.Items.Count + 1).ToString();
                        itemVar.SubItems.Add(var.Attributes["Name"].Value);
                        itemVar.SubItems.Add(var.Attributes["Value"].Value);
                        itemVar.Group = groupMessage;

                        this.listViewCommonParam.Items.Add(itemVar);
                    }
                }

                this.listViewCommonParam.EndUpdate();
            }
            else
                tabPageCommonParam.Parent = null;

            DataNode = root.SelectSingleNode("AdvancedParam");
            if (DataNode != null)
            {
                this.listViewAdvancedParam.BeginUpdate();

                foreach (XmlNode message in DataNode.ChildNodes)
                {
                    ListViewGroup groupMessage = new ListViewGroup();
                    groupMessage.Header = message.Attributes["Name"].Value;
                    this.listViewAdvancedParam.Groups.Add(groupMessage);

                    foreach (XmlNode var in message.ChildNodes)
                    {
                        ListViewItem itemVar = new ListViewItem();
                        itemVar.Text = (groupMessage.Items.Count + 1).ToString();
                        itemVar.SubItems.Add(var.Attributes["Name"].Value);
                        itemVar.SubItems.Add(var.Attributes["Value"].Value);
                        itemVar.Group = groupMessage;

                        this.listViewAdvancedParam.Items.Add(itemVar);
                    }
                }

                this.listViewAdvancedParam.EndUpdate();
            }
            else
                tabPageAdvancedParam.Parent = null;

            DataNode = root.SelectSingleNode("Maintenance");
            if (DataNode != null)
            {
                this.listViewMaintenance.BeginUpdate();

                foreach (XmlNode message in DataNode.ChildNodes)
                {
                    ListViewGroup groupMessage = new ListViewGroup();
                    groupMessage.Header = message.Attributes["Name"].Value;
                    this.listViewMaintenance.Groups.Add(groupMessage);

                    foreach (XmlNode var in message.ChildNodes)
                    {
                        ListViewItem itemVar = new ListViewItem();
                        itemVar.Text = (groupMessage.Items.Count + 1).ToString();
                        itemVar.SubItems.Add(var.Attributes["Name"].Value);
                        itemVar.SubItems.Add(var.Attributes["Value"].Value);
                        itemVar.Group = groupMessage;

                        this.listViewMaintenance.Items.Add(itemVar);
                    }
                }

                this.listViewMaintenance.EndUpdate();
            }
            else
                tabPageMaintenance.Parent = null;

            DataNode = root.SelectSingleNode("Events");
            if (DataNode != null)
            {
                var digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                String LastType = "";
                ListView listViewEvent = null;
                foreach (XmlNode message in DataNode.ChildNodes)
                {
                    String EventType = message.Attributes["Name"].Value;
                    EventType = EventType.TrimEnd(digits);

                    if (LastType != EventType)
                    {
                        TabPage tabPageEvent = new TabPage();
                        tabPageEvent.Text = EventType;

                        listViewEvent = new ListView();
                        listViewEvent.View = View.Details;
                        listViewEvent.Dock = DockStyle.Fill;

                        ColumnHeader columnHeader = new ColumnHeader();
                        columnHeader.Text = "序号";
                        listViewEvent.Columns.Add(columnHeader);

                        columnHeader = new ColumnHeader();
                        columnHeader.Text = "变量名称";
                        columnHeader.Width = 200;
                        listViewEvent.Columns.Add(columnHeader);

                        columnHeader = new ColumnHeader();
                        columnHeader.Text = "变量值";
                        columnHeader.Width = 200;
                        listViewEvent.Columns.Add(columnHeader);

                        listViewEvent.Parent = tabPageEvent;

                        tabPageEvent.Parent = tabControlEvents;
                    }
                    LastType = EventType;

                    listViewEvent.BeginUpdate();

                    ListViewGroup groupMessage = new ListViewGroup();
                    groupMessage.Header = "记录" + (listViewEvent.Groups.Count + 1);
                    listViewEvent.Groups.Add(groupMessage);

                    foreach (XmlNode var in message.ChildNodes)
                    {
                        ListViewItem itemVar = new ListViewItem();
                        itemVar.Text = (groupMessage.Items.Count + 1).ToString();
                        itemVar.SubItems.Add(var.Attributes["Name"].Value.TrimEnd(digits));
                        itemVar.SubItems.Add(var.Attributes["Value"].Value);
                        itemVar.Group = groupMessage;

                        listViewEvent.Items.Add(itemVar);
                    }

                    listViewEvent.EndUpdate();
                }
            }
            else
                tabPageEvents.Parent = null;

            DataNode = root.SelectSingleNode("Oscillo");
            if (DataNode != null)
            {
                int[] FileData = new int[776 * 2 + 4];

                foreach (XmlNode file in DataNode.ChildNodes)
                {
                    String FileName = file.Attributes["Name"].Value;
                    int FileNumber = Convert.ToInt32(FileName.Remove(0, 7));

                    TabPage tabPageFile = new TabPage();
                    tabPageFile.Padding = new Padding(8);
                    tabPageFile.BackColor = Color.White;
                    if (FileNumber == 2)
                        tabPageFile.Text = "起动录波";
                    else
                        tabPageFile.Text = "故障录波" + FileNumber;

                    tabControlOscillo.SuspendLayout();
                    tabPageFile.SuspendLayout();

                    Chart chart = new Chart();
                    ((System.ComponentModel.ISupportInitialize)(chart)).BeginInit();

                    ChartArea chartArea1 = new ChartArea();
                    chartArea1.Name = "ChartArea1";
                    chartArea1.AxisX.MajorGrid.Enabled = false;
                    chartArea1.AxisY.MajorGrid.Enabled = false;
                    chartArea1.AxisY.Title = "电流";
                    chartArea1.AxisY.TitleFont = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    chart.ChartAreas.Add(chartArea1);                    

                    ListView listViewFile = new ListView();
                    listViewFile.View = View.Details;
                    listViewFile.Scrollable = false;
                    listViewFile.Dock = DockStyle.Top;
                    listViewFile.Height = 100;
                    listViewFile.FullRowSelect = true;
                    listViewFile.HeaderStyle = ColumnHeaderStyle.None;
                    listViewFile.BorderStyle = BorderStyle.None;

                    ColumnHeader columnHeader = new ColumnHeader();
                    columnHeader.Text = "";
                    columnHeader.Width = 200;
                    listViewFile.Columns.Add(columnHeader);

                    columnHeader = new ColumnHeader();
                    columnHeader.Text = "";
                    columnHeader.Width = 200;
                    listViewFile.Columns.Add(columnHeader);

                    try
                    {
                        byte[] buffer = Convert.FromBase64String(file.FirstChild.Value);
                        for (int i = 0; i < FileData.Length; i++)
                        {
                            FileData[i] = CommonUtility.ByteToInt(buffer[i]);
                        }

                        float Ratio = CommonUtility.Byte2Float(buffer, FileData.Length - 4);
                        int FileType = FileData[0];

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
                        if (FileType == 8)
                        {
                            float MaxStarter = OscilloForm.DrawStarterOscillogram(chart, TotalPoints, RunningPoint, FileData, DataIndex);

                            ListViewItem itemVar = new ListViewItem();
                            itemVar.Text = "起动最大电流";
                            itemVar.SubItems.Add(MaxStarter.ToString("0.00"));
                            listViewFile.Items.Add(itemVar);
                        }                            
                        else
                            OscilloForm.DrawFaultOscillogram(chart, FileData, DataIndex, Ratio);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("录波文件加载错误！\n错误信息：" + ex.Message);
                    }

                    tabPageFile.Controls.Add(chart);
                    tabPageFile.Controls.Add(listViewFile);

                    tabControlOscillo.Controls.Add(tabPageFile);

                    tabPageFile.ResumeLayout(false);
                    tabControlOscillo.ResumeLayout(false);

                    ((System.ComponentModel.ISupportInitialize)(chart)).EndInit();                                        

                    chartList.Add(chart);
                }
            }
            else
                tabPageOscillo.Parent = null;

            this.ResumeLayout(false);            
        }
        
        public void PrintContent()
        {
            //PrintListView plv = new PrintListView();
            //plv.MYListView = this.listViewRealTime;
            //plv.IsPreview = true;
            //plv.DoPrint();
        }

        private void timerDock_Tick(object sender, EventArgs e)
        {
            timerDock.Enabled = false;
            foreach (Chart chart in chartList)
            {
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
}
