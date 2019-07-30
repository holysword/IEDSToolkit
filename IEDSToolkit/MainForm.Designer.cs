namespace IEDSToolkit
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OscilloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogPackage = new System.Windows.Forms.OpenFileDialog();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.openFileDialogParam = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogOscillo = new System.Windows.Forms.OpenFileDialog();
            this.ST570ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ST570LToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.设备ToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStripMain.Size = new System.Drawing.Size(784, 27);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "主菜单";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ExitToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.Enabled = false;
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.PrintToolStripMenuItem.Text = "打印(P)";
            this.PrintToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.ExitToolStripMenuItem.Text = "退出(X)";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ParameterToolStripMenuItem,
            this.PackageToolStripMenuItem,
            this.OscilloToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.工具TToolStripMenuItem.Text = "查看(V)";
            // 
            // ParameterToolStripMenuItem
            // 
            this.ParameterToolStripMenuItem.Name = "ParameterToolStripMenuItem";
            this.ParameterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.ParameterToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.ParameterToolStripMenuItem.Text = "定值文件(&P)";
            this.ParameterToolStripMenuItem.Click += new System.EventHandler(this.ParameterToolStripMenuItem_Click);
            // 
            // PackageToolStripMenuItem
            // 
            this.PackageToolStripMenuItem.Name = "PackageToolStripMenuItem";
            this.PackageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.PackageToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.PackageToolStripMenuItem.Text = "打包文件(&C)";
            this.PackageToolStripMenuItem.Click += new System.EventHandler(this.PackageToolStripMenuItem_Click);
            // 
            // OscilloToolStripMenuItem
            // 
            this.OscilloToolStripMenuItem.Name = "OscilloToolStripMenuItem";
            this.OscilloToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.OscilloToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.OscilloToolStripMenuItem.Text = "录波文件(&O)";
            this.OscilloToolStripMenuItem.Click += new System.EventHandler(this.OscilloToolStripMenuItem_Click);
            // 
            // 设备ToolStripMenuItem
            // 
            this.设备ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ST570LToolStripMenuItem,
            this.ST570ToolStripMenuItem});
            this.设备ToolStripMenuItem.MergeIndex = 0;
            this.设备ToolStripMenuItem.Name = "设备ToolStripMenuItem";
            this.设备ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.设备ToolStripMenuItem.Text = "设备(&D)";
            // 
            // openFileDialogPackage
            // 
            this.openFileDialogPackage.DefaultExt = "dat";
            this.openFileDialogPackage.Filter = "打包数据文件|Exp_*.dat";
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.AllowEndUserDocking = false;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Location = new System.Drawing.Point(0, 27);
            this.dockPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.ShowDocumentIcon = true;
            this.dockPanel.Size = new System.Drawing.Size(784, 534);
            this.dockPanel.TabIndex = 2;
            // 
            // openFileDialogParam
            // 
            this.openFileDialogParam.DefaultExt = "xml";
            this.openFileDialogParam.Filter = "定值文件|*.xml";
            // 
            // openFileDialogOscillo
            // 
            this.openFileDialogOscillo.DefaultExt = "dat";
            this.openFileDialogOscillo.Filter = "录波文件|Osc_*.dat";
            // 
            // ST570ToolStripMenuItem
            // 
            this.ST570ToolStripMenuItem.Name = "ST570ToolStripMenuItem";
            this.ST570ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ST570ToolStripMenuItem.Text = "ST570";
            this.ST570ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemConnect_Click);
            // 
            // ST570LToolStripMenuItem
            // 
            this.ST570LToolStripMenuItem.Name = "ST570LToolStripMenuItem";
            this.ST570LToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ST570LToolStripMenuItem.Text = "ST570L";
            this.ST570LToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemConnect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智秀工具箱";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ParameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PackageToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogPackage;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialogParam;
        private System.Windows.Forms.ToolStripMenuItem OscilloToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogOscillo;
        private System.Windows.Forms.ToolStripMenuItem 设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ST570LToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ST570ToolStripMenuItem;
    }
}

