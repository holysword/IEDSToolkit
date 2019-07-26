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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogParam.ShowDialog() == DialogResult.OK)
            {
                ParameterForm parameterForm = new ParameterForm();
                parameterForm.MdiParent = this;
                parameterForm.FileName = this.openFileDialogParam.FileName;
                parameterForm.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
            }
        }

        private void PackageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogPackage.ShowDialog() == DialogResult.OK)
            {
                PackageForm packageForm = new PackageForm();
                packageForm.MdiParent = this;
                packageForm.FileName = this.openFileDialogPackage.FileName;                
                packageForm.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);                
            }
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打印
            if (this.ActiveMdiChild == null)
                return;

            AnalyzeFormInterface AnalyzeForm = (AnalyzeFormInterface)this.ActiveMdiChild;
            AnalyzeForm.PrintContent();
        }

        private void OscilloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogOscillo.ShowDialog() == DialogResult.OK)
            {
                OscilloForm oscilloForm = new OscilloForm();
                oscilloForm.MdiParent = this;
                oscilloForm.FileName = this.openFileDialogOscillo.FileName;
                oscilloForm.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
            }
        }
    }
}
