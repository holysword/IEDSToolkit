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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageForm));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageRealtime = new System.Windows.Forms.TabPage();
            this.listViewRealTime = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageCommonParam = new System.Windows.Forms.TabPage();
            this.listViewCommonParam = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageAdvancedParam = new System.Windows.Forms.TabPage();
            this.listViewAdvancedParam = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageMaintenance = new System.Windows.Forms.TabPage();
            this.listViewMaintenance = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageEvents = new System.Windows.Forms.TabPage();
            this.tabControlEvents = new System.Windows.Forms.TabControl();
            this.tabPageOscillo = new System.Windows.Forms.TabPage();
            this.tabControlOscillo = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCreateTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIEDType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerDock = new System.Windows.Forms.Timer(this.components);
            this.tabControlMain.SuspendLayout();
            this.tabPageRealtime.SuspendLayout();
            this.tabPageCommonParam.SuspendLayout();
            this.tabPageAdvancedParam.SuspendLayout();
            this.tabPageMaintenance.SuspendLayout();
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
            this.tabPageRealtime.Controls.Add(this.listViewRealTime);
            this.tabPageRealtime.Location = new System.Drawing.Point(4, 36);
            this.tabPageRealtime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageRealtime.Name = "tabPageRealtime";
            this.tabPageRealtime.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageRealtime.Size = new System.Drawing.Size(984, 618);
            this.tabPageRealtime.TabIndex = 0;
            this.tabPageRealtime.Text = "实时数据";
            this.tabPageRealtime.UseVisualStyleBackColor = true;
            // 
            // listViewRealTime
            // 
            this.listViewRealTime.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewRealTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRealTime.FullRowSelect = true;
            this.listViewRealTime.Location = new System.Drawing.Point(3, 4);
            this.listViewRealTime.MultiSelect = false;
            this.listViewRealTime.Name = "listViewRealTime";
            this.listViewRealTime.Size = new System.Drawing.Size(978, 610);
            this.listViewRealTime.TabIndex = 0;
            this.listViewRealTime.UseCompatibleStateImageBehavior = false;
            this.listViewRealTime.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "变量名称";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "变量值";
            this.columnHeader3.Width = 200;
            // 
            // tabPageCommonParam
            // 
            this.tabPageCommonParam.Controls.Add(this.listViewCommonParam);
            this.tabPageCommonParam.Location = new System.Drawing.Point(4, 36);
            this.tabPageCommonParam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageCommonParam.Name = "tabPageCommonParam";
            this.tabPageCommonParam.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageCommonParam.Size = new System.Drawing.Size(984, 618);
            this.tabPageCommonParam.TabIndex = 1;
            this.tabPageCommonParam.Text = "普通定值";
            this.tabPageCommonParam.UseVisualStyleBackColor = true;
            // 
            // listViewCommonParam
            // 
            this.listViewCommonParam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewCommonParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCommonParam.FullRowSelect = true;
            this.listViewCommonParam.Location = new System.Drawing.Point(3, 4);
            this.listViewCommonParam.MultiSelect = false;
            this.listViewCommonParam.Name = "listViewCommonParam";
            this.listViewCommonParam.Size = new System.Drawing.Size(978, 610);
            this.listViewCommonParam.TabIndex = 1;
            this.listViewCommonParam.UseCompatibleStateImageBehavior = false;
            this.listViewCommonParam.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "序号";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "定值名称";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "整定值";
            this.columnHeader6.Width = 200;
            // 
            // tabPageAdvancedParam
            // 
            this.tabPageAdvancedParam.Controls.Add(this.listViewAdvancedParam);
            this.tabPageAdvancedParam.Location = new System.Drawing.Point(4, 36);
            this.tabPageAdvancedParam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageAdvancedParam.Name = "tabPageAdvancedParam";
            this.tabPageAdvancedParam.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageAdvancedParam.Size = new System.Drawing.Size(984, 618);
            this.tabPageAdvancedParam.TabIndex = 2;
            this.tabPageAdvancedParam.Text = "工厂定值";
            this.tabPageAdvancedParam.UseVisualStyleBackColor = true;
            // 
            // listViewAdvancedParam
            // 
            this.listViewAdvancedParam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listViewAdvancedParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAdvancedParam.FullRowSelect = true;
            this.listViewAdvancedParam.Location = new System.Drawing.Point(3, 4);
            this.listViewAdvancedParam.MultiSelect = false;
            this.listViewAdvancedParam.Name = "listViewAdvancedParam";
            this.listViewAdvancedParam.Size = new System.Drawing.Size(978, 610);
            this.listViewAdvancedParam.TabIndex = 2;
            this.listViewAdvancedParam.UseCompatibleStateImageBehavior = false;
            this.listViewAdvancedParam.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "序号";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "定值名称";
            this.columnHeader8.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "整定值";
            this.columnHeader9.Width = 200;
            // 
            // tabPageMaintenance
            // 
            this.tabPageMaintenance.Controls.Add(this.listViewMaintenance);
            this.tabPageMaintenance.Location = new System.Drawing.Point(4, 36);
            this.tabPageMaintenance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageMaintenance.Name = "tabPageMaintenance";
            this.tabPageMaintenance.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageMaintenance.Size = new System.Drawing.Size(984, 618);
            this.tabPageMaintenance.TabIndex = 3;
            this.tabPageMaintenance.Text = "维护信息";
            this.tabPageMaintenance.UseVisualStyleBackColor = true;
            // 
            // listViewMaintenance
            // 
            this.listViewMaintenance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listViewMaintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMaintenance.FullRowSelect = true;
            this.listViewMaintenance.Location = new System.Drawing.Point(3, 4);
            this.listViewMaintenance.MultiSelect = false;
            this.listViewMaintenance.Name = "listViewMaintenance";
            this.listViewMaintenance.Size = new System.Drawing.Size(978, 610);
            this.listViewMaintenance.TabIndex = 2;
            this.listViewMaintenance.UseCompatibleStateImageBehavior = false;
            this.listViewMaintenance.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "序号";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "指标名称";
            this.columnHeader11.Width = 200;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "指标值";
            this.columnHeader12.Width = 200;
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
            this.textBoxCreateTime.Size = new System.Drawing.Size(315, 23);
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
            this.tabPageCommonParam.ResumeLayout(false);
            this.tabPageAdvancedParam.ResumeLayout(false);
            this.tabPageMaintenance.ResumeLayout(false);
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
        private System.Windows.Forms.ListView listViewRealTime;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listViewCommonParam;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView listViewAdvancedParam;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ListView listViewMaintenance;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.TabControl tabControlEvents;
        private System.Windows.Forms.TabControl tabControlOscillo;
        private System.Windows.Forms.Timer timerDock;
    }
}