using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IEDSToolkit
{
    public partial class OscilloForm : WeifenLuo.WinFormsUI.Docking.DockContent, AnalyzeFormInterface
    {
        public String FileName;
        
        public OscilloForm()
        {
            InitializeComponent();
        }
        
        public void PrintContent()
        {            
            this.oscilloControl.PrintContent();
        }        
        
        private void OscilloForm_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();

            this.TabText = System.IO.Path.GetFileName(FileName);

            this.oscilloControl.LoadOscilloFile(FileName);

            this.ResumeLayout(false);
        }        

        private void timerDock_Tick(object sender, EventArgs e)
        {
            timerDock.Enabled = false;

            this.oscilloControl.DockChart();
        }        
    }
}
