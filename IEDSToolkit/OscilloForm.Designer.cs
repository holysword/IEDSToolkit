namespace IEDSToolkit
{
    partial class OscilloForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OscilloForm));
            this.timerDock = new System.Windows.Forms.Timer(this.components);
            this.oscilloControl = new IEDSToolkit.OscilloControl();
            this.SuspendLayout();
            // 
            // timerDock
            // 
            this.timerDock.Enabled = true;
            this.timerDock.Tick += new System.EventHandler(this.timerDock_Tick);
            // 
            // oscilloControl
            // 
            this.oscilloControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oscilloControl.Location = new System.Drawing.Point(8, 8);
            this.oscilloControl.Name = "oscilloControl";
            this.oscilloControl.Size = new System.Drawing.Size(478, 462);
            this.oscilloControl.TabIndex = 0;
            // 
            // OscilloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(494, 478);
            this.Controls.Add(this.oscilloControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OscilloForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.TabText = "录波文件";
            this.Text = "录波文件";
            this.Load += new System.EventHandler(this.OscilloForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerDock;
        private OscilloControl oscilloControl;
    }
}