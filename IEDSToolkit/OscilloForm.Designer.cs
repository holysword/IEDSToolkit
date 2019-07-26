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
            this.listViewFile = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerDock = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewFile
            // 
            this.listViewFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewFile.FullRowSelect = true;
            this.listViewFile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewFile.Location = new System.Drawing.Point(8, 8);
            this.listViewFile.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Scrollable = false;
            this.listViewFile.Size = new System.Drawing.Size(478, 100);
            this.listViewFile.TabIndex = 0;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 200;
            // 
            // chart
            // 
            this.chart.Location = new System.Drawing.Point(8, 108);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(478, 362);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart1";
            // 
            // timerDock
            // 
            this.timerDock.Enabled = true;
            this.timerDock.Tick += new System.EventHandler(this.timerDock_Tick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // OscilloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(494, 478);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.listViewFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OscilloForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.TabText = "录波文件";
            this.Text = "录波文件";
            this.Load += new System.EventHandler(this.OscilloForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Timer timerDock;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}