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
    public partial class CreatePackageForm : Form
    {
        public CreatePackageForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (checkedListBoxType.SelectedItems.Count == 0)
            {
                MessageBox.Show("请至少选择一种数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
