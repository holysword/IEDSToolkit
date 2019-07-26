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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 25);
            this.gridControl.MainView = this.gridViewMain;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit,
            this.repositoryItemComboBox,
            this.repositoryItemCheckEdit});
            this.gridControl.Size = new System.Drawing.Size(679, 492);
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
            this.gridViewMain.GroupRowHeight = 24;
            this.gridViewMain.Name = "gridViewMain";
            this.gridViewMain.OptionsCustomization.AllowFilter = false;
            this.gridViewMain.OptionsCustomization.AllowSort = false;
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
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(679, 25);
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
            this.ReloadToolStripMenuItem.Click += new System.EventHandler(this.还原所有更改ToolStripMenuItem_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Silver";
            // 
            // ParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 517);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ParameterForm";
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
    }
}