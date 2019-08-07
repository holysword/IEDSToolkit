namespace IEDSToolkit
{
    partial class ParameterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterForm));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCreateTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIEDType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Location = new System.Drawing.Point(9, 104);
            this.gridControl.MainView = this.gridViewMain;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit,
            this.repositoryItemComboBox,
            this.repositoryItemCheckEdit});
            this.gridControl.Size = new System.Drawing.Size(866, 226);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMain});
            // 
            // gridViewMain
            // 
            this.gridViewMain.ColumnPanelRowHeight = 28;
            this.gridViewMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridViewMain.GridControl = this.gridControl;
            this.gridViewMain.GroupCount = 1;
            this.gridViewMain.GroupFormat = "[#image]{1} {2}";
            this.gridViewMain.GroupRowHeight = 28;
            this.gridViewMain.Name = "gridViewMain";
            this.gridViewMain.OptionsCustomization.AllowFilter = false;
            this.gridViewMain.OptionsCustomization.AllowSort = false;
            this.gridViewMain.OptionsMenu.EnableColumnMenu = false;
            this.gridViewMain.OptionsMenu.EnableFooterMenu = false;
            this.gridViewMain.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewMain.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridViewMain.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridViewMain.OptionsView.ColumnAutoWidth = false;
            this.gridViewMain.OptionsView.ShowGroupPanel = false;
            this.gridViewMain.RowHeight = 24;
            this.gridViewMain.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewMain.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewMain_CustomDrawRowIndicator);
            this.gridViewMain.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridViewMain_CustomDrawCell);
            this.gridViewMain.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridViewMain_CustomDrawGroupRow);
            this.gridViewMain.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridViewMain_CustomRowCellEditForEditing);
            this.gridViewMain.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewMain_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Message_Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 200;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.BackColor = System.Drawing.Color.Azure;
            this.gridColumn2.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn2.Caption = "定值名称";
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
            this.gridColumn3.Caption = "整定值";
            this.gridColumn3.ColumnEdit = this.repositoryItemSpinEdit;
            this.gridColumn3.FieldName = "Value";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 200;
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
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(9, 11);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(68, 27);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.ReloadToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.文件FToolStripMenuItem.Text = "编辑(&E)";
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.SaveToolStripMenuItem.Text = "保存(&S)";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // ReloadToolStripMenuItem
            // 
            this.ReloadToolStripMenuItem.Enabled = false;
            this.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem";
            this.ReloadToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ReloadToolStripMenuItem.Text = "还原所有更改";
            this.ReloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItem_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Silver";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxCreateTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxIEDType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(9, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 48);
            this.panel1.TabIndex = 2;
            // 
            // textBoxCreateTime
            // 
            this.textBoxCreateTime.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCreateTime.Location = new System.Drawing.Point(449, 16);
            this.textBoxCreateTime.Name = "textBoxCreateTime";
            this.textBoxCreateTime.ReadOnly = true;
            this.textBoxCreateTime.Size = new System.Drawing.Size(258, 23);
            this.textBoxCreateTime.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "更新时间：";
            // 
            // textBoxIEDType
            // 
            this.textBoxIEDType.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxIEDType.Location = new System.Drawing.Point(87, 16);
            this.textBoxIEDType.Name = "textBoxIEDType";
            this.textBoxIEDType.ReadOnly = true;
            this.textBoxIEDType.Size = new System.Drawing.Size(258, 23);
            this.textBoxIEDType.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "设备类型：";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.buttonSearch);
            this.panel3.Controls.Add(this.textBoxKeyword);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(9, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(866, 45);
            this.panel3.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.AutoSize = true;
            this.buttonSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSearch.Image = global::IEDSToolkit.Properties.Resources.Search;
            this.buttonSearch.Location = new System.Drawing.Point(307, 7);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(30, 30);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(16, 11);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(285, 23);
            this.textBoxKeyword.TabIndex = 0;
            this.textBoxKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxKeyword_KeyPress);
            // 
            // ParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 341);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ParameterForm";
            this.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.TabText = "定值文件";
            this.Text = "定值文件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParameterForm_FormClosing);
            this.Load += new System.EventHandler(this.ParameterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMain;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReloadToolStripMenuItem;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxCreateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIEDType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxKeyword;
    }
}