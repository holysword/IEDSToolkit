namespace IEDSToolkit
{
    partial class IEDCommForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IEDCommForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemParamMng = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemLoadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemWizard = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageCommonParam = new System.Windows.Forms.TabPage();
            this.gridControlCommonParam = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStripGridControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewCommonParam = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRefValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.tabPageAdvancedParam = new System.Windows.Forms.TabPage();
            this.gridControlAdvancedParam = new DevExpress.XtraGrid.GridControl();
            this.gridViewAdvancedParam = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageMaintenance = new System.Windows.Forms.TabPage();
            this.gridControlMaintenance = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaintenance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageEvents = new System.Windows.Forms.TabPage();
            this.tabControlEvents = new System.Windows.Forms.TabControl();
            this.tabPageOscillo = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxOscilloFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.comboBoxFileType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonToFile = new System.Windows.Forms.Button();
            this.buttonToDevice = new System.Windows.Forms.Button();
            this.textBoxParamFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxConnectState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRefreshAll = new System.Windows.Forms.Button();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelProgress = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelInfo = new System.Windows.Forms.Label();
            this.timerDock = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageCommonParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCommonParam)).BeginInit();
            this.contextMenuStripGridControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCommonParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPageAdvancedParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdvancedParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdvancedParam)).BeginInit();
            this.tabPageMaintenance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaintenance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaintenance)).BeginInit();
            this.tabPageEvents.SuspendLayout();
            this.tabPageOscillo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设备ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(4, 44);
            this.menuStrip.MdiWindowListItem = this.设备ToolStripMenuItem;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(162, 27);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 设备ToolStripMenuItem
            // 
            this.设备ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemParamMng,
            this.ToolStripMenuItemPackage});
            this.设备ToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.设备ToolStripMenuItem.MergeIndex = 0;
            this.设备ToolStripMenuItem.Name = "设备ToolStripMenuItem";
            this.设备ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.设备ToolStripMenuItem.Text = "设备(&D)";
            // 
            // ToolStripMenuItemParamMng
            // 
            this.ToolStripMenuItemParamMng.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNewFile,
            this.ToolStripMenuItemLoadFile,
            this.toolStripMenuItem3,
            this.ToolStripMenuItemWizard,
            this.ToolStripMenuItemCheck});
            this.ToolStripMenuItemParamMng.Name = "ToolStripMenuItemParamMng";
            this.ToolStripMenuItemParamMng.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemParamMng.Text = "定值管理";
            // 
            // ToolStripMenuItemNewFile
            // 
            this.ToolStripMenuItemNewFile.Name = "ToolStripMenuItemNewFile";
            this.ToolStripMenuItemNewFile.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemNewFile.Text = "新建定值文件";
            this.ToolStripMenuItemNewFile.Click += new System.EventHandler(this.ToolStripMenuItemNewFile_Click);
            // 
            // ToolStripMenuItemLoadFile
            // 
            this.ToolStripMenuItemLoadFile.Name = "ToolStripMenuItemLoadFile";
            this.ToolStripMenuItemLoadFile.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemLoadFile.Text = "加载定值文件";
            this.ToolStripMenuItemLoadFile.Click += new System.EventHandler(this.ToolStripMenuItemLoadFile_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // ToolStripMenuItemWizard
            // 
            this.ToolStripMenuItemWizard.Name = "ToolStripMenuItemWizard";
            this.ToolStripMenuItemWizard.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemWizard.Text = "定值整定向导";
            this.ToolStripMenuItemWizard.Click += new System.EventHandler(this.ToolStripMenuItemWizard_Click);
            // 
            // ToolStripMenuItemCheck
            // 
            this.ToolStripMenuItemCheck.Name = "ToolStripMenuItemCheck";
            this.ToolStripMenuItemCheck.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemCheck.Text = "安全性检查";
            this.ToolStripMenuItemCheck.Click += new System.EventHandler(this.ToolStripMenuItemCheck_Click);
            // 
            // ToolStripMenuItemPackage
            // 
            this.ToolStripMenuItemPackage.Name = "ToolStripMenuItemPackage";
            this.ToolStripMenuItemPackage.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemPackage.Text = "数据打包(&P)";
            this.ToolStripMenuItemPackage.Click += new System.EventHandler(this.ToolStripMenuItemPackage_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageCommonParam);
            this.tabControlMain.Controls.Add(this.tabPageAdvancedParam);
            this.tabControlMain.Controls.Add(this.tabPageMaintenance);
            this.tabControlMain.Controls.Add(this.tabPageEvents);
            this.tabControlMain.Controls.Add(this.tabPageOscillo);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.HotTrack = true;
            this.tabControlMain.ItemSize = new System.Drawing.Size(80, 32);
            this.tabControlMain.Location = new System.Drawing.Point(8, 61);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(811, 446);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 3;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageCommonParam
            // 
            this.tabPageCommonParam.Controls.Add(this.gridControlCommonParam);
            this.tabPageCommonParam.Controls.Add(this.panel3);
            this.tabPageCommonParam.Location = new System.Drawing.Point(4, 36);
            this.tabPageCommonParam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageCommonParam.Name = "tabPageCommonParam";
            this.tabPageCommonParam.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageCommonParam.Size = new System.Drawing.Size(803, 406);
            this.tabPageCommonParam.TabIndex = 1;
            this.tabPageCommonParam.Text = "普通定值";
            this.tabPageCommonParam.UseVisualStyleBackColor = true;
            // 
            // gridControlCommonParam
            // 
            this.gridControlCommonParam.ContextMenuStrip = this.contextMenuStripGridControl;
            this.gridControlCommonParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCommonParam.Location = new System.Drawing.Point(3, 49);
            this.gridControlCommonParam.MainView = this.gridViewCommonParam;
            this.gridControlCommonParam.Name = "gridControlCommonParam";
            this.gridControlCommonParam.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit,
            this.repositoryItemComboBox,
            this.repositoryItemCheckEdit});
            this.gridControlCommonParam.Size = new System.Drawing.Size(797, 353);
            this.gridControlCommonParam.TabIndex = 2;
            this.gridControlCommonParam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCommonParam});
            // 
            // contextMenuStripGridControl
            // 
            this.contextMenuStripGridControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDownload,
            this.toolStripMenuItemUpload});
            this.contextMenuStripGridControl.Name = "contextMenuStripGridControl";
            this.contextMenuStripGridControl.Size = new System.Drawing.Size(185, 48);
            this.contextMenuStripGridControl.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripGridControl_Opening);
            // 
            // toolStripMenuItemDownload
            // 
            this.toolStripMenuItemDownload.Name = "toolStripMenuItemDownload";
            this.toolStripMenuItemDownload.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItemDownload.Text = "参考值整定到设备";
            this.toolStripMenuItemDownload.Click += new System.EventHandler(this.toolStripMenuItemDownload_Click);
            // 
            // toolStripMenuItemUpload
            // 
            this.toolStripMenuItemUpload.Name = "toolStripMenuItemUpload";
            this.toolStripMenuItemUpload.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItemUpload.Text = "当前值更新定值文件";
            this.toolStripMenuItemUpload.Click += new System.EventHandler(this.toolStripMenuItemUpload_Click);
            // 
            // gridViewCommonParam
            // 
            this.gridViewCommonParam.ColumnPanelRowHeight = 28;
            this.gridViewCommonParam.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumnValue,
            this.gridColumnRefValue});
            this.gridViewCommonParam.GridControl = this.gridControlCommonParam;
            this.gridViewCommonParam.GroupCount = 1;
            this.gridViewCommonParam.GroupFormat = "[#image]{1} {2}";
            this.gridViewCommonParam.GroupRowHeight = 28;
            this.gridViewCommonParam.Name = "gridViewCommonParam";
            this.gridViewCommonParam.OptionsCustomization.AllowFilter = false;
            this.gridViewCommonParam.OptionsCustomization.AllowSort = false;
            this.gridViewCommonParam.OptionsMenu.EnableColumnMenu = false;
            this.gridViewCommonParam.OptionsMenu.EnableFooterMenu = false;
            this.gridViewCommonParam.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewCommonParam.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridViewCommonParam.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridViewCommonParam.OptionsView.ColumnAutoWidth = false;
            this.gridViewCommonParam.OptionsView.ShowGroupPanel = false;
            this.gridViewCommonParam.RowHeight = 24;
            this.gridViewCommonParam.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewCommonParam.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridViewCommonParam_CustomDrawCell);
            this.gridViewCommonParam.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridViewCommonParam_CustomDrawGroupRow);
            this.gridViewCommonParam.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridViewCommonParam_CustomRowCellEditForEditing);
            this.gridViewCommonParam.GroupRowExpanding += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridViewCommonParam_GroupRowExpanding);
            this.gridViewCommonParam.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewCommonParam_CellValueChanged);
            this.gridViewCommonParam.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridViewCommonParam_ValidatingEditor);
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "Message_Name";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Width = 200;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.BackColor = System.Drawing.Color.Azure;
            this.gridColumn5.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn5.Caption = "定值名称";
            this.gridColumn5.FieldName = "Desc";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 200;
            // 
            // gridColumnValue
            // 
            this.gridColumnValue.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumnValue.AppearanceCell.Options.UseBackColor = true;
            this.gridColumnValue.Caption = "当前值";
            this.gridColumnValue.FieldName = "Value";
            this.gridColumnValue.Name = "gridColumnValue";
            this.gridColumnValue.OptionsColumn.AllowMove = false;
            this.gridColumnValue.Visible = true;
            this.gridColumnValue.VisibleIndex = 1;
            this.gridColumnValue.Width = 200;
            // 
            // gridColumnRefValue
            // 
            this.gridColumnRefValue.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumnRefValue.AppearanceCell.Options.UseBackColor = true;
            this.gridColumnRefValue.Caption = "参考值";
            this.gridColumnRefValue.FieldName = "RefValue";
            this.gridColumnRefValue.Name = "gridColumnRefValue";
            this.gridColumnRefValue.OptionsColumn.AllowEdit = false;
            this.gridColumnRefValue.OptionsColumn.AllowMove = false;
            this.gridColumnRefValue.OptionsColumn.ReadOnly = true;
            this.gridColumnRefValue.Visible = true;
            this.gridColumnRefValue.VisibleIndex = 2;
            this.gridColumnRefValue.Width = 200;
            // 
            // repositoryItemSpinEdit
            // 
            this.repositoryItemSpinEdit.AutoHeight = false;
            this.repositoryItemSpinEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit.Name = "repositoryItemSpinEdit";
            // 
            // repositoryItemComboBox
            // 
            this.repositoryItemComboBox.AutoHeight = false;
            this.repositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox.Name = "repositoryItemComboBox";
            this.repositoryItemComboBox.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemCheckEdit
            // 
            this.repositoryItemCheckEdit.AutoHeight = false;
            this.repositoryItemCheckEdit.Name = "repositoryItemCheckEdit";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonSearch);
            this.panel3.Controls.Add(this.textBoxKeyword);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(797, 45);
            this.panel3.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.AutoSize = true;
            this.buttonSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSearch.Image = global::IEDSToolkit.Properties.Resources.Search;
            this.buttonSearch.Location = new System.Drawing.Point(301, 7);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(30, 30);
            this.buttonSearch.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buttonSearch, "搜索定值");
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(9, 11);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(285, 23);
            this.textBoxKeyword.TabIndex = 0;
            this.textBoxKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxKeyword_KeyPress);
            // 
            // tabPageAdvancedParam
            // 
            this.tabPageAdvancedParam.Controls.Add(this.gridControlAdvancedParam);
            this.tabPageAdvancedParam.Location = new System.Drawing.Point(4, 36);
            this.tabPageAdvancedParam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageAdvancedParam.Name = "tabPageAdvancedParam";
            this.tabPageAdvancedParam.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageAdvancedParam.Size = new System.Drawing.Size(803, 406);
            this.tabPageAdvancedParam.TabIndex = 2;
            this.tabPageAdvancedParam.Text = "工程定值";
            this.tabPageAdvancedParam.UseVisualStyleBackColor = true;
            // 
            // gridControlAdvancedParam
            // 
            this.gridControlAdvancedParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlAdvancedParam.Location = new System.Drawing.Point(3, 4);
            this.gridControlAdvancedParam.MainView = this.gridViewAdvancedParam;
            this.gridControlAdvancedParam.Name = "gridControlAdvancedParam";
            this.gridControlAdvancedParam.Size = new System.Drawing.Size(797, 398);
            this.gridControlAdvancedParam.TabIndex = 3;
            this.gridControlAdvancedParam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAdvancedParam});
            // 
            // gridViewAdvancedParam
            // 
            this.gridViewAdvancedParam.ColumnPanelRowHeight = 28;
            this.gridViewAdvancedParam.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridViewAdvancedParam.GridControl = this.gridControlAdvancedParam;
            this.gridViewAdvancedParam.GroupCount = 1;
            this.gridViewAdvancedParam.GroupFormat = "[#image]{1} {2}";
            this.gridViewAdvancedParam.GroupRowHeight = 28;
            this.gridViewAdvancedParam.Name = "gridViewAdvancedParam";
            this.gridViewAdvancedParam.OptionsCustomization.AllowFilter = false;
            this.gridViewAdvancedParam.OptionsCustomization.AllowSort = false;
            this.gridViewAdvancedParam.OptionsMenu.EnableColumnMenu = false;
            this.gridViewAdvancedParam.OptionsMenu.EnableFooterMenu = false;
            this.gridViewAdvancedParam.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewAdvancedParam.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridViewAdvancedParam.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridViewAdvancedParam.OptionsView.ColumnAutoWidth = false;
            this.gridViewAdvancedParam.OptionsView.ShowGroupPanel = false;
            this.gridViewAdvancedParam.RowHeight = 24;
            this.gridViewAdvancedParam.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn7, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewAdvancedParam.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridViewCommonParam_CustomDrawGroupRow);
            // 
            // gridColumn7
            // 
            this.gridColumn7.FieldName = "Message_Name";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 200;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.BackColor = System.Drawing.Color.Azure;
            this.gridColumn8.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn8.Caption = "定值名称";
            this.gridColumn8.FieldName = "Desc";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 200;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn9.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn9.Caption = "整定值";
            this.gridColumn9.FieldName = "Value";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowMove = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 200;
            // 
            // tabPageMaintenance
            // 
            this.tabPageMaintenance.Controls.Add(this.gridControlMaintenance);
            this.tabPageMaintenance.Location = new System.Drawing.Point(4, 36);
            this.tabPageMaintenance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageMaintenance.Name = "tabPageMaintenance";
            this.tabPageMaintenance.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageMaintenance.Size = new System.Drawing.Size(803, 406);
            this.tabPageMaintenance.TabIndex = 3;
            this.tabPageMaintenance.Text = "维护信息";
            this.tabPageMaintenance.UseVisualStyleBackColor = true;
            // 
            // gridControlMaintenance
            // 
            this.gridControlMaintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMaintenance.Location = new System.Drawing.Point(3, 4);
            this.gridControlMaintenance.MainView = this.gridViewMaintenance;
            this.gridControlMaintenance.Name = "gridControlMaintenance";
            this.gridControlMaintenance.Size = new System.Drawing.Size(797, 398);
            this.gridControlMaintenance.TabIndex = 4;
            this.gridControlMaintenance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaintenance});
            // 
            // gridViewMaintenance
            // 
            this.gridViewMaintenance.ColumnPanelRowHeight = 28;
            this.gridViewMaintenance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gridViewMaintenance.GridControl = this.gridControlMaintenance;
            this.gridViewMaintenance.GroupCount = 1;
            this.gridViewMaintenance.GroupFormat = "[#image]{1} {2}";
            this.gridViewMaintenance.GroupRowHeight = 28;
            this.gridViewMaintenance.Name = "gridViewMaintenance";
            this.gridViewMaintenance.OptionsCustomization.AllowFilter = false;
            this.gridViewMaintenance.OptionsCustomization.AllowSort = false;
            this.gridViewMaintenance.OptionsMenu.EnableColumnMenu = false;
            this.gridViewMaintenance.OptionsMenu.EnableFooterMenu = false;
            this.gridViewMaintenance.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewMaintenance.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridViewMaintenance.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridViewMaintenance.OptionsView.ColumnAutoWidth = false;
            this.gridViewMaintenance.OptionsView.ShowGroupPanel = false;
            this.gridViewMaintenance.RowHeight = 24;
            this.gridViewMaintenance.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewMaintenance.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridViewCommonParam_CustomDrawGroupRow);
            // 
            // gridColumn10
            // 
            this.gridColumn10.FieldName = "Message_Name";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowMove = false;
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 200;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.BackColor = System.Drawing.Color.Azure;
            this.gridColumn11.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn11.Caption = "指标名称";
            this.gridColumn11.FieldName = "Desc";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowMove = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 200;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn12.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn12.Caption = "指标值";
            this.gridColumn12.FieldName = "Value";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowMove = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            this.gridColumn12.Width = 200;
            // 
            // tabPageEvents
            // 
            this.tabPageEvents.Controls.Add(this.tabControlEvents);
            this.tabPageEvents.Location = new System.Drawing.Point(4, 36);
            this.tabPageEvents.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageEvents.Name = "tabPageEvents";
            this.tabPageEvents.Padding = new System.Windows.Forms.Padding(8);
            this.tabPageEvents.Size = new System.Drawing.Size(803, 406);
            this.tabPageEvents.TabIndex = 4;
            this.tabPageEvents.Text = "事件记录";
            this.tabPageEvents.UseVisualStyleBackColor = true;
            // 
            // tabControlEvents
            // 
            this.tabControlEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEvents.ItemSize = new System.Drawing.Size(108, 25);
            this.tabControlEvents.Location = new System.Drawing.Point(8, 8);
            this.tabControlEvents.Name = "tabControlEvents";
            this.tabControlEvents.SelectedIndex = 0;
            this.tabControlEvents.Size = new System.Drawing.Size(787, 390);
            this.tabControlEvents.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlEvents.TabIndex = 0;
            // 
            // tabPageOscillo
            // 
            this.tabPageOscillo.Controls.Add(this.chart);
            this.tabPageOscillo.Controls.Add(this.listViewFile);
            this.tabPageOscillo.Controls.Add(this.panel2);
            this.tabPageOscillo.Location = new System.Drawing.Point(4, 36);
            this.tabPageOscillo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageOscillo.Name = "tabPageOscillo";
            this.tabPageOscillo.Padding = new System.Windows.Forms.Padding(8);
            this.tabPageOscillo.Size = new System.Drawing.Size(803, 406);
            this.tabPageOscillo.TabIndex = 5;
            this.tabPageOscillo.Text = "录波文件";
            this.tabPageOscillo.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            this.chart.Location = new System.Drawing.Point(8, 72);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(478, 362);
            this.chart.TabIndex = 3;
            this.chart.Text = "chart1";
            title1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            title1.Name = "TitleFile";
            title1.Text = "故障录波0";
            title1.Visible = false;
            title2.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            title2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "TitleParam";
            title2.Text = "记录时间";
            title2.Visible = false;
            this.chart.Titles.Add(title1);
            this.chart.Titles.Add(title2);
            // 
            // listViewFile
            // 
            this.listViewFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewFile.FullRowSelect = true;
            this.listViewFile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewFile.Location = new System.Drawing.Point(8, 50);
            this.listViewFile.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Scrollable = false;
            this.listViewFile.Size = new System.Drawing.Size(787, 100);
            this.listViewFile.TabIndex = 2;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 200;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.textBoxOscilloFile);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.buttonOpen);
            this.panel2.Controls.Add(this.buttonRead);
            this.panel2.Controls.Add(this.comboBoxFileType);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 42);
            this.panel2.TabIndex = 4;
            // 
            // textBoxOscilloFile
            // 
            this.textBoxOscilloFile.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxOscilloFile.Location = new System.Drawing.Point(438, 10);
            this.textBoxOscilloFile.Name = "textBoxOscilloFile";
            this.textBoxOscilloFile.ReadOnly = true;
            this.textBoxOscilloFile.Size = new System.Drawing.Size(225, 23);
            this.textBoxOscilloFile.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "已加载录波文件：";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(669, 9);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(87, 23);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "打开";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(215, 10);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(87, 23);
            this.buttonRead.TabIndex = 2;
            this.buttonRead.Text = "读取";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // comboBoxFileType
            // 
            this.comboBoxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileType.FormattingEnabled = true;
            this.comboBoxFileType.Items.AddRange(new object[] {
            "故障录波0",
            "故障录波1",
            "起动录波"});
            this.comboBoxFileType.Location = new System.Drawing.Point(88, 9);
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.Size = new System.Drawing.Size(121, 25);
            this.comboBoxFileType.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "录波文件：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonToFile);
            this.panel1.Controls.Add(this.buttonToDevice);
            this.panel1.Controls.Add(this.textBoxParamFile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxConnectState);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonRefreshAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 53);
            this.panel1.TabIndex = 4;
            // 
            // buttonToFile
            // 
            this.buttonToFile.AutoSize = true;
            this.buttonToFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonToFile.BackColor = System.Drawing.Color.Transparent;
            this.buttonToFile.Enabled = false;
            this.buttonToFile.Image = global::IEDSToolkit.Properties.Resources.upload_31_466666666667px_1122580_easyicon_net;
            this.buttonToFile.Location = new System.Drawing.Point(716, 8);
            this.buttonToFile.Name = "buttonToFile";
            this.buttonToFile.Size = new System.Drawing.Size(37, 38);
            this.buttonToFile.TabIndex = 9;
            this.toolTip1.SetToolTip(this.buttonToFile, "设备当前值更新定值文件");
            this.buttonToFile.UseVisualStyleBackColor = false;
            this.buttonToFile.Click += new System.EventHandler(this.buttonToFile_Click);
            // 
            // buttonToDevice
            // 
            this.buttonToDevice.AutoSize = true;
            this.buttonToDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonToDevice.BackColor = System.Drawing.Color.Transparent;
            this.buttonToDevice.Enabled = false;
            this.buttonToDevice.Image = global::IEDSToolkit.Properties.Resources.download_31_466666666667px_1122612_easyicon_net;
            this.buttonToDevice.Location = new System.Drawing.Point(673, 8);
            this.buttonToDevice.Name = "buttonToDevice";
            this.buttonToDevice.Size = new System.Drawing.Size(37, 38);
            this.buttonToDevice.TabIndex = 8;
            this.toolTip1.SetToolTip(this.buttonToDevice, "定值文件参考值整定到设备");
            this.buttonToDevice.UseVisualStyleBackColor = false;
            this.buttonToDevice.Click += new System.EventHandler(this.buttonToDevice_Click);
            // 
            // textBoxParamFile
            // 
            this.textBoxParamFile.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxParamFile.Location = new System.Drawing.Point(284, 16);
            this.textBoxParamFile.Name = "textBoxParamFile";
            this.textBoxParamFile.ReadOnly = true;
            this.textBoxParamFile.Size = new System.Drawing.Size(383, 23);
            this.textBoxParamFile.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "定值文件：";
            // 
            // textBoxConnectState
            // 
            this.textBoxConnectState.BackColor = System.Drawing.Color.Red;
            this.textBoxConnectState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxConnectState.ForeColor = System.Drawing.Color.White;
            this.textBoxConnectState.Location = new System.Drawing.Point(87, 19);
            this.textBoxConnectState.Name = "textBoxConnectState";
            this.textBoxConnectState.ReadOnly = true;
            this.textBoxConnectState.Size = new System.Drawing.Size(84, 16);
            this.textBoxConnectState.TabIndex = 1;
            this.textBoxConnectState.Text = "未连接";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "连接状态：";
            // 
            // buttonRefreshAll
            // 
            this.buttonRefreshAll.BackColor = System.Drawing.Color.Aqua;
            this.buttonRefreshAll.Location = new System.Drawing.Point(177, 16);
            this.buttonRefreshAll.Name = "buttonRefreshAll";
            this.buttonRefreshAll.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshAll.TabIndex = 7;
            this.buttonRefreshAll.Text = "刷新所有";
            this.buttonRefreshAll.UseVisualStyleBackColor = false;
            this.buttonRefreshAll.Visible = false;
            this.buttonRefreshAll.Click += new System.EventHandler(this.buttonRefreshAll_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Silver";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 1000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.Filter = "定值文件|*.xml";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.Filter = "定值文件|*.xml";
            // 
            // panelProgress
            // 
            this.panelProgress.BackColor = System.Drawing.Color.Azure;
            this.panelProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProgress.Controls.Add(this.progressBar);
            this.panelProgress.Controls.Add(this.labelInfo);
            this.panelProgress.Location = new System.Drawing.Point(4, 327);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(387, 65);
            this.panelProgress.TabIndex = 5;
            this.panelProgress.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 31);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(358, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(11, 11);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(161, 17);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "正在读取设备定值，请稍候...";
            // 
            // timerDock
            // 
            this.timerDock.Enabled = true;
            this.timerDock.Tick += new System.EventHandler(this.timerDock_Tick);
            // 
            // IEDCommForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 515);
            this.Controls.Add(this.panelProgress);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IEDCommForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowInTaskbar = false;
            this.TabText = "IEDCommForm";
            this.Text = "IEDCommForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IEDCommForm_FormClosing);
            this.Load += new System.EventHandler(this.IEDCommForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageCommonParam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCommonParam)).EndInit();
            this.contextMenuStripGridControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCommonParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPageAdvancedParam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdvancedParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdvancedParam)).EndInit();
            this.tabPageMaintenance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaintenance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaintenance)).EndInit();
            this.tabPageEvents.ResumeLayout(false);
            this.tabPageOscillo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemParamMng;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemNewFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLoadFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemWizard;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCheck;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPackage;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCommonParam;
        private DevExpress.XtraGrid.GridControl gridControlCommonParam;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCommonParam;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnValue;
        private System.Windows.Forms.TabPage tabPageAdvancedParam;
        private DevExpress.XtraGrid.GridControl gridControlAdvancedParam;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAdvancedParam;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.TabPage tabPageMaintenance;
        private DevExpress.XtraGrid.GridControl gridControlMaintenance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMaintenance;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.TabPage tabPageEvents;
        private System.Windows.Forms.TabControl tabControlEvents;
        private System.Windows.Forms.TabPage tabPageOscillo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxConnectState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxParamFile;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRefValue;
        private System.Windows.Forms.Button buttonRefreshAll;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGridControl;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDownload;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUpload;
        private System.Windows.Forms.Button buttonToDevice;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonToFile;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxOscilloFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.ComboBox comboBoxFileType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerDock;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxKeyword;
    }
}