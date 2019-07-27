namespace IEDSToolkit
{
    partial class PackageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageForm));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageRealtime = new System.Windows.Forms.TabPage();
            this.gridControlRealTime = new DevExpress.XtraGrid.GridControl();
            this.gridViewRealTime = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageCommonParam = new System.Windows.Forms.TabPage();
            this.gridControlCommonParam = new DevExpress.XtraGrid.GridControl();
            this.gridViewCommonParam = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.tabControlOscillo = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCreateTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIEDType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerDock = new System.Windows.Forms.Timer();
            this.tabControlMain.SuspendLayout();
            this.tabPageRealtime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRealTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRealTime)).BeginInit();
            this.tabPageCommonParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCommonParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCommonParam)).BeginInit();
            this.tabPageAdvancedParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdvancedParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdvancedParam)).BeginInit();
            this.tabPageMaintenance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaintenance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaintenance)).BeginInit();
            this.tabPageEvents.SuspendLayout();
            this.tabPageOscillo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageRealtime);
            this.tabControlMain.Controls.Add(this.tabPageCommonParam);
            this.tabControlMain.Controls.Add(this.tabPageAdvancedParam);
            this.tabControlMain.Controls.Add(this.tabPageMaintenance);
            this.tabControlMain.Controls.Add(this.tabPageEvents);
            this.tabControlMain.Controls.Add(this.tabPageOscillo);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.HotTrack = true;
            this.tabControlMain.ItemSize = new System.Drawing.Size(80, 32);
            this.tabControlMain.Location = new System.Drawing.Point(8, 63);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(992, 658);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageRealtime
            // 
            this.tabPageRealtime.Controls.Add(this.gridControlRealTime);
            this.tabPageRealtime.Location = new System.Drawing.Point(4, 36);
            this.tabPageRealtime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageRealtime.Name = "tabPageRealtime";
            this.tabPageRealtime.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageRealtime.Size = new System.Drawing.Size(984, 618);
            this.tabPageRealtime.TabIndex = 0;
            this.tabPageRealtime.Text = "实时数据";
            this.tabPageRealtime.UseVisualStyleBackColor = true;
            // 
            // gridControlRealTime
            // 
            this.gridControlRealTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRealTime.Location = new System.Drawing.Point(3, 4);
            this.gridControlRealTime.MainView = this.gridViewRealTime;
            this.gridControlRealTime.Name = "gridControlRealTime";
            this.gridControlRealTime.Size = new System.Drawing.Size(978, 610);
            this.gridControlRealTime.TabIndex = 1;
            this.gridControlRealTime.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRealTime});
            // 
            // gridViewRealTime
            // 
            this.gridViewRealTime.ColumnPanelRowHeight = 28;
            this.gridViewRealTime.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridViewRealTime.GridControl = this.gridControlRealTime;
            this.gridViewRealTime.GroupCount = 1;
            this.gridViewRealTime.GroupFormat = "[#image]{1} {2}";
            this.gridViewRealTime.GroupRowHeight = 24;
            this.gridViewRealTime.Name = "gridViewRealTime";
            this.gridViewRealTime.OptionsCustomization.AllowFilter = false;
            this.gridViewRealTime.OptionsCustomization.AllowSort = false;
            this.gridViewRealTime.OptionsView.ColumnAutoWidth = false;
            this.gridViewRealTime.OptionsView.ShowGroupPanel = false;
            this.gridViewRealTime.RowHeight = 24;
            this.gridViewRealTime.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Message_Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 200;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.BackColor = System.Drawing.Color.Azure;
            this.gridColumn2.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn2.Caption = "变量名称";
            this.gridColumn2.FieldName = "Var_Desc";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 200;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn3.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn3.Caption = "变量值";
            this.gridColumn3.FieldName = "Var_Value";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 200;
            // 
            // tabPageCommonParam
            // 
            this.tabPageCommonParam.Controls.Add(this.gridControlCommonParam);
            this.tabPageCommonParam.Location = new System.Drawing.Point(4, 36);
            this.tabPageCommonParam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageCommonParam.Name = "tabPageCommonParam";
            this.tabPageCommonParam.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageCommonParam.Size = new System.Drawing.Size(984, 618);
            this.tabPageCommonParam.TabIndex = 1;
            this.tabPageCommonParam.Text = "普通定值";
            this.tabPageCommonParam.UseVisualStyleBackColor = true;
            // 
            // gridControlCommonParam
            // 
            this.gridControlCommonParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCommonParam.Location = new System.Drawing.Point(3, 4);
            this.gridControlCommonParam.MainView = this.gridViewCommonParam;
            this.gridControlCommonParam.Name = "gridControlCommonParam";
            this.gridControlCommonParam.Size = new System.Drawing.Size(978, 610);
            this.gridControlCommonParam.TabIndex = 2;
            this.gridControlCommonParam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCommonParam});
            // 
            // gridViewCommonParam
            // 
            this.gridViewCommonParam.ColumnPanelRowHeight = 28;
            this.gridViewCommonParam.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridViewCommonParam.GridControl = this.gridControlCommonParam;
            this.gridViewCommonParam.GroupCount = 1;
            this.gridViewCommonParam.GroupFormat = "[#image]{1} {2}";
            this.gridViewCommonParam.GroupRowHeight = 24;
            this.gridViewCommonParam.Name = "gridViewCommonParam";
            this.gridViewCommonParam.OptionsCustomization.AllowFilter = false;
            this.gridViewCommonParam.OptionsCustomization.AllowSort = false;
            this.gridViewCommonParam.OptionsView.ColumnAutoWidth = false;
            this.gridViewCommonParam.OptionsView.ShowGroupPanel = false;
            this.gridViewCommonParam.RowHeight = 24;
            this.gridViewCommonParam.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "Message_Name";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 200;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.BackColor = System.Drawing.Color.Azure;
            this.gridColumn5.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn5.Caption = "定值名称";
            this.gridColumn5.FieldName = "Var_Desc";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 200;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn6.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn6.Caption = "整定值";
            this.gridColumn6.FieldName = "Var_Value";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 200;
            // 
            // tabPageAdvancedParam
            // 
            this.tabPageAdvancedParam.Controls.Add(this.gridControlAdvancedParam);
            this.tabPageAdvancedParam.Location = new System.Drawing.Point(4, 36);
            this.tabPageAdvancedParam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageAdvancedParam.Name = "tabPageAdvancedParam";
            this.tabPageAdvancedParam.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageAdvancedParam.Size = new System.Drawing.Size(984, 618);
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
            this.gridControlAdvancedParam.Size = new System.Drawing.Size(978, 610);
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
            this.gridViewAdvancedParam.GroupRowHeight = 24;
            this.gridViewAdvancedParam.Name = "gridViewAdvancedParam";
            this.gridViewAdvancedParam.OptionsCustomization.AllowFilter = false;
            this.gridViewAdvancedParam.OptionsCustomization.AllowSort = false;
            this.gridViewAdvancedParam.OptionsView.ColumnAutoWidth = false;
            this.gridViewAdvancedParam.OptionsView.ShowGroupPanel = false;
            this.gridViewAdvancedParam.RowHeight = 24;
            this.gridViewAdvancedParam.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn7, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.gridColumn8.FieldName = "Var_Desc";
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
            this.gridColumn9.FieldName = "Var_Value";
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
            this.tabPageMaintenance.Size = new System.Drawing.Size(984, 618);
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
            this.gridControlMaintenance.Size = new System.Drawing.Size(978, 610);
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
            this.gridViewMaintenance.GroupRowHeight = 24;
            this.gridViewMaintenance.Name = "gridViewMaintenance";
            this.gridViewMaintenance.OptionsCustomization.AllowFilter = false;
            this.gridViewMaintenance.OptionsCustomization.AllowSort = false;
            this.gridViewMaintenance.OptionsView.ColumnAutoWidth = false;
            this.gridViewMaintenance.OptionsView.ShowGroupPanel = false;
            this.gridViewMaintenance.RowHeight = 24;
            this.gridViewMaintenance.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.gridColumn11.FieldName = "Var_Desc";
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
            this.gridColumn12.FieldName = "Var_Value";
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
            this.tabPageEvents.Size = new System.Drawing.Size(984, 618);
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
            this.tabControlEvents.Size = new System.Drawing.Size(968, 602);
            this.tabControlEvents.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlEvents.TabIndex = 0;
            // 
            // tabPageOscillo
            // 
            this.tabPageOscillo.Controls.Add(this.tabControlOscillo);
            this.tabPageOscillo.Location = new System.Drawing.Point(4, 36);
            this.tabPageOscillo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageOscillo.Name = "tabPageOscillo";
            this.tabPageOscillo.Padding = new System.Windows.Forms.Padding(8);
            this.tabPageOscillo.Size = new System.Drawing.Size(984, 618);
            this.tabPageOscillo.TabIndex = 5;
            this.tabPageOscillo.Text = "录波文件";
            this.tabPageOscillo.UseVisualStyleBackColor = true;
            // 
            // tabControlOscillo
            // 
            this.tabControlOscillo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOscillo.ItemSize = new System.Drawing.Size(108, 25);
            this.tabControlOscillo.Location = new System.Drawing.Point(8, 8);
            this.tabControlOscillo.Name = "tabControlOscillo";
            this.tabControlOscillo.SelectedIndex = 0;
            this.tabControlOscillo.Size = new System.Drawing.Size(968, 602);
            this.tabControlOscillo.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlOscillo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxCreateTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxIEDType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 55);
            this.panel1.TabIndex = 1;
            // 
            // textBoxCreateTime
            // 
            this.textBoxCreateTime.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCreateTime.Location = new System.Drawing.Point(444, 16);
            this.textBoxCreateTime.Name = "textBoxCreateTime";
            this.textBoxCreateTime.ReadOnly = true;
            this.textBoxCreateTime.Size = new System.Drawing.Size(258, 23);
            this.textBoxCreateTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "创建时间：";
            // 
            // textBoxIEDType
            // 
            this.textBoxIEDType.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxIEDType.Location = new System.Drawing.Point(87, 16);
            this.textBoxIEDType.Name = "textBoxIEDType";
            this.textBoxIEDType.ReadOnly = true;
            this.textBoxIEDType.Size = new System.Drawing.Size(258, 23);
            this.textBoxIEDType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备类型：";
            // 
            // timerDock
            // 
            this.timerDock.Enabled = true;
            this.timerDock.Tick += new System.EventHandler(this.timerDock_Tick);
            // 
            // PackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PackageForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowInTaskbar = false;
            this.TabText = "打包数据文件";
            this.Text = "打包数据文件";
            this.Load += new System.EventHandler(this.PackageForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageRealtime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRealTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRealTime)).EndInit();
            this.tabPageCommonParam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCommonParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCommonParam)).EndInit();
            this.tabPageAdvancedParam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdvancedParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdvancedParam)).EndInit();
            this.tabPageMaintenance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaintenance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaintenance)).EndInit();
            this.tabPageEvents.ResumeLayout(false);
            this.tabPageOscillo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageRealtime;
        private System.Windows.Forms.TabPage tabPageCommonParam;
        private System.Windows.Forms.TabPage tabPageAdvancedParam;
        private System.Windows.Forms.TabPage tabPageMaintenance;
        private System.Windows.Forms.TabPage tabPageEvents;
        private System.Windows.Forms.TabPage tabPageOscillo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxCreateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIEDType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlEvents;
        private System.Windows.Forms.TabControl tabControlOscillo;
        private System.Windows.Forms.Timer timerDock;
        private DevExpress.XtraGrid.GridControl gridControlRealTime;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRealTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.GridControl gridControlCommonParam;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCommonParam;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.GridControl gridControlAdvancedParam;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAdvancedParam;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.GridControl gridControlMaintenance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMaintenance;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}