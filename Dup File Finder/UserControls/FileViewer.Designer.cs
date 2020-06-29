namespace Dup_File_Finder.UserControls {
   partial class FileViewer {
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.txtFileName = new System.Windows.Forms.TextBox();
         this.txtDateCreated = new System.Windows.Forms.TextBox();
         this.txtLastModified = new System.Windows.Forms.TextBox();
         this.txtSize = new System.Windows.Forms.TextBox();
         this.pbImage = new System.Windows.Forms.PictureBox();
         this.btnDelete = new System.Windows.Forms.Button();
         this.txtLastScanned = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(3, 10);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(86, 19);
         this.label1.TabIndex = 0;
         this.label1.Text = "File:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label2
         // 
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(3, 31);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(86, 18);
         this.label2.TabIndex = 1;
         this.label2.Text = "Created:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label3
         // 
         this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(3, 54);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(86, 19);
         this.label3.TabIndex = 2;
         this.label3.Text = "Last modified:";
         this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label4
         // 
         this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(26, 77);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(63, 18);
         this.label4.TabIndex = 3;
         this.label4.Text = "Size:";
         this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // txtFileName
         // 
         this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtFileName.BackColor = System.Drawing.SystemColors.Control;
         this.txtFileName.HideSelection = false;
         this.txtFileName.Location = new System.Drawing.Point(92, 9);
         this.txtFileName.Name = "txtFileName";
         this.txtFileName.ReadOnly = true;
         this.txtFileName.Size = new System.Drawing.Size(857, 20);
         this.txtFileName.TabIndex = 4;
         // 
         // txtDateCreated
         // 
         this.txtDateCreated.BackColor = System.Drawing.SystemColors.Control;
         this.txtDateCreated.HideSelection = false;
         this.txtDateCreated.Location = new System.Drawing.Point(92, 32);
         this.txtDateCreated.Name = "txtDateCreated";
         this.txtDateCreated.ReadOnly = true;
         this.txtDateCreated.Size = new System.Drawing.Size(111, 20);
         this.txtDateCreated.TabIndex = 5;
         this.txtDateCreated.Text = "01/01/2002 00:00:00";
         // 
         // txtLastModified
         // 
         this.txtLastModified.BackColor = System.Drawing.SystemColors.Control;
         this.txtLastModified.HideSelection = false;
         this.txtLastModified.Location = new System.Drawing.Point(92, 55);
         this.txtLastModified.Name = "txtLastModified";
         this.txtLastModified.ReadOnly = true;
         this.txtLastModified.Size = new System.Drawing.Size(111, 20);
         this.txtLastModified.TabIndex = 6;
         // 
         // txtSize
         // 
         this.txtSize.BackColor = System.Drawing.SystemColors.Control;
         this.txtSize.HideSelection = false;
         this.txtSize.Location = new System.Drawing.Point(92, 78);
         this.txtSize.Name = "txtSize";
         this.txtSize.ReadOnly = true;
         this.txtSize.Size = new System.Drawing.Size(100, 20);
         this.txtSize.TabIndex = 7;
         // 
         // pbImage
         // 
         this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.pbImage.Location = new System.Drawing.Point(92, 104);
         this.pbImage.Name = "pbImage";
         this.pbImage.Size = new System.Drawing.Size(857, 267);
         this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pbImage.TabIndex = 8;
         this.pbImage.TabStop = false;
         // 
         // btnDelete
         // 
         this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnDelete.Location = new System.Drawing.Point(852, 377);
         this.btnDelete.Name = "btnDelete";
         this.btnDelete.Size = new System.Drawing.Size(97, 23);
         this.btnDelete.TabIndex = 9;
         this.btnDelete.Text = "Delete this file";
         this.btnDelete.UseVisualStyleBackColor = true;
         this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
         // 
         // txtLastScanned
         // 
         this.txtLastScanned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.txtLastScanned.BackColor = System.Drawing.SystemColors.Control;
         this.txtLastScanned.HideSelection = false;
         this.txtLastScanned.Location = new System.Drawing.Point(838, 32);
         this.txtLastScanned.Name = "txtLastScanned";
         this.txtLastScanned.ReadOnly = true;
         this.txtLastScanned.Size = new System.Drawing.Size(111, 20);
         this.txtLastScanned.TabIndex = 10;
         this.txtLastScanned.Text = "01/01/2002 00:00:00";
         // 
         // label5
         // 
         this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(716, 34);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(119, 13);
         this.label5.TabIndex = 11;
         this.label5.Text = "Last scanned:";
         this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // FileViewer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.ButtonFace;
         this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.Controls.Add(this.label5);
         this.Controls.Add(this.txtLastScanned);
         this.Controls.Add(this.btnDelete);
         this.Controls.Add(this.pbImage);
         this.Controls.Add(this.txtSize);
         this.Controls.Add(this.txtLastModified);
         this.Controls.Add(this.txtDateCreated);
         this.Controls.Add(this.txtFileName);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Name = "FileViewer";
         this.Size = new System.Drawing.Size(963, 414);
         ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox txtFileName;
      private System.Windows.Forms.TextBox txtDateCreated;
      private System.Windows.Forms.TextBox txtLastModified;
      private System.Windows.Forms.TextBox txtSize;
      private System.Windows.Forms.PictureBox pbImage;
      private System.Windows.Forms.Button btnDelete;
      private System.Windows.Forms.TextBox txtLastScanned;
      private System.Windows.Forms.Label label5;
   }
}
