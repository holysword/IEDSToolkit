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
        private List<OscilloControl> chartList = new List<OscilloControl>();

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
                        varRow["Var_Value"] = var.Attributes["Value"].Value + GetVarUnit(message.Attributes["Name"].Value, var.Attributes["Name"].Value);

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
                        varRow["Var_Value"] = var.Attributes["Value"].Value + GetVarUnit(message.Attributes["Name"].Value, var.Attributes["Name"].Value);

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
                        varRow["Var_Value"] = var.Attributes["Value"].Value + GetVarUnit(message.Attributes["Name"].Value, var.Attributes["Name"].Value);

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
                        varRow["Var_Value"] = var.Attributes["Value"].Value + GetVarUnit(message.Attributes["Name"].Value, var.Attributes["Name"].Value);

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
                        varRow["Var_Value"] = var.Attributes["Value"].Value + GetVarUnit(EventType, var.Attributes["Name"].Value.TrimEnd(digits));

                        if (EventType == "IO变位记录")
                            AnalyzeIOChangeEvent(varRow);

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

                    OscilloControl oscilloControl = new OscilloControl();
                    oscilloControl.Dock = DockStyle.Fill;
                    oscilloControl.LoadOscilloString(file.FirstChild.Value);                   

                    tabPageFile.Controls.Add(oscilloControl);                    

                    tabControlOscillo.Controls.Add(tabPageFile);

                    tabPageFile.ResumeLayout(false);
                    tabControlOscillo.ResumeLayout(false);
                    
                    chartList.Add(oscilloControl);
                }
            }
            else
                tabPageOscillo.Parent = null;

            this.ResumeLayout(false);            
        }

        public static void AnalyzeIOChangeEvent(DataRow varRow)
        {
            if (!varRow["Var_Desc"].ToString().Contains("变位"))
                return;
            
            try
            {
                short value = Convert.ToInt16(varRow["Var_Value"]);                
                varRow["Var_Value"] = String.Join(" ", Convert.ToString(value, 2).PadLeft(16, '0').ToCharArray().Reverse().ToArray());
            }
            catch (Exception)
            { }
        }

        private string GetVarUnit(string MessageName, string VarDesc)
        {
            String unit = "";
            DataRow[] rows = iedFile.Tables["Message"].Select("Name = '" + MessageName + "'");
            if (rows.Length == 0)
                return unit;
            String messageId = rows[0]["Message_Id"].ToString();
            rows = iedFile.Tables["Var"].Select("Message_Id = " + messageId + " AND Desc = '" + VarDesc + "'");
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
                        OscilloControl oscilloControl = null;
                        foreach (Control control in tabPageFile.Controls)
                        {
                            if (control.GetType().Name == "OscilloControl")
                            {
                                oscilloControl = (OscilloControl)control;
                                break;
                            }                                
                        }

                        if (oscilloControl == null)
                            break;

                        oscilloControl.SetChartPreTitle("打包文件 - [" + this.TabText + "] - ", "设备类型：" + this.textBoxIEDType.Text + "     ");
                        oscilloControl.PrintContent();

                        break;
                    }
                default: break;
            }
        }        

        private void timerDock_Tick(object sender, EventArgs e)
        {
            timerDock.Enabled = false;
            foreach (OscilloControl oscilloControl in chartList)
            {
                oscilloControl.DockChart();
            }
        }
    }
}
