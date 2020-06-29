namespace Dup_File_Finder.forms {
   partial class frmMain {
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
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.scanDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.manageDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.splDuplicates = new System.Windows.Forms.SplitContainer();
         this.tvwDuplicates = new System.Windows.Forms.TreeView();
         this.pnlImages = new System.Windows.Forms.Panel();
         this.menuStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splDuplicates)).BeginInit();
         this.splDuplicates.Panel1.SuspendLayout();
         this.splDuplicates.Panel2.SuspendLayout();
         this.splDuplicates.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanDirectoryToolStripMenuItem,
            this.manageDuplicatesToolStripMenuItem,
            this.quitToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(1075, 24);
         this.menuStrip1.TabIndex = 0;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // scanDirectoryToolStripMenuItem
         // 
         this.scanDirectoryToolStripMenuItem.Name = "scanDirectoryToolStripMenuItem";
         this.scanDirectoryToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
         this.scanDirectoryToolStripMenuItem.Text = "Scan Directory";
         this.scanDirectoryToolStripMenuItem.Click += new System.EventHandler(this.scanDirectoryToolStripMenuItem_Click);
         // 
         // manageDuplicatesToolStripMenuItem
         // 
         this.manageDuplicatesToolStripMenuItem.Name = "manageDuplicatesToolStripMenuItem";
         this.manageDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
         this.manageDuplicatesToolStripMenuItem.Text = "Manage Duplicates";
         this.manageDuplicatesToolStripMenuItem.Click += new System.EventHandler(this.manageDuplicatesToolStripMenuItem_Click);
         // 
         // quitToolStripMenuItem
         // 
         this.quitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
         this.quitToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
         this.quitToolStripMenuItem.Text = "Quit";
         this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
         // 
         // splDuplicates
         // 
         this.splDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.splDuplicates.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this.splDuplicates.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.splDuplicates.Location = new System.Drawing.Point(0, 27);
         this.splDuplicates.Name = "splDuplicates";
         // 
         // splDuplicates.Panel1
         // 
         this.splDuplicates.Panel1.Controls.Add(this.tvwDuplicates);
         // 
         // splDuplicates.Panel2
         // 
         this.splDuplicates.Panel2.Controls.Add(this.pnlImages);
         this.splDuplicates.Size = new System.Drawing.Size(1075, 612);
         this.splDuplicates.SplitterDistance = 359;
         this.splDuplicates.TabIndex = 1;
         // 
         // tvwDuplicates
         // 
         this.tvwDuplicates.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.tvwDuplicates.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tvwDuplicates.HideSelection = false;
         this.tvwDuplicates.Location = new System.Drawing.Point(0, 0);
         this.tvwDuplicates.Name = "tvwDuplicates";
         this.tvwDuplicates.Size = new System.Drawing.Size(355, 608);
         this.tvwDuplicates.TabIndex = 0;
         this.tvwDuplicates.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDuplicates_AfterSelect);
         // 
         // pnlImages
         // 
         this.pnlImages.AutoScroll = true;
         this.pnlImages.BackColor = System.Drawing.SystemColors.ControlDarkDark;
         this.pnlImages.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlImages.Location = new System.Drawing.Point(0, 0);
         this.pnlImages.Name = "pnlImages";
         this.pnlImages.Padding = new System.Windows.Forms.Padding(5);
         this.pnlImages.Size = new System.Drawing.Size(708, 608);
         this.pnlImages.TabIndex = 0;
         this.pnlImages.Resize += new System.EventHandler(this.pnlImages_Resize);
         // 
         // frmMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1075, 642);
         this.Controls.Add(this.splDuplicates);
         this.Controls.Add(this.menuStrip1);
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "frmMain";
         this.Text = "Duplicate File Finder";
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.splDuplicates.Panel1.ResumeLayout(false);
         this.splDuplicates.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splDuplicates)).EndInit();
         this.splDuplicates.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem scanDirectoryToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem manageDuplicatesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
      private System.Windows.Forms.SplitContainer splDuplicates;
      private System.Windows.Forms.TreeView tvwDuplicates;
      private System.Windows.Forms.Panel pnlImages;
   }
}