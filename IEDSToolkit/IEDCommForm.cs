using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void ToolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRefreshAll_Click(object sender, EventArgs e)
        {

        }

        private void gridViewCommonParam_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            int childCount = gridView.GetChildRowCount(e.RowHandle);
            for (int i = 0; i < childCount; i++)
            {
                int childHandle = gridView.GetChildRowHandle(e.RowHandle, i);
                DataRow row = gridView.GetDataRow(childHandle);
                if (row["Value"].ToString() != "" && RTDB.GetDevice().HasLoadFromFile()
                        && row["Value"].ToString() != row["RefValue"].ToString())
                {
                    e.Appearance.BackColor = Color.Blue;
                    e.Appearance.ForeColor = Color.White;

                    break;
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

                    this.ToolStripMenuItemAction.Enabled = true;
                }
                else
                {
                    this.textBoxParamFile.Text = "";

                    this.gridColumnRefValue.OptionsColumn.AllowEdit = false;
                    this.gridColumnRefValue.OptionsColumn.ReadOnly = true;

                    this.ToolStripMenuItemAction.Enabled = false;
                }

                UpdateAllFileValue();
            }
        }

        private void ToolStripMenuItemLoadFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string paramFile = this.openFileDialog.FileName;

                if (RTDB.GetDevice().LoadParameterFile(paramFile))
                {
                    this.textBoxParamFile.Text = paramFile;

                    this.gridColumnRefValue.OptionsColumn.AllowEdit = true;
                    this.gridColumnRefValue.OptionsColumn.ReadOnly = false;

                    this.ToolStripMenuItemAction.Enabled = true;
                }
                else
                {
                    this.textBoxParamFile.Text = "";

                    this.gridColumnRefValue.OptionsColumn.AllowEdit = false;
                    this.gridColumnRefValue.OptionsColumn.ReadOnly = true;

                    this.ToolStripMenuItemAction.Enabled = false;
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

        private void ToolStripMenuItemPackage_Click(object sender, EventArgs e)
        {

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
                        && row["Value"].ToString() != row["RefValue"].ToString())
                    {
                        e.Appearance.BackColor = Color.Blue;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
        }

        private void toolStripMenuItemDownload_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemUpload_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStripGridControl_Opening(object sender, CancelEventArgs e)
        {
            //DataRow row = this.gridViewCommonParam.style();
            
        }

        private void ToolStripMenuItemToDevice_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemToFile_Click(object sender, EventArgs e)
        {

        }
    }
}
