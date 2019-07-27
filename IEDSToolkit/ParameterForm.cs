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
using System.Xml;

namespace IEDSToolkit
{
    public partial class ParameterForm : WeifenLuo.WinFormsUI.Docking.DockContent, AnalyzeFormInterface
    {
        public String FileName;
        private DataSet paramFile;
        private DataSet iedFile = new DataSet();
        private DataTable deviceTable, messageTable, varTable;
        public ParameterForm()
        {
            InitializeComponent();
        }
        public void PrintContent()
        {
            //this.gridControl.ShowPrintPreview();
            DevGridReport devGridReport = new DevGridReport(this.gridControl
                , "定值文件 - [" + this.TabText + "]"
                , "设备类型：" + this.textBoxIEDType.Text + "\t更新时间：" + this.textBoxCreateTime.Text);
            devGridReport.Preview();
        }
        private void LoadParameterFile()
        {
            try
            {                
                paramFile = new DataSet();
                paramFile.ReadXml(FileName);
                deviceTable = paramFile.Tables["Device"];
                messageTable = paramFile.Tables["Message"];
                varTable = paramFile.Tables["Var"];

                if (deviceTable == null || messageTable == null || varTable == null)
                {
                    MessageBox.Show("定值文件加载错误！");
                    return;
                }                

                if (iedFile.Tables.Count == 0)
                {
                    String IEDType = deviceTable.Rows[0]["Name"].ToString();
                    iedFile.ReadXml(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\IED\\" + IEDType + ".xml");

                    this.textBoxIEDType.Text = IEDType;
                    this.textBoxCreateTime.Text = deviceTable.Rows[0]["UpdateTime"].ToString();
                }

                varTable.Columns.Add(new DataColumn("Message_Name", typeof(string)));
                varTable.Columns.Add(new DataColumn("Var_Desc", typeof(string)));
                varTable.Columns.Add(new DataColumn("Var_Obj", typeof(Object)));
                varTable.Columns.Add(new DataColumn("Tables", typeof(Object)));
                varTable.Columns.Add(new DataColumn("Modify", typeof(Boolean)));
                foreach (DataRow varRow in varTable.Rows)
                {
                    String messageIndex = messageTable.Rows[Convert.ToInt32(varRow["Message_Id"])]["Index"].ToString();
                    DataRow[] rows = iedFile.Tables["Message"].Select("Index = '" + messageIndex + "'");
                    if (rows.Length == 0)
                        continue;

                    varRow["Message_Name"] = (Convert.ToInt32(varRow["Message_Id"]) + 1).ToString("00") + ". " + rows[0]["Name"];

                    rows = iedFile.Tables["Var"].Select("Name = '" + varRow["Name"] + "'");
                    if (rows.Length == 0)
                        continue;

                    String unit = rows[0]["Unit"].ToString();
                    if (unit != "")
                        varRow["Var_Desc"] = rows[0]["Desc"] + " (" + unit + ")";
                    else
                        varRow["Var_Desc"] = rows[0]["Desc"];

                    varRow["Var_Obj"] = rows[0];
                }

                ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).BeginInit();
                this.SuspendLayout();

                this.gridControl.DataSource = varTable;

                ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).EndInit();
                this.ResumeLayout(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("定值文件加载错误！\n错误信息：" + ex.Message);
            }
        }

        private void ParameterForm_Load(object sender, EventArgs e)
        {
            this.TabText = System.IO.Path.GetFileName(FileName);

            LoadParameterFile();
        }

        private void SaveParameterFile()
        {
            deviceTable.Rows[0]["UpdateTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.textBoxCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            DataSet saveData = paramFile.Copy();
            saveData.Tables["Var"].Columns.Remove("Message_Name");
            saveData.Tables["Var"].Columns.Remove("Var_Desc");
            saveData.Tables["Var"].Columns.Remove("Var_Obj");
            saveData.Tables["Var"].Columns.Remove("Tables");
            saveData.Tables["Var"].Columns.Remove("Modify");         

            using (MemoryStream ms = new MemoryStream())
            {
                saveData.WriteXml(ms);
                ms.Position = 0;
                XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(ms);

                XmlNode root = doc.SelectSingleNode("NewDataSet");
                XmlNode device = root.SelectSingleNode("Device");
                doc.RemoveChild(root);

                XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                doc.AppendChild(declaration);

                doc.AppendChild(device);
                doc.Save(FileName);
            }

            foreach (DataRow var in varTable.Rows)
                var["Modify"] = false;

            SaveToolStripMenuItem.Enabled = false;
            ReloadToolStripMenuItem.Enabled = false;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveParameterFile();
        }

        private void gridViewMain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            //if (e.Info.IsRowIndicator && e.RowHandle >= 0 
            //    && varTable.Rows[e.RowHandle]["Modify"] != DBNull.Value 
            //    && Convert.ToBoolean(varTable.Rows[e.RowHandle]["Modify"]))
            //{
            //    e.Info.BackAppearance.BackColor = Color.Blue;
            //    e.Info.Appearance.BackColor = Color.Blue;
            //    e.Handled = true;
            //    e.Painter.DrawObject(e.Info);                
            //}
        }

        private void gridViewMain_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                varTable.Rows[e.RowHandle]["Modify"] = true;

                SaveToolStripMenuItem.Enabled = true;
                ReloadToolStripMenuItem.Enabled = true;
            }
        }

        private void gridViewMain_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Column.FieldName == "Value"
                && varTable.Rows[e.RowHandle]["Modify"] != DBNull.Value
                && Convert.ToBoolean(varTable.Rows[e.RowHandle]["Modify"]))
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void gridViewMain_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                return;

            int childCount = this.gridViewMain.GetChildRowCount(e.RowHandle);
            for (int i = 0; i < childCount; i++)
            {
                int childHandle = this.gridViewMain.GetChildRowHandle(e.RowHandle, i);
                if (varTable.Rows[childHandle]["Modify"] != DBNull.Value
                    && Convert.ToBoolean(varTable.Rows[childHandle]["Modify"]))
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;

                    break;
                }
            }
            
            if (Math.Abs(e.RowHandle) % 2 == 0 && e.Appearance.BackColor != Color.Red)
            {
                e.Appearance.BackColor = Color.WhiteSmoke;
            }            
        }

        private void ParameterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveToolStripMenuItem.Enabled)
            {
                DialogResult dr = MessageBox.Show("定值文件已被修改，关闭前是否保存？\n是：保存当前文件\n否：放弃修改不保存\n取消：不关闭"
                                                    , "询问", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    SaveParameterFile();
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void gridViewMain_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Column.FieldName == "Value")
            {
                //String varName = varTable.Rows[e.RowHandle]["Name"].ToString();
                DataRow varRow = (DataRow)varTable.Rows[e.RowHandle]["Var_Obj"];
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
                            rows = iedFile.Tables["T"].Select("Var_Id = '" + varRow["Var_Id"] + "'");

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

        private void 还原所有更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gridControl.DataSource = null;
            LoadParameterFile();

            SaveToolStripMenuItem.Enabled = false;
            ReloadToolStripMenuItem.Enabled = false;
        }
    }
}
