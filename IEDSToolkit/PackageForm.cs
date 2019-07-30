using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

        private DataSet iedFile = new DataSet();
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
            
            iedFile.ReadXml(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\IED\\" + this.textBoxIEDType.Text + ".xml");

            XmlNode DataNode = root.SelectSingleNode("RealTime");
            if (DataNode != null)
            {
                ((System.ComponentModel.ISupportInitialize)(this.gridControlRealTime)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridViewRealTime)).BeginInit();

                DataTable varTable = new DataTable();
                varTable.Columns.Add(new DataColumn("Message_Name", typeof(string)));
                varTable.Columns.Add(new DataColumn("Var_Desc", typeof(string)));
                varTable.Columns.Add(new DataColumn("Var_Value", typeof(string)));

                int messageIndex = 1;
                foreach (XmlNode message in DataNode.ChildNodes)
                {   
                    foreach (XmlNode var in message.ChildNodes)
                    {                      
                        DataRow varRow = varTable.NewRow();
                        varRow["Message_Name"] = messageIndex.ToString("00") + ". " + message.Attributes["Name"].Value;
                        varRow["Var_Desc"] = var.Attributes["Name"].Value;
                        varRow["Var_Value"] = var.Attributes["Value"].Value + GetVarUnit(var.Attributes["Name"].Value);

                        varTable.Rows.Add(varRow);
                    }

                    messageIndex++;
                }

                this.gridControlRealTime.DataSource = varTable;

                this.gridViewRealTime.OptionsBehavior.AutoExpandAllGroups = true;

                ((System.ComponentModel.ISupportInitialize)(this.gridControlRealTime)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridViewRealTime)).EndInit();
            }
            else
                tabPageRealtime.Parent = null;

            DataNode = root.SelectSingleNode("CommonParam");
            if (DataNode != null)
            {
                ((System.ComponentModel.ISupportInitialize)(this.gridControlCommonParam)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridViewCommonParam)).BeginInit();

                DataTable varTable = new DataTable();
                varTable.Columns.Add(new DataColumn("Message_Name", typeof(string)));
                varTable.Columns.Add(new DataColumn("Var_Desc", typeof(string)));
                varTable.Columns.Add(new DataColumn("Var_Value", typeof(string)));

                int messageIndex = 1;
                foreach (XmlNode message in DataNode.ChildNodes)
                {
                    foreach (XmlNode var in message.ChildNodes)
                    {
                        DataRow varRow = varTable.NewRow();
                        varRow["Message_Name"] = messageIndex.ToString("00") + ". " + message.Attributes["Name"].Value;
                        varRow["Var_Desc"] = var.Attributes["Name"].Value;
                        varRow["Var_Value"] = var.Attributes["Value"].Value + GetVarUnit(var.Attributes["Name"].Value);

                        varTable.Rows.Add(varRow);
                    }

                    messageIndex++;
                }

                this.gridControlCommonParam.DataSource = varTable;

                this.gridViewCommonParam.OptionsBehavior.AutoExpandAllGroups = true;

                ((System.ComponentModel.ISupportInitialize)(this.gridControlCommonParam)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridViewCommonParam)).EndInit();
            }
            else
                tabPageCommonParam.Parent = null;

            DataNode = root.SelectSingleNode("AdvancedParam");
            if (DataNode != null)
            {
                ((System.ComponentModel.ISupportInitialize)(this.gridControlAdvancedParam)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridViewAdvancedParam)).BeginInit();

                DataTable varTable = new DataTable();
                varTable.Columns.Add(new DataColumn("Message_Name", typeof(string)));
                varTable.Columns.Add(new DataColumn("Var_Desc", typeof(string)));
                varTable.Columns.Add(new DataColumn("Var_Value", typeof(string)));

                int messageIndex = 1;
                foreach (XmlNode message in DataNode.ChildNodes)
                {
                    foreach (XmlNode var in message.ChildNodes)
                    {
                        DataRow varRow = varTable.NewRow();
                        varRow["Message_Name"] = messageIndex.ToString("00") + ". " + message.Attributes["Name"].Value;
                        varRow["Var_Desc"] = var.Attributes["Name"].Value;
                        varRow["Var_Value"] = var.Attributes["Value"].Value + GetVarUnit(var.Attributes["Name"].Value);

                        varTable.Rows.Add(varRow);
                    }

                    messageIndex++;
                }

                this.gridControlAdvancedParam.DataSource = varTable;

                this.gridViewAdvancedParam.OptionsBehavior.AutoExpandAllGroups = true;

                ((System.ComponentModel.ISupportInitialize)(this.gridControlAdvancedParam)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridViewAdvancedParam)).EndInit();
            }
            else
                tabPageAdvancedParam.Parent = null;

            DataNode = root.SelectSingleNode("Maintenance");
            if (DataNode != null)
            {
                ((System.ComponentModel.ISupportInitialize)(this.gridControlMaintenance)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridViewMaintenance)).BeginInit();

                DataTable varTable = new DataTable();
                varTable.Columns.Add(new DataColumn("Message_Name", typeof(string)));
                varTable.Columns.Add(new DataColumn("Var_Desc", typeof(string)));
                varTable.Columns.Add(new DataColumn("Var_Value", typeof(string)));

                int messageIndex = 1;
                foreach (XmlNode message in DataNode.ChildNodes)
                {
                    foreach (XmlNode var in message.ChildNodes)
                    {
                        DataRow varRow = varTable.NewRow();
                        varRow["Message_Name"] = messageIndex.ToString("00") + ". " + message.Attributes["Name"].Value;
                        varRow["Var_Desc"] = var.Attributes["Name"].Value;
                        varRow["Var_Value"] = var.Attributes["Value"].Value + GetVarUnit(var.Attributes["Name"].Value);

                        varTable.Rows.Add(varRow);
                    }

                    messageIndex++;
                }

                this.gridControlMaintenance.DataSource = varTable;

                this.gridViewMaintenance.OptionsBehavior.AutoExpandAllGroups = true;

                ((System.ComponentModel.ISupportInitialize)(this.gridControlMaintenance)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridViewMaintenance)).EndInit();
            }
            else
                tabPageMaintenance.Parent = null;

            DataNode = root.SelectSingleNode("Events");
            if (DataNode != null)
            {
                var digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                String LastType = "";
                DevExpress.XtraGrid.GridControl gridControlEvent = null;
                DataTable varTable = null;
                foreach (XmlNode message in DataNode.ChildNodes)
                {
                    String EventType = message.Attributes["Name"].Value;
                    EventType = EventType.TrimEnd(digits);

                    if (LastType != EventType)
                    {
                        TabPage tabPageEvent = new TabPage();
                        tabPageEvent.Text = EventType;
                        tabControlEvents.Controls.Add(tabPageEvent);

                        gridControlEvent = CreateEventGridControl();
                        tabPageEvent.Controls.Add(gridControlEvent);

                        varTable = new DataTable();
                        varTable.Columns.Add(new DataColumn("Message_Name", typeof(string)));
                        varTable.Columns.Add(new DataColumn("Var_Desc", typeof(string)));
                        varTable.Columns.Add(new DataColumn("Var_Value", typeof(string)));

                        gridControlEvent.DataSource = varTable;
                        ((DevExpress.XtraGrid.Views.Grid.GridView)(gridControlEvent.MainView)).OptionsBehavior.AutoExpandAllGroups = true;
                    }

                    LastType = EventType;

                    ((System.ComponentModel.ISupportInitialize)(gridControlEvent)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(gridControlEvent.MainView)).BeginInit();

                    foreach (XmlNode var in message.ChildNodes)
                    {
                        DataRow varRow = varTable.NewRow();
                        varRow["Message_Name"] = "记录" + (Convert.ToInt32(message.Attributes["Name"].Value.Replace(EventType, "")) + 1).ToString("00");
                        varRow["Var_Desc"] = var.Attributes["Name"].Value.TrimEnd(digits);
                        varRow["Var_Value"] = var.Attributes["Value"].Value + GetVarUnit(var.Attributes["Name"].Value.TrimEnd(digits));

                        varTable.Rows.Add(varRow);                        
                    }

                    ((System.ComponentModel.ISupportInitialize)(gridControlEvent)).EndInit();
                    ((System.ComponentModel.ISupportInitialize)(gridControlEvent.MainView)).EndInit();
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
                    chart.Name = tabPageFile.Text;
                    ((System.ComponentModel.ISupportInitialize)(chart)).BeginInit();

                    System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
                    System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
                    title1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //title1.Name = "TitleFile";
                    title1.Text = "故障录波0";
                    title1.Visible = false;
                    title2.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
                    title2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //title2.Name = "TitleParam";
                    title2.Text = "记录时间";
                    title2.Visible = false;
                    chart.Titles.Add(title1);
                    chart.Titles.Add(title2);

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

        private string GetVarUnit(string VarDesc)
        {
            String unit = "";
            DataRow[] rows = iedFile.Tables["Var"].Select("Desc = '" + VarDesc + "'");
            if (rows.Length > 0)
                unit = rows[0]["Unit"].ToString();
            return unit;
        }

        private DevExpress.XtraGrid.GridControl CreateEventGridControl()
        {
            DevExpress.XtraGrid.GridControl gridControlEvent = new DevExpress.XtraGrid.GridControl();
            DevExpress.XtraGrid.Views.Grid.GridView gridViewEvent = new DevExpress.XtraGrid.Views.Grid.GridView();
            DevExpress.XtraGrid.Columns.GridColumn gridColumn110 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gridColumn111 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gridColumn112 = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(gridControlEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gridViewEvent)).BeginInit();

            // 
            // gridControlMaintenance
            // 
            gridControlEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlEvent.Location = new System.Drawing.Point(3, 4);
            gridControlEvent.MainView = gridViewEvent;
            //gridControlEvent.Name = "gridControlEvent";
            gridControlEvent.Size = new System.Drawing.Size(978, 610);
            gridControlEvent.TabIndex = 4;
            gridControlEvent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            gridViewEvent});
            // 
            // gridViewMaintenance
            // 
            gridViewEvent.ColumnPanelRowHeight = 28;
            gridViewEvent.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn110,
            gridColumn111,
            gridColumn112});
            gridViewEvent.GridControl = gridControlEvent;
            gridViewEvent.GroupCount = 1;
            gridViewEvent.GroupFormat = "[#image]{1} {2}";
            gridViewEvent.GroupRowHeight = 24;
            //gridViewEvent.Name = "gridViewEvent";
            gridViewEvent.OptionsCustomization.AllowFilter = false;
            gridViewEvent.OptionsCustomization.AllowSort = false;
            gridViewEvent.OptionsMenu.EnableColumnMenu = false;
            gridViewEvent.OptionsMenu.EnableFooterMenu = false;
            gridViewEvent.OptionsMenu.EnableGroupPanelMenu = false;
            gridViewEvent.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridViewEvent.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridViewEvent.OptionsView.ColumnAutoWidth = false;
            gridViewEvent.OptionsView.ShowGroupPanel = false;
            gridViewEvent.RowHeight = 24;
            gridViewEvent.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gridColumn110, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn10
            // 
            gridColumn110.FieldName = "Message_Name";
            //gridColumn110.Name = "gridColumn110";
            gridColumn110.OptionsColumn.AllowEdit = false;
            gridColumn110.OptionsColumn.AllowMove = false;
            gridColumn110.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            gridColumn110.OptionsColumn.ReadOnly = true;
            gridColumn110.Visible = true;
            gridColumn110.VisibleIndex = 0;
            gridColumn110.Width = 200;
            // 
            // gridColumn11
            // 
            gridColumn111.AppearanceCell.BackColor = System.Drawing.Color.Azure;
            gridColumn111.AppearanceCell.Options.UseBackColor = true;
            gridColumn111.Caption = "变量名称";
            gridColumn111.FieldName = "Var_Desc";
            //gridColumn111.Name = "gridColumn111";
            gridColumn111.OptionsColumn.AllowEdit = false;
            gridColumn111.OptionsColumn.AllowMove = false;
            gridColumn111.OptionsColumn.ReadOnly = true;
            gridColumn111.Visible = true;
            gridColumn111.VisibleIndex = 0;
            gridColumn111.Width = 200;
            // 
            // gridColumn12
            // 
            gridColumn112.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            gridColumn112.AppearanceCell.Options.UseBackColor = true;
            gridColumn112.Caption = "变量值";
            gridColumn112.FieldName = "Var_Value";
            //gridColumn112.Name = "gridColumn112";
            gridColumn112.OptionsColumn.AllowEdit = false;
            gridColumn112.OptionsColumn.AllowMove = false;
            gridColumn112.OptionsColumn.ReadOnly = true;
            gridColumn112.Visible = true;
            gridColumn112.VisibleIndex = 1;
            gridColumn112.Width = 200;

            ((System.ComponentModel.ISupportInitialize)(gridControlEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gridViewEvent)).EndInit();

            return gridControlEvent;
        }

        public void PrintContent()
        {
            switch (this.tabControlMain.SelectedTab.Name)
            {
                case "tabPageRealtime":
                    {
                        DevGridReport devGridReport = new DevGridReport(this.gridControlRealTime
                                        , "打包文件 - [" + this.TabText + "] - " + this.tabControlMain.SelectedTab.Text
                                        , "设备类型：" + this.textBoxIEDType.Text + "\t创建时间：" + this.textBoxCreateTime.Text);
                        devGridReport.Preview();
                        break;
                    }
                case "tabPageCommonParam":
                    {
                        DevGridReport devGridReport = new DevGridReport(this.gridControlCommonParam
                                        , "打包文件 - [" + this.TabText + "] - " + this.tabControlMain.SelectedTab.Text
                                        , "设备类型：" + this.textBoxIEDType.Text + "\t创建时间：" + this.textBoxCreateTime.Text);
                        devGridReport.Preview();
                        break;
                    }
                case "tabPageAdvancedParam":
                    {
                        DevGridReport devGridReport = new DevGridReport(this.gridControlAdvancedParam
                                        , "打包文件 - [" + this.TabText + "] - " + this.tabControlMain.SelectedTab.Text
                                        , "设备类型：" + this.textBoxIEDType.Text + "\t创建时间：" + this.textBoxCreateTime.Text);
                        devGridReport.Preview();
                        break;
                    }
                case "tabPageMaintenance":
                    {
                        DevGridReport devGridReport = new DevGridReport(this.gridControlMaintenance
                                        , "打包文件 - [" + this.TabText + "] - " + this.tabControlMain.SelectedTab.Text
                                        , "设备类型：" + this.textBoxIEDType.Text + "\t创建时间：" + this.textBoxCreateTime.Text);
                        devGridReport.Preview();
                        break;
                    }
                case "tabPageEvents":
                    {                        
                        DevGridReport devGridReport = new DevGridReport(((DevExpress.XtraGrid.GridControl)(this.tabControlEvents.SelectedTab.Controls[0]))
                                        , "打包文件 - [" + this.TabText + "] - " + this.tabControlEvents.SelectedTab.Text
                                        , "设备类型：" + this.textBoxIEDType.Text + "\t创建时间：" + this.textBoxCreateTime.Text);
                        devGridReport.Preview();
                        break;
                    }
                case "tabPageOscillo":
                    {
                        TabPage tabPageFile = tabControlOscillo.SelectedTab;
                        ListView listViewFile = null;
                        foreach (Control control in tabPageFile.Controls)
                        {
                            if (control.GetType().Name == "Chart")
                                printingChart = (Chart)control;
                            else if (control.GetType().Name == "ListView") 
                                listViewFile = (ListView)control;
                        }

                        if (listViewFile == null || printingChart == null)
                            break;

                        printingChart.Titles[0].Text = "打包文件 - [" + this.TabText + "] - " + tabPageFile.Text;

                        printingChart.Titles[1].Text = "设备类型：" + this.textBoxIEDType.Text + "     ";
                        foreach (ListViewItem item in listViewFile.Items)
                        {
                            printingChart.Titles[1].Text += item.SubItems[0].Text + "：" + item.SubItems[1].Text + "     ";
                        }

                        printingChart.Printing.PrintDocument.PrintPage += PrintDocument_PrintPage;
                        printingChart.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                        printingChart.Printing.PageSetup();

                        printingChart.Titles[0].Visible = true;
                        printingChart.Titles[1].Visible = true;

                        PrintPreviewDialog ppd = new PrintPreviewDialog();
                        ppd.Document = printingChart.Printing.PrintDocument;
                        (ppd as Form).WindowState = FormWindowState.Maximized;
                        ppd.ShowDialog();

                        break;
                    }
                default: break;
            }
        }

        private Chart printingChart = null;
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (printingChart != null)
            {
                printingChart.Titles[0].Visible = false;
                printingChart.Titles[1].Visible = false;
            }            
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
