using IEDSToolkit.IED;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace IEDSToolkit
{
    public partial class IEDCommForm : WeifenLuo.WinFormsUI.Docking.DockContent, AnalyzeFormInterface
    {
        public String IEDType;

        private IED.CRTDB RTDB;
        private IED.CommTCPServerThread commTCPServerThread;

        private DataSet iedFile = new DataSet();
        private DataTable deviceTable, messageTable, varTable;

        private bool PasswordHasVerified = false;
        public IEDCommForm()
        {
            InitializeComponent();
        }

        public void PrintContent()
        {
        }

        private void IEDCommForm_Load(object sender, EventArgs e)
        {
            this.TabText = IEDType + "助手";

            this.comboBoxFileType.SelectedIndex = 0;

            iedFile.ReadXml(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\IED\\" + IEDType + ".xml");
            deviceTable = iedFile.Tables["Device"];
            messageTable = iedFile.Tables["Message"];
            varTable = iedFile.Tables["Var"];

            varTable.Columns.Add(new DataColumn("Message_Name", typeof(string)));
            varTable.Columns.Add(new DataColumn("Message_Type", typeof(int)));
            varTable.Columns.Add(new DataColumn("Tables", typeof(Object)));
            varTable.Columns.Add(new DataColumn("Value", typeof(string)));
            varTable.Columns.Add(new DataColumn("RefValue", typeof(string)));
            varTable.Columns.Add(new DataColumn("ValueModify", typeof(Boolean)));
            varTable.Columns.Add(new DataColumn("RefValueModify", typeof(Boolean)));
            foreach (DataRow varRow in varTable.Rows)
            {
                String messageIndex = messageTable.Rows[Convert.ToInt32(varRow["Message_Id"])]["Index"].ToString();
                DataRow[] rows = iedFile.Tables["Message"].Select("Index = '" + messageIndex + "'");
                if (rows.Length == 0)
                    continue;

                varRow["Message_Name"] = rows[0]["Name"];
                varRow["Message_Type"] = rows[0]["Type"];

                String unit = varRow["Unit"].ToString();
                if (unit != "")
                    varRow["Desc"] = varRow["Desc"] + " (" + unit + ")";
            }

            ((System.ComponentModel.ISupportInitialize)(this.gridControlCommonParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCommonParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdvancedParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdvancedParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaintenance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaintenance)).BeginInit();
            this.SuspendLayout();

            //普通定值
            DataTable dtNew = varTable.Clone();               
            DataRow[] drArr = varTable.Select("Message_Type = " + 1);
            int MessageIndex = 0;
            string LastMessageName = "";
            foreach (DataRow row in drArr)
            {
                if (LastMessageName != row["Message_Name"].ToString())
                {
                    MessageIndex++;
                    LastMessageName = row["Message_Name"].ToString();
                }

                row["Message_Name"] = MessageIndex.ToString("00") + ". " + row["Message_Name"];

                dtNew.ImportRow(row);
            }
                
            this.gridControlCommonParam.DataSource = dtNew;
            //this.gridViewCommonParam.OptionsBehavior.AutoExpandAllGroups = true;

            //工程定值
            dtNew = varTable.Clone();
            drArr = varTable.Select("Message_Type = " + 6);
            MessageIndex = 0;
            LastMessageName = "";
            foreach (DataRow row in drArr)
            {
                if (LastMessageName != row["Message_Name"].ToString())
                {
                    MessageIndex++;
                    LastMessageName = row["Message_Name"].ToString();
                }

                row["Message_Name"] = MessageIndex.ToString("00") + ". " + row["Message_Name"];

                dtNew.ImportRow(row);
            }

            this.gridControlAdvancedParam.DataSource = dtNew;
            this.gridViewAdvancedParam.OptionsBehavior.AutoExpandAllGroups = true;

            //维护信息
            dtNew = varTable.Clone();
            drArr = varTable.Select("Message_Type = " + 4);
            MessageIndex = 0;
            LastMessageName = "";
            foreach (DataRow row in drArr)
            {
                if (LastMessageName != row["Message_Name"].ToString())
                {
                    MessageIndex++;
                    LastMessageName = row["Message_Name"].ToString();
                }

                row["Message_Name"] = MessageIndex.ToString("00") + ". " + row["Message_Name"];

                dtNew.ImportRow(row);
            }

            this.gridControlMaintenance.DataSource = dtNew;
            this.gridViewMaintenance.OptionsBehavior.AutoExpandAllGroups = true;

            ((System.ComponentModel.ISupportInitialize)(this.gridControlCommonParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCommonParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdvancedParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdvancedParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaintenance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaintenance)).EndInit();

            //事件记录
            DataRow[] drMessage = messageTable.Select("Type = " + 2);
            foreach (DataRow rowMessage in drMessage)
            {
                dtNew = varTable.Clone();
                drArr = varTable.Select("Message_ID = " + rowMessage["Message_ID"]);
                
                DataTable varMsgTable = new DataTable();
                varMsgTable.Columns.Add(new DataColumn("Message_Name", typeof(string)));
                varMsgTable.Columns.Add(new DataColumn("Message_ID", typeof(int)));
                varMsgTable.Columns.Add(new DataColumn("Desc", typeof(string)));
                varMsgTable.Columns.Add(new DataColumn("Name", typeof(string)));
                varMsgTable.Columns.Add(new DataColumn("Value", typeof(string)));                               
                
                for (int i = 0;i < Convert.ToInt32(rowMessage["Count"]);i++)
                {
                    foreach (DataRow rowVar in drArr)
                    {
                        DataRow varRow = varMsgTable.NewRow();
                        varRow["Message_Name"] = "记录" + (i + 1).ToString("00");
                        varRow["Message_ID"] = rowMessage["Message_ID"];
                        varRow["Desc"] = rowVar["Desc"];
                        varRow["Name"] = rowVar["Name"] + i.ToString();

                        varMsgTable.Rows.Add(varRow);                        
                    }
                }

                TabPage tabPageEvent = new TabPage();
                tabPageEvent.Text = rowMessage["Name"].ToString();
                tabControlEvents.Controls.Add(tabPageEvent);

                DevExpress.XtraGrid.GridControl gridControlEvent = CreateEventGridControl();
                tabPageEvent.Controls.Add(gridControlEvent);

                ((System.ComponentModel.ISupportInitialize)(gridControlEvent)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(gridControlEvent.MainView)).BeginInit();

                gridControlEvent.DataSource = varMsgTable;

                ((System.ComponentModel.ISupportInitialize)(gridControlEvent)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(gridControlEvent.MainView)).EndInit();
            }

            this.ResumeLayout(false);

            RTDB = new IED.CRTDB(IEDType);
            commTCPServerThread = new IED.CommTCPServerThread(RTDB);
            commTCPServerThread.Start();

            timerRefresh.Start();
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
            gridViewEvent.GroupRowHeight = 28;
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
            gridViewEvent.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridViewCommonParam_CustomDrawGroupRow);
            gridViewEvent.GroupRowExpanding += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridViewEvent_GroupRowExpanding);
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
            gridColumn111.FieldName = "Desc";
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
            gridColumn112.FieldName = "Value";
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
        
        private void buttonRefreshAll_Click(object sender, EventArgs e)
        {

        }

        private void gridViewCommonParam_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (gridView == this.gridViewCommonParam)
            {
                int childCount = gridView.GetChildRowCount(e.RowHandle);
                for (int i = 0; i < childCount; i++)
                {
                    int childHandle = gridView.GetChildRowHandle(e.RowHandle, i);
                    DataRow row = gridView.GetDataRow(childHandle);
                    if (row["Value"].ToString() != "" && RTDB.GetDevice().HasLoadFromFile()
                            && row["RefValue"].ToString() != ""
                            && row["Value"].ToString() != row["RefValue"].ToString())
                    {
                        e.Appearance.BackColor = Color.Blue;
                        e.Appearance.ForeColor = Color.White;

                        break;
                    }
                }
            }            

            if (Math.Abs(e.RowHandle) % 2 == 0 && e.Appearance.BackColor != Color.Blue)
            {
                e.Appearance.BackColor = Color.WhiteSmoke;
            }
        }

        private delegate void delegateStartTimer();
        private void StartTimer()
        {
            this.timerRefresh.Start();
        }

        private void gridViewCommonParam_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                DataRow row = gridView.GetDataRow(e.RowHandle);

                if (e.Column.FieldName == "Value")
                {
                    this.timerRefresh.Stop();
                    
                    RTDB.GetDevice().WriteVar(row["Name"].ToString(), e.Value.ToString(), null);
                    row["ValueModify"] = true;

                    Task.Run(async delegate
                    {
                        await Task.Delay(1000);
                        int messageIndex = Convert.ToInt32(messageTable.Rows[Convert.ToInt32(row["Message_Id"])]["Index"]);
                        RTDB.GetDevice().AddUpdateMessage(RTDB.GetDevice().GetMessage(messageIndex));

                        await Task.Delay(1000);
                        this.Invoke(new delegateStartTimer(StartTimer));
                    });
                }
                else if (e.Column.FieldName == "RefValue")
                {
                    row["RefValueModify"] = true;

                    RTDB.GetDevice().SetParamValue(RTDB.GetDevice().GetVar(row["Name"].ToString()), e.Value.ToString());
                    RTDB.GetDevice().SaveParameterFile();
                }
            }
        }

        private void gridViewCommonParam_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle >= 0 && (e.Column.FieldName == "Value" || e.Column.FieldName == "RefValue"))
            {
                DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                DataRow varRow = gridView.GetDataRow(e.RowHandle);
                if (varRow == null)
                    e.RepositoryItem = null;
                else
                {
                    if (Convert.ToBoolean(varRow["Table"]))
                    {
                        DataRow[] rows = null;
                        if (varTable.Rows[e.RowHandle]["Tables"] != DBNull.Value)
                            rows = (DataRow[])varTable.Rows[e.RowHandle]["Tables"];
                        else
                        {
                            rows = iedFile.Tables["T"].Select("Var_Id = '" + varRow["Var_Id"] + "'");
                            varTable.Rows[e.RowHandle]["Tables"] = rows;
                        }

                        this.repositoryItemComboBox.Items.Clear();
                        foreach (DataRow table in rows)
                        {
                            this.repositoryItemComboBox.Items.Add(table["Value"]);
                        }

                        e.RepositoryItem = this.repositoryItemComboBox;
                    }
                    else
                    {
                        int DataType = Convert.ToInt32(varRow["DataType"]);
                        if (DataType == 9)
                            e.RepositoryItem = this.repositoryItemCheckEdit;
                        else
                        {
                            if (DataType == 5 || DataType == 6)
                                this.repositoryItemSpinEdit.IsFloatValue = true;
                            else
                                this.repositoryItemSpinEdit.IsFloatValue = false;

                            this.repositoryItemSpinEdit.MinValue = Convert.ToDecimal(varRow["Min"]);
                            this.repositoryItemSpinEdit.MaxValue = Convert.ToDecimal(varRow["Max"]);

                            e.RepositoryItem = this.repositoryItemSpinEdit;
                        }
                    }
                }
            }
        }

        private void IEDCommForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int ConnectState = Convert.ToInt32(RTDB.GetVarValue(RTDB.GetDevice().Name, "_ConnectState_"));
            if (ConnectState == 1)
            {
                DialogResult dr = MessageBox.Show("是否确定关闭本窗口？\n本操作将断开与设备的连接！", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            commTCPServerThread.Terminate();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            timerRefresh.Stop();

            int ConnectState = Convert.ToInt32(RTDB.GetVarValue(RTDB.GetDevice().Name, "_ConnectState_"));
            if (ConnectState == 1)
            {
                textBoxConnectState.Text = "已连接";
                textBoxConnectState.BackColor = Color.Blue;

                this.gridColumnValue.OptionsColumn.AllowEdit = true;
                this.gridColumnValue.OptionsColumn.ReadOnly = false;
            }
            else
            {
                if (textBoxConnectState.Text != "未连接")
                {
                    DataTable dataTable = (DataTable)gridControlCommonParam.DataSource;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["Value"] = null;
                        row["ValueModify"] = false; //清除修改状态
                    }

                    textBoxConnectState.Text = "未连接";
                    textBoxConnectState.BackColor = Color.Red;                    
                }

                this.gridColumnValue.OptionsColumn.AllowEdit = false;
                this.gridColumnValue.OptionsColumn.ReadOnly = true;

                timerRefresh.Start();
                return;
            }

            DevExpress.XtraGrid.GridControl activeGridControl = null;
            switch (tabControlMain.SelectedIndex)
            {
                case 0: activeGridControl = this.gridControlCommonParam; break;
                case 1: activeGridControl = this.gridControlAdvancedParam; break;
                case 2: activeGridControl = this.gridControlMaintenance; break;
                case 3:
                    {
                        activeGridControl = (DevExpress.XtraGrid.GridControl)(this.tabControlEvents.SelectedTab.Controls[0]);
                        break;
                    }
                default: break;
            }

            if (activeGridControl != null)
            {
                DataTable dataTable = (DataTable)activeGridControl.DataSource;
                foreach (DataRow row in dataTable.Rows)
                {
                    row["Value"] = RTDB.GetVarValue(RTDB.GetDevice().Name, row["Name"].ToString());
                }
            }            

            timerRefresh.Start();
        }

        private void gridViewCommonParam_GroupRowExpanding(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (e.RowHandle >= 0)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            int childHandle = gridView.GetChildRowHandle(e.RowHandle, 0);
            DataRow row = gridView.GetDataRow(childHandle);
            int messageIndex = Convert.ToInt32(messageTable.Rows[Convert.ToInt32(row["Message_Id"])]["Index"]);
            RTDB.GetDevice().AddUpdateMessage(RTDB.GetDevice().GetMessage(messageIndex));
        }
        
        private void gridViewEvent_GroupRowExpanding(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (e.RowHandle >= 0)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            int childHandle = gridView.GetChildRowHandle(e.RowHandle, 0);
            DataRow row = gridView.GetDataRow(childHandle);
            int messageIndex = Convert.ToInt32(messageTable.Rows[Convert.ToInt32(row["Message_Id"])]["Index"]);
            IED.DeviceBase.CMessage relativeMessage = RTDB.GetDevice().GetMessage(messageIndex);
            int recordIndex = Convert.ToInt32(row["Message_Name"].ToString().Replace("记录", "")) - 1;
            RTDB.GetDevice().AddUpdateMessage(RTDB.GetDevice().GetRecordMessage(relativeMessage, recordIndex));
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlMain.SelectedIndex)
            {
                case 1:
                    {
                        foreach (DataRow row in messageTable.Rows)
                        {
                            if (Convert.ToInt32(row["Type"]) == 6)
                            {
                                RTDB.GetDevice().AddUpdateMessage(RTDB.GetDevice().GetMessage(Convert.ToInt32(row["Index"])));
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (DataRow row in messageTable.Rows)
                        {
                            if (Convert.ToInt32(row["Type"]) == 4)
                            {
                                RTDB.GetDevice().AddUpdateMessage(RTDB.GetDevice().GetMessage(Convert.ToInt32(row["Index"])));
                            }
                        }
                        break;
                    }
                default: break;
            }
        }

        private void gridViewCommonParam_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (this.gridViewCommonParam.FocusedColumn.FieldName != "Value")
                return;

            if (PasswordHasVerified)
                return;

            String PM = Microsoft.VisualBasic.Interaction.InputBox("请输入密码...", "输入密码", "");
            if (PM != "111111")
            {
                MessageBox.Show("请输入正确的密码！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Valid = false;
                return;
            }

            PasswordHasVerified = true;
        }

        private void UpdateAllFileValue()
        {
            DataTable dataTable = (DataTable)gridControlCommonParam.DataSource;
            foreach (DataRow row in dataTable.Rows)
            {
                row["RefValue"] = RTDB.GetDevice().GetParamValue(row["Name"].ToString());
                row["RefValueModify"] = false;
            }
        }

        private void ToolStripMenuItemNewFile_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.Filter = "定值文件|*.xml";
            this.saveFileDialog.FileName = "";

            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string paramFile = this.saveFileDialog.FileName;
                //if (System.IO.File.Exists(paramFile))
                //{
                //    DialogResult dr = MessageBox.Show("已存在同名的定值文件，是否确定覆盖？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (dr == DialogResult.No)
                //        return;                    
                //}

                if (RTDB.GetDevice().NewParameterFile(paramFile))
                {
                    this.textBoxParamFile.Text = paramFile;

                    this.gridColumnRefValue.OptionsColumn.AllowEdit = true;
                    this.gridColumnRefValue.OptionsColumn.ReadOnly = false;

                    this.buttonToDevice.Enabled = true;
                    this.buttonToFile.Enabled = true;
                }
                else
                {
                    this.textBoxParamFile.Text = "";

                    this.gridColumnRefValue.OptionsColumn.AllowEdit = false;
                    this.gridColumnRefValue.OptionsColumn.ReadOnly = true;

                    this.buttonToDevice.Enabled = false;
                    this.buttonToFile.Enabled = false;
                }

                UpdateAllFileValue();
            }
        }

        private void ToolStripMenuItemLoadFile_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "定值文件|*.xml";
            this.openFileDialog.FileName = "";

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string paramFile = this.openFileDialog.FileName;

                if (RTDB.GetDevice().LoadParameterFile(paramFile))
                {
                    this.textBoxParamFile.Text = paramFile;

                    this.gridColumnRefValue.OptionsColumn.AllowEdit = true;
                    this.gridColumnRefValue.OptionsColumn.ReadOnly = false;

                    this.buttonToDevice.Enabled = true;
                    this.buttonToFile.Enabled = true;
                }
                else
                {
                    this.textBoxParamFile.Text = "";

                    this.gridColumnRefValue.OptionsColumn.AllowEdit = false;
                    this.gridColumnRefValue.OptionsColumn.ReadOnly = true;

                    this.buttonToDevice.Enabled = false;
                    this.buttonToFile.Enabled = false;
                }

                UpdateAllFileValue();
            }
        }

        private void ToolStripMenuItemWizard_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemCheck_Click(object sender, EventArgs e)
        {

        }

        private bool ExportData(int MessageType, String TypeName, XmlDocument ExpDocument)
        {
            this.progressBar.Value = 0;

            DeviceBase device = RTDB.GetDevice();
            List<DeviceBase.CMessage> messages = new List<DeviceBase.CMessage>();
            foreach (DeviceBase.CMessage message in device.Messages)
            {
                if (message.Type == MessageType)
                    messages.Add(message);
            }

            progressBar.Maximum = messages.Count;

            XmlElement root = (XmlElement)ExpDocument.SelectSingleNode("Data");
            XmlElement dataNode = ExpDocument.CreateElement(TypeName);
            root.AppendChild(dataNode);

            System.Threading.AutoResetEvent NotifyObj = new System.Threading.AutoResetEvent(false);
            foreach (DeviceBase.CMessage message in messages)
            {
                DeviceBase.CMessage messageClone = message.Clone();           
                if (!device.ExchangeMessage(messageClone, NotifyObj))
                {
                    MessageBox.Show("从设备读取数据失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.panelProgress.Visible = false;
                    return false;
                }

                //存储变量值
                XmlElement MessageNode = ExpDocument.CreateElement("Message");
                MessageNode.SetAttribute("Name", message.Name);
                dataNode.AppendChild(MessageNode);

                foreach (DeviceBase.CVar var in message.Vars)
                {
                    XmlElement VarNode = ExpDocument.CreateElement("Var");
                    VarNode.SetAttribute("Name", var.Desc);
                    VarNode.SetAttribute("Value", CommonUtility.FormatedString(RTDB.GetVarValue(device.Name, var.Name)));

                    MessageNode.AppendChild(VarNode);
                }

                this.progressBar.Value++;
            }

            return true;
        }

        private bool ExportEvents(XmlDocument ExpDocument)
        {
            this.progressBar.Value = 0;

            DeviceBase device = RTDB.GetDevice();

            int MessageCount = 0;

            List<DeviceBase.CMessage> messages = new List<DeviceBase.CMessage>();
            foreach (DeviceBase.CMessage message in device.Messages)
            {
                if (message.Type == 2)
                {
                    messages.Add(message);
                    MessageCount += message.Count;
                }                    
            }

            progressBar.Maximum = MessageCount;

            XmlElement root = (XmlElement)ExpDocument.SelectSingleNode("Data");
            XmlElement dataNode = ExpDocument.CreateElement("Events");
            root.AppendChild(dataNode);

            System.Threading.AutoResetEvent NotifyObj = new System.Threading.AutoResetEvent(false);
            foreach (DeviceBase.CMessage message in messages)
            {
                for (int j = 0; j < message.Count; j++)
                {
                    DeviceBase.CMessage messageClone = device.GetRecordMessage(message, j);
                    if (!device.ExchangeMessage(messageClone, NotifyObj))
                    {
                        MessageBox.Show("从设备读取数据失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.panelProgress.Visible = false;
                        return false;
                    }

                    //存储变量值
                    XmlElement MessageNode = ExpDocument.CreateElement("Message");
                    MessageNode.SetAttribute("Name", message.Name + j.ToString());
                    dataNode.AppendChild(MessageNode);

                    foreach (DeviceBase.CVar var in message.Vars)
                    {
                        XmlElement VarNode = ExpDocument.CreateElement("Var");
                        VarNode.SetAttribute("Name", var.Desc + j.ToString());
                        VarNode.SetAttribute("Value", CommonUtility.FormatedString(RTDB.GetVarValue(device.Name, var.Name + j.ToString())));

                        MessageNode.AppendChild(VarNode);
                    }

                    this.progressBar.Value++;
                }                
            }

            return true;
        }

        private bool ExportOscillo(XmlDocument ExpDocument)
        {
            this.progressBar.Value = 0;

            XmlElement root = (XmlElement)ExpDocument.SelectSingleNode("Data");
            XmlElement dataNode = ExpDocument.CreateElement("Oscillo");
            root.AppendChild(dataNode);

            DeviceBase device = RTDB.GetDevice();
            System.Threading.AutoResetEvent NotifyObj = new System.Threading.AutoResetEvent(false);
            DeviceBase.CMessage OscilloMessage = device.GetMessage(53);
            int[] FileData = new int[776 * 2 + 4];

            for (byte FileNumber = 0; FileNumber < 3; FileNumber++)
            {
                //读取记录标识
                DeviceBase.CMessage message = OscilloMessage.Clone();
                message.Schema[0] = (byte)device.Address;
                message.Schema[5] = FileNumber;
                message.Schema[7] = 0;
                message.Schema[9] = 8;
                if (!device.ExchangeMessage(message, NotifyObj))
                {
                    MessageBox.Show("读取波形文件失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (message.Response[5] == 0)
                {
                    //MessageBox.Show("波形文件数据为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                float Ratio = 1;
                System.Array.Copy(message.Response, 5, FileData, 0, 8 * 2);

                if (FileNumber != 2)
                {
                    //读取电流变比，从工程定值中读取相电流CT配置，然后除以2.5mA
                    message = device.GetMessage(33).Clone();
                    if (!device.ExchangeMessage(message, NotifyObj))
                    {
                        MessageBox.Show("读取CT变比失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    int CT = message.Response[3] * 256 + message.Response[4];
                    switch (CT)
                    {
                        case 1: break;
                        case 2: CT = 5; break;
                        case 3: CT = 25; break;
                        case 4: CT = 2; break;
                        case 5: CT = 100; break;
                        case 6: CT = 160; break;
                        case 7: CT = 250; break;
                        default: break;
                    }

                    double CTOutput = Convert.ToDouble(OscilloMessage.Vars[0].Default.ToString());
                    Ratio = (float)CT * 1000 / (float)CTOutput;
                }

                this.labelInfo.Text = "正在打包数据，请稍候... [录波文件" + FileNumber + "]";
                this.progressBar.Value = 0;
                this.progressBar.Maximum = 48;                

                //读取记录标识
                message = OscilloMessage.Clone();
                message.Schema[0] = (byte)device.Address;
                message.Schema[5] = FileNumber;
                message.Schema[7] = 0;
                message.Schema[9] = 8;
                message.NotifyObj = NotifyObj;

                for (int i = 0; i < 48; i++)
                {
                    int RecordNumber = 8 + i * 16;
                    message.Schema[6] = (byte)((RecordNumber & 0xFF00) >> 8);
                    message.Schema[7] = (byte)(RecordNumber & 0x00FF);
                    message.Schema[9] = 16;
                    if (!device.ExchangeMessage(message, NotifyObj))
                    {
                        MessageBox.Show("读取波形文件失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.panelProgress.Visible = false;
                        return false;
                    }

                    System.Array.Copy(message.Response, 5, FileData, 8 * 2 + i * 16 * 2, 16 * 2);

                    this.progressBar.Value++;
                }                

                byte[] buffer = new byte[FileData.Length];
                for (int i = 0; i < FileData.Length - 4; i++)
                {
                    buffer[i] = (byte)(FileData[i] & 0xFF);
                }

                //存储Ratio
                byte[] RatioBytes = BitConverter.GetBytes(Ratio);
                for (int i = FileData.Length - 4, j = 0; i < FileData.Length; i++, j++)
                    buffer[i] = RatioBytes[j];

                XmlElement OscilloNode = ExpDocument.CreateElement("File");
                OscilloNode.SetAttribute("Name", "Oscillo" + FileNumber);
                OscilloNode.InnerText = Convert.ToBase64String(buffer);
                dataNode.AppendChild(OscilloNode);
            }

            return true;
        }

        private void ToolStripMenuItemPackage_Click(object sender, EventArgs e)
        {
            int ConnectState = Convert.ToInt32(RTDB.GetVarValue(RTDB.GetDevice().Name, "_ConnectState_"));
            if (ConnectState != 1)
            {
                MessageBox.Show("设备未连接，不能打包数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (CreatePackageForm createPackageForm = new CreatePackageForm())
            {
                if (createPackageForm.ShowDialog() == DialogResult.OK)
                {
                    this.saveFileDialog.Filter = "打包数据文件|Exp_*.dat";
                    this.saveFileDialog.FileName = "";
                    string saveFileName;
                    if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        saveFileName = "Exp_" + System.IO.Path.GetFileName(this.saveFileDialog.FileName).Substring(4);
                        saveFileName = System.IO.Path.GetDirectoryName(this.saveFileDialog.FileName) + "\\" + saveFileName;
                    }
                    else
                        return;

                    XmlDocument ExpDocument;
                    try
                    {
                        ExpDocument = new XmlDocument();

                        XmlDeclaration declaration = ExpDocument.CreateXmlDeclaration("1.0", "utf-8", "yes");
                        ExpDocument.AppendChild(declaration);

                        XmlElement root = ExpDocument.CreateElement("Data");
                        root.SetAttribute("Name", RTDB.GetDevice().Name);
                        root.SetAttribute("CreateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ExpDocument.AppendChild(root);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("新建数据文件失败！错误信息：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.labelInfo.Text = "正在打包数据，请稍候...";
                    this.progressBar.Value = 0;
                    this.panelProgress.Top = this.Height / 2;
                    this.panelProgress.Left = (this.Width - this.panelProgress.Width) / 2;
                    this.panelProgress.Visible = true;

                    bool HasError = false;
                    foreach (String selectObj in createPackageForm.checkedListBoxType.CheckedItems)
                    {
                        if (selectObj == "实时数据")
                        {
                            this.labelInfo.Text = "正在打包数据，请稍候... [" + selectObj + "]";
                            if (!ExportData(0, "RealTime", ExpDocument))
                            {
                                HasError = false;
                                break;
                            }                                
                        }
                        else if (selectObj == "普通定值")
                        {
                            this.labelInfo.Text = "正在打包数据，请稍候... [" + selectObj + "]";
                            if (!ExportData(1, "CommonParam", ExpDocument))
                            {
                                HasError = false;
                                break;
                            }
                        }
                        else if (selectObj == "工程定值")
                        {
                            this.labelInfo.Text = "正在打包数据，请稍候... [" + selectObj + "]";
                            if (!ExportData(6, "AdvancedParam", ExpDocument))
                            {
                                HasError = false;
                                break;
                            }
                        }
                        else if (selectObj == "维护信息")
                        {
                            this.labelInfo.Text = "正在打包数据，请稍候... [" + selectObj + "]";
                            if (!ExportData(4, "Maintenance", ExpDocument))
                            {
                                HasError = false;
                                break;
                            }
                        }
                        else if (selectObj == "事件记录")
                        {
                            this.labelInfo.Text = "正在打包数据，请稍候... [" + selectObj + "]";
                            if (!ExportEvents(ExpDocument))
                            {
                                HasError = false;
                                break;
                            }
                        }
                        else if (selectObj == "录波文件")
                        {
                            this.labelInfo.Text = "正在打包数据，请稍候... [" + selectObj + "]";
                            if (!ExportOscillo(ExpDocument))
                            {
                                HasError = false;
                                break;
                            }
                        }
                    }

                    this.panelProgress.Visible = false;
                    try
                    {
                        if (!HasError)
                        {
                            ExpDocument.Save(saveFileName);
                            MessageBox.Show("所选数据已打包到文件[" + saveFileName + "]！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }                            
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存数据文件失败！错误信息：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridViewCommonParam_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                DataRow row = gridView.GetDataRow(e.RowHandle);

                if (e.Column.FieldName == "Value"
                        && row["ValueModify"] != DBNull.Value
                        && Convert.ToBoolean(row["ValueModify"]))
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (e.Column.FieldName == "RefValue"
                        && row["RefValueModify"] != DBNull.Value
                        && Convert.ToBoolean(row["RefValueModify"]))
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (e.Column.FieldName == "Desc")
                {
                    if (row["Value"].ToString() != "" && RTDB.GetDevice().HasLoadFromFile()
                        && row["RefValue"].ToString() != "" && row["Value"].ToString() != row["RefValue"].ToString())
                    {
                        e.Appearance.BackColor = Color.Blue;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
        }

        private void toolStripMenuItemDownload_Click(object sender, EventArgs e)
        {
            int messageIndex = -1;

            int FocusRowHandle = this.gridViewCommonParam.FocusedRowHandle;
            if (FocusRowHandle < 0)
            {
                DialogResult dr = MessageBox.Show("是否确定将本类型的所有参考值整定到设备？\n本操作将更改设备定值，请慎重操作！", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                    return;

                this.timerRefresh.Stop();

                int childCount = this.gridViewCommonParam.GetChildRowCount(FocusRowHandle);
                for (int i = 0; i < childCount; i++)
                {
                    int childHandle = this.gridViewCommonParam.GetChildRowHandle(FocusRowHandle, i);
                    DataRow row = this.gridViewCommonParam.GetDataRow(childHandle);
                    if (row["Value"].ToString() != "" && RTDB.GetDevice().HasLoadFromFile()
                            && row["RefValue"].ToString() != "" && row["Value"].ToString() != row["RefValue"].ToString())
                    {
                        RTDB.GetDevice().WriteVar(row["Name"].ToString(), row["RefValue"].ToString(), null);
                        row["ValueModify"] = true;

                        messageIndex = Convert.ToInt32(messageTable.Rows[Convert.ToInt32(row["Message_Id"])]["Index"]);

                        //System.Threading.Thread.Sleep(100);
                    }
                }
            }
            else
            {
                DataRow row = this.gridViewCommonParam.GetFocusedDataRow();
                if (row["Value"].ToString() != "" && RTDB.GetDevice().HasLoadFromFile()
                        && row["RefValue"].ToString() != "" && row["Value"].ToString() != row["RefValue"].ToString())
                {
                    DialogResult dr = MessageBox.Show("是否确定将所选参考值整定到设备？\n本操作将更改设备定值，请慎重操作！", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
                        return;

                    this.timerRefresh.Stop();

                    RTDB.GetDevice().WriteVar(row["Name"].ToString(), row["RefValue"].ToString(), null);
                    row["ValueModify"] = true;

                    messageIndex = Convert.ToInt32(messageTable.Rows[Convert.ToInt32(row["Message_Id"])]["Index"]);
                }
            }

            if (messageIndex >= 0)
            {
                Task.Run(async delegate
                {
                    await Task.Delay(1000);
                    RTDB.GetDevice().AddUpdateMessage(RTDB.GetDevice().GetMessage(messageIndex));

                    await Task.Delay(1000);
                    this.Invoke(new delegateStartTimer(StartTimer));
                });
            }
        }

        private void toolStripMenuItemUpload_Click(object sender, EventArgs e)
        {
            int FocusRowHandle = this.gridViewCommonParam.FocusedRowHandle;
            if (FocusRowHandle < 0)
            {
                DialogResult dr = MessageBox.Show("是否确定将本类型所有的定值当前值来更新定值文件？\n本操作将更改定值文件中的参考定值，请慎重操作！", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                    return;

                this.timerRefresh.Stop();

                int childCount = this.gridViewCommonParam.GetChildRowCount(FocusRowHandle);
                for (int i = 0; i < childCount; i++)
                {
                    int childHandle = this.gridViewCommonParam.GetChildRowHandle(FocusRowHandle, i);
                    DataRow row = this.gridViewCommonParam.GetDataRow(childHandle);
                    if (row["Value"].ToString() != "" && RTDB.GetDevice().HasLoadFromFile()
                            && row["RefValue"].ToString() != "" && row["Value"].ToString() != row["RefValue"].ToString())
                    {
                        row["RefValueModify"] = true;

                        row["RefValue"] = row["Value"];
                        RTDB.GetDevice().SetParamValue(RTDB.GetDevice().GetVar(row["Name"].ToString()), row["Value"].ToString());                        
                    }
                }

                RTDB.GetDevice().SaveParameterFile();

                this.timerRefresh.Start();
            }
            else
            {
                DataRow row = this.gridViewCommonParam.GetFocusedDataRow();
                if (row["Value"].ToString() != "" && RTDB.GetDevice().HasLoadFromFile()
                        && row["RefValue"].ToString() != "" && row["Value"].ToString() != row["RefValue"].ToString())
                {
                    DialogResult dr = MessageBox.Show("是否确定将所选定值当前值来更新定值文件？\n本操作将更改定值文件中的参考定值，请慎重操作！", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
                        return;

                    this.timerRefresh.Stop();

                    row["RefValueModify"] = true;

                    row["RefValue"] = row["Value"];
                    RTDB.GetDevice().SetParamValue(RTDB.GetDevice().GetVar(row["Name"].ToString()), row["Value"].ToString());
                    RTDB.GetDevice().SaveParameterFile();

                    this.timerRefresh.Start();
                }
            }
        }

        private void contextMenuStripGridControl_Opening(object sender, CancelEventArgs e)
        {
            bool CanShow = false;
            int FocusRowHandle = this.gridViewCommonParam.FocusedRowHandle;
            if (FocusRowHandle < 0)
            {
                int childCount = this.gridViewCommonParam.GetChildRowCount(FocusRowHandle);
                for (int i = 0; i < childCount; i++)
                {
                    int childHandle = this.gridViewCommonParam.GetChildRowHandle(FocusRowHandle, i);
                    DataRow row = this.gridViewCommonParam.GetDataRow(childHandle);
                    if (row["Value"].ToString() != "" && RTDB.GetDevice().HasLoadFromFile()
                            && row["RefValue"].ToString() != "" && row["Value"].ToString() != row["RefValue"].ToString())
                    {
                        CanShow = true;
                        break;
                    }
                }
            }
            else
            {
                DataRow row = this.gridViewCommonParam.GetFocusedDataRow();
                if (row["Value"].ToString() != "" && RTDB.GetDevice().HasLoadFromFile()
                        && row["RefValue"].ToString() != "" && row["Value"].ToString() != row["RefValue"].ToString())
                {
                    CanShow = true;
                }
            }

            e.Cancel = !CanShow;
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

        private void buttonRead_Click(object sender, EventArgs e)
        {
            //读取波形文件
            int ConnectState = Convert.ToInt32(RTDB.GetVarValue(RTDB.GetDevice().Name, "_ConnectState_"));
            if (ConnectState != 1)
            {
                MessageBox.Show("设备未连接，不能读取波形文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DeviceBase device = RTDB.GetDevice();

            byte FileNumber = (byte)this.comboBoxFileType.SelectedIndex;
            System.Threading.AutoResetEvent NotifyObj = new System.Threading.AutoResetEvent(false);
            DeviceBase.CMessage OscilloMessage = device.GetMessage(53);
            //读取记录标识
            DeviceBase.CMessage message = OscilloMessage.Clone();
            message.Schema[0] = (byte)device.Address;
            message.Schema[5] = FileNumber;
            message.Schema[7] = 0;
            message.Schema[9] = 8;
            if (!device.ExchangeMessage(message, NotifyObj))
            {
                MessageBox.Show("读取波形文件失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (message.Response[5] == 0)
            {
                MessageBox.Show("波形文件数据为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float Ratio = 1;
            int[] FileData = new int[776 * 2 + 4];
            System.Array.Copy(message.Response, 5, FileData, 0, 8 * 2);

            if (FileNumber != 2)
            {
                //读取电流变比，从工程定值中读取相电流CT配置，然后除以2.5mA
                message = device.GetMessage(33).Clone();
                if (!device.ExchangeMessage(message, NotifyObj))
                {
                    MessageBox.Show("读取CT变比失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int CT = message.Response[3] * 256 + message.Response[4];
                switch (CT)
                {
                    case 1: break;
                    case 2: CT = 5; break;
                    case 3: CT = 25; break;
                    case 4: CT = 2; break;
                    case 5: CT = 100; break;
                    case 6: CT = 160; break;
                    case 7: CT = 250; break;
                    default: break;
                }

                double CTOutput = Convert.ToDouble(OscilloMessage.Vars[0].Default.ToString());
                Ratio = (float)CT * 1000 / (float)CTOutput;
            }

            this.saveFileDialog.Filter = "录波文件|Osc_*.dat";
            this.saveFileDialog.FileName = "";
            string saveFileName;
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveFileName = "Osc_" + System.IO.Path.GetFileName(this.saveFileDialog.FileName).Substring(4);
                saveFileName = System.IO.Path.GetDirectoryName(this.saveFileDialog.FileName) + "\\" + saveFileName;
            }
            else
                return;

            this.labelInfo.Text = "正在读取录波文件，请稍候...";
            this.progressBar.Value = 0;
            this.progressBar.Maximum = 48;
            this.panelProgress.Top = this.Height / 2;
            this.panelProgress.Left = (this.Width - this.panelProgress.Width) / 2;
            this.panelProgress.Visible = true;

            //读取记录标识
            message = OscilloMessage.Clone();
            message.Schema[0] = (byte)device.Address;
            message.Schema[5] = FileNumber;
            message.Schema[7] = 0;
            message.Schema[9] = 8;
            message.NotifyObj = NotifyObj;

            for (int i = 0; i < 48; i++)
            {
                int RecordNumber = 8 + i * 16;
                message.Schema[6] = (byte)((RecordNumber & 0xFF00) >> 8);
                message.Schema[7] = (byte)(RecordNumber & 0x00FF);
                message.Schema[9] = 16;
                if (!device.ExchangeMessage(message, NotifyObj))
                {
                    MessageBox.Show("读取波形文件失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.panelProgress.Visible = false;
                    return;
                }

                System.Array.Copy(message.Response, 5, FileData, 8 * 2 + i * 16 * 2, 16 * 2);

                this.progressBar.Value++;
            }

            this.panelProgress.Visible = false;
            
            byte[] buffer = new byte[FileData.Length];
            for (int i = 0; i < FileData.Length - 4; i++)
            {
                buffer[i] = (byte)(FileData[i] & 0xFF);
            }

            //存储Ratio
            byte[] RatioBytes = BitConverter.GetBytes(Ratio);
            for (int i = FileData.Length - 4, j = 0; i < FileData.Length; i++, j++)
                buffer[i] = RatioBytes[j];

            FileStream fos = new FileStream(saveFileName, FileMode.Create);
            try
            {
                fos.Write(buffer, 0, buffer.Length);
                MessageBox.Show("波形文件已存储到[" + saveFileName + "]！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fos.Dispose();
            }
            catch (IOException ex)
            {
                MessageBox.Show("波形文件保存失败！\n错误信息：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DrawOscilloGraph(saveFileName);
        }

        private void DrawOscilloGraph(string FileName)
        {
            this.listViewFile.Items.Clear();
            this.chart.Series.Clear();
            this.chart.ChartAreas.Clear();

            this.textBoxOscilloFile.Text = System.IO.Path.GetFileName(FileName);

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
                    float MaxStarter = OscilloForm.DrawStarterOscillogram(chart, TotalPoints, RunningPoint, FileData, DataIndex);

                    ListViewItem itemVar = new ListViewItem();
                    itemVar.Text = "起动最大电流";
                    itemVar.SubItems.Add(MaxStarter.ToString("0.00"));
                    listViewFile.Items.Add(itemVar);
                }
                else
                    OscilloForm.DrawFaultOscillogram(chart, FileData, DataIndex, Ratio);

                ((System.ComponentModel.ISupportInitialize)(chart)).EndInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("录波文件加载错误！\n错误信息：" + ex.Message);
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "录波文件|Osc_*.dat";
            this.openFileDialog.FileName = "";

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DrawOscilloGraph(this.openFileDialog.FileName);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string keyword = this.textBoxKeyword.Text.Trim();
            if (keyword == "")
            {
                MessageBox.Show("请输入搜索关键字！");
                return;
            }

            int FocusedRowHandle = this.gridViewCommonParam.FocusedRowHandle;

            DataTable dataTable = (DataTable)gridControlCommonParam.DataSource;
            DataRow[] rows = dataTable.Select("(Message_Name LIKE '%" + keyword + "%') OR (Desc LIKE '%" + keyword + "%') OR (Value LIKE '%" + keyword + "%') OR (RefValue LIKE '%" + keyword + "%')");

            if (rows.Length > 0)
            {
                int LastRowIndex = this.gridViewCommonParam.GetRowHandle(dataTable.Rows.IndexOf(rows[rows.Length - 1]));
                if (LastRowIndex <= FocusedRowHandle)
                    FocusedRowHandle = -1;
            }            

            foreach (DataRow row in rows)
            {
                int RowIndex = this.gridViewCommonParam.GetRowHandle(dataTable.Rows.IndexOf(row));
                if (RowIndex >= FocusedRowHandle + 1)
                {
                    this.gridViewCommonParam.SelectRow(RowIndex);
                    this.gridViewCommonParam.FocusedRowHandle = RowIndex;
                    this.gridViewCommonParam.FocusedColumn = this.gridViewCommonParam.Columns["Value"];

                    //this.gridViewCommonParam.Focus();
                    break;
                }
            }            
        }

        private void textBoxKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Enter))
            {
                buttonSearch_Click(null, null);
            }
        }

        private void buttonToDevice_Click(object sender, EventArgs e)
        {
            int ConnectState = Convert.ToInt32(RTDB.GetVarValue(RTDB.GetDevice().Name, "_ConnectState_"));
            if (ConnectState != 1)
            {
                MessageBox.Show("设备未连接，不能将当前定值文件下载到设备！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("是否确定将当前定值文件的所有参考值整定到设备？\n本操作将更改所有的设备定值，请慎重操作！", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;

            this.labelInfo.Text = "正在下载定值文件，请稍候...";
            this.progressBar.Value = 0;
            this.panelProgress.Top = this.Height / 2;
            this.panelProgress.Left = (this.Width - this.panelProgress.Width) / 2;
            this.panelProgress.Visible = true;

            if (RTDB.GetDevice().SaveAllToDevice(this.progressBar))
            {
                UpdateAllFileValue();

                this.panelProgress.Visible = false;

                MessageBox.Show("下载定值文件成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.panelProgress.Visible = false;
                MessageBox.Show("下载定值文件失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonToFile_Click(object sender, EventArgs e)
        {
            int ConnectState = Convert.ToInt32(RTDB.GetVarValue(RTDB.GetDevice().Name, "_ConnectState_"));
            if (ConnectState != 1)
            {
                MessageBox.Show("设备未连接，不能读取所有设备定值来更新定值文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("是否确定读取本设备所有的定值来更新当前定值文件？\n本操作将更改定值文件中的参考定值，请慎重操作！", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;

            this.labelInfo.Text = "正在读取设备定值，请稍候...";
            this.progressBar.Value = 0;
            this.panelProgress.Top = this.Height / 2;
            this.panelProgress.Left = (this.Width - this.panelProgress.Width) / 2;
            this.panelProgress.Visible = true;

            if (RTDB.GetDevice().SaveAllToFile(this.progressBar))
            {
                UpdateAllFileValue();

                this.panelProgress.Visible = false;

                MessageBox.Show("更新定值文件成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.panelProgress.Visible = false;
                MessageBox.Show("更新定值文件失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
