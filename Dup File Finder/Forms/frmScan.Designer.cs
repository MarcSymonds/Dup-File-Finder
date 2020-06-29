namespace Dup_File_Finder.Forms {
   partial class frmScan {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.panel1 = new System.Windows.Forms.Panel();
         this.btnStartScan = new System.Windows.Forms.Button();
         this.btnFindDirectory = new System.Windows.Forms.Button();
         this.cbbDirectory = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.fbdPickDirectory = new System.Windows.Forms.FolderBrowserDialog();
         this.panel2 = new System.Windows.Forms.Panel();
         this.txtScanLog = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.btnCancelScan = new System.Windows.Forms.Button();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panel1.Controls.Add(this.btnStartScan);
         this.panel1.Controls.Add(this.btnFindDirectory);
         this.panel1.Controls.Add(this.cbbDirectory);
         this.panel1.Controls.Add(this.label1);
         this.panel1.Location = new System.Drawing.Point(3, 2);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(876, 68);
         this.panel1.TabIndex = 0;
         // 
         // btnStartScan
         // 
         this.btnStartScan.Location = new System.Drawing.Point(105, 38);
         this.btnStartScan.Name = "btnStartScan";
         this.btnStartScan.Size = new System.Drawing.Size(75, 23);
         this.btnStartScan.TabIndex = 4;
         this.btnStartScan.Text = "Start Scan";
         this.btnStartScan.UseVisualStyleBackColor = true;
         this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
         // 
         // btnFindDirectory
         // 
         this.btnFindDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnFindDirectory.Location = new System.Drawing.Point(835, 8);
         this.btnFindDirectory.Name = "btnFindDirectory";
         this.btnFindDirectory.Size = new System.Drawing.Size(33, 23);
         this.btnFindDirectory.TabIndex = 3;
         this.btnFindDirectory.Text = "...";
         this.btnFindDirectory.UseVisualStyleBackColor = true;
         this.btnFindDirectory.Click += new System.EventHandler(this.btnFindDirectory_Click);
         // 
         // cbbDirectory
         // 
         this.cbbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cbbDirectory.Location = new System.Drawing.Point(105, 10);
         this.cbbDirectory.Name = "cbbDirectory";
         this.cbbDirectory.Size = new System.Drawing.Size(724, 21);
         this.cbbDirectory.TabIndex = 2;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(9, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(90, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Directory to scan:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // fbdPickDirectory
         // 
         this.fbdPickDirectory.ShowNewFolderButton = false;
         // 
         // panel2
         // 
         this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
         this.panel2.Location = new System.Drawing.Point(3, 69);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(876, 1);
         this.panel2.TabIndex = 1;
         // 
         // txtScanLog
         // 
         this.txtScanLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtScanLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.txtScanLog.Location = new System.Drawing.Point(16, 93);
         this.txtScanLog.Multiline = true;
         this.txtScanLog.Name = "txtScanLog";
         this.txtScanLog.ReadOnly = true;
         this.txtScanLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.txtScanLog.Size = new System.Drawing.Size(855, 299);
         this.txtScanLog.TabIndex = 2;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 77);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(78, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Scan progress:";
         // 
         // btnCancelScan
         // 
         this.btnCancelScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancelScan.Enabled = false;
         this.btnCancelScan.Location = new System.Drawing.Point(785, 398);
         this.btnCancelScan.Name = "btnCancelScan";
         this.btnCancelScan.Size = new System.Drawing.Size(86, 23);
         this.btnCancelScan.TabIndex = 4;
         this.btnCancelScan.Text = "Cancel Scan";
         this.btnCancelScan.UseVisualStyleBackColor = true;
         this.btnCancelScan.Click += new System.EventHandler(this.btnCancelScan_Click);
         // 
         // frmScan
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(883, 434);
         this.Controls.Add(this.btnCancelScan);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.txtScanLog);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.MinimumSize = new System.Drawing.Size(400, 200);
         this.Name = "frmScan";
         this.Text = "frmScan";
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox cbbDirectory;
      private System.Windows.Forms.Button btnStartScan;
      private System.Windows.Forms.Button btnFindDirectory;
      private System.Windows.Forms.FolderBrowserDialog fbdPickDirectory;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.TextBox txtScanLog;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button btnCancelScan;
   }
}