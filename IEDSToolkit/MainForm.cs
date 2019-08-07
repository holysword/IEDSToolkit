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

            Application.Idle += new EventHandler(UpdateMenuState);
        }

        public void UpdateMenuState(Object sender, EventArgs e)
        {
            this.PrintToolStripMenuItem.Enabled = this.ActiveMdiChild != null;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialogParam.FileName = "";
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
            this.openFileDialogPackage.FileName = "";
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
            this.openFileDialogOscillo.FileName = "";
            if (this.openFileDialogOscillo.ShowDialog() == DialogResult.OK)
            {
                OscilloForm oscilloForm = new OscilloForm();
                oscilloForm.MdiParent = this;
                oscilloForm.FileName = this.openFileDialogOscillo.FileName;
                oscilloForm.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
            }
        }

        
        private void ToolStripMenuItemConnect_Click(object sender, EventArgs e)
        {
            IEDCommForm iedCommForm = new IEDCommForm();
            iedCommForm.MdiParent = this;
            iedCommForm.IEDType = ((ToolStripMenuItem)sender).Text;
            iedCommForm.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);

            this.DeviceToolStripMenuItem.Visible = false;                        
        }

        private void dockPanel_ContentRemoved(object sender, WeifenLuo.WinFormsUI.Docking.DockContentEventArgs e)
        {
            if (e.Content.GetType().Name == "IEDCommForm")
                this.DeviceToolStripMenuItem.Visible = true;
        }
    }
}
