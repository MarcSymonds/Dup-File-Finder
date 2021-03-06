﻿using Dup_File_Finder.Forms;
using Dup_File_Finder.Helpers;
using Dup_File_Finder.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Dup_File_Finder.forms {
   public partial class frmMain : Form {
      public frmMain() {
         InitializeComponent();
      }

      private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
         this.Close();
      }

      private void scanDirectoryToolStripMenuItem_Click(object sender, EventArgs e) {
         frmScan frm = new frmScan();
         frm.ShowDialog(this);
      }

      private void manageDuplicatesToolStripMenuItem_Click(object sender, EventArgs e) {
         ShowDuplicates();
      }

      private void ShowDuplicates() {
         DataTable dtDups;

         using (Database db = new Database()) {
            dtDups = db.GetDuplicateFiles();
         }

         tvwDuplicates.Nodes.Clear();

         long size = -1;
         string hash = "";
         TreeNode node = null;

         if (dtDups != null && dtDups.Rows.Count > 0) {
            foreach (DataRow drDup in dtDups.Rows) {
               if (drDup["hash"].ToString() != hash || (long)drDup["fileSize"] != size) {
                  hash = drDup["hash"].ToString();
                  size = (long)drDup["fileSize"];

                  node = tvwDuplicates.Nodes.Add(drDup["id"].ToString(), drDup["filePath"].ToString());
                  node.Tag = drDup;
               }
               else {
                  TreeNode subNode = node.Nodes.Add(drDup["id"].ToString(), drDup["filePath"].ToString());
                  subNode.Tag = drDup;
               }
            }
         }
      }

      private void tvwDuplicates_AfterSelect(object sender, TreeViewEventArgs e) {
         FileViewer fv;
         Control[] fileViewers = pnlImages.Controls.Find("ucFile", false);
         int ipIdx = 0;

         if (e.Node != null) {
            List<TreeNode> nodes = new List<TreeNode>();

            TreeNode pNode = e.Node;
            if (pNode.Parent != null) {
               pNode = pNode.Parent;
            }

            nodes.Add(pNode);

            if (pNode.Nodes != null) {
               foreach (TreeNode n in pNode.Nodes) {
                  nodes.Add(n);
               }
            }

            foreach (TreeNode n in nodes) {
               if (ipIdx >= fileViewers.Length) {
                  fv = new FileViewer() { 
                     Name = "ucFile" , 
                     Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right, 
                     Width = pnlImages.Width, 
                     Left = 0
                  };

                  fv.DeleteFile += Fv_DeleteFile;

                  pnlImages.Controls.Add(fv);

                  ++ipIdx;
               }
               else {
                  fv = (FileViewer)fileViewers[ipIdx++];
               }

               fv.Set((DataRow)n.Tag);
               fv.Visible = true;
            }

            DoResize();
         }

            while (ipIdx < fileViewers.Length) {
               fv = (FileViewer)fileViewers[ipIdx++];
               fv.ClearImage();
               fv.Visible = false;
            }
      }

      private void Fv_DeleteFile(object sender, FileViewerEventArgs e) {
         TreeNode[] nodes = tvwDuplicates.Nodes.Find(((FileViewer)sender).Tag.ToString(), true);

         if (nodes.Length > 0) {
            TreeNode node = nodes[0];
            if (File.Exists(e.FilePath)) {
               ((FileViewer)sender).ClearImage();

               File.Delete(e.FilePath);
            }

            using(Database db = new Database()) {
               db.RemoveFile(e.FilePath);
            }

            if (node.Parent == null) {
               if (node.Nodes.Count > 1) {

               }
               else {
                  node.Remove();

                  tvwDuplicates_AfterSelect(tvwDuplicates, new TreeViewEventArgs(tvwDuplicates.SelectedNode));
               }
            }
            else {
               TreeNode parent = node.Parent;

               if (parent.Nodes.Count > 1) {
                  node.Remove();
               }
               else {
                  parent.Remove();
               }

               tvwDuplicates_AfterSelect(tvwDuplicates, new TreeViewEventArgs(tvwDuplicates.SelectedNode));
            }
         }
      }

      private void DeleteButton_Click(object sender, EventArgs e) {
         Button btn = (Button)sender;

         if (btn.Tag != null && Int32.TryParse(btn.Tag.ToString(), out _)) {
            TreeNode[] nodes = tvwDuplicates.Nodes.Find(btn.Tag.ToString(), true);

            if (nodes.Length > 0) {
               TreeNode node = nodes[0];

               if (MessageBox.Show(this, "Delete the file " + node.Text + "?", "Delete File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                  try {
                     RemoveFileFromTree(node.Tag.ToString());

                     Thread.Sleep(250);

                     if (File.Exists(node.Text)) {
                        File.Delete(node.Text);
                     }

                     using (Database db = new Database()) {
                        db.RemoveFile(node.Text);
                     }

                     if (node.Parent == null) {
                        if (node.GetNodeCount(false) == 0) {
                           node.Remove();
                        }
                        else {
                           //RemoveFileFromTree(node.Tag.ToString());

                           node.Tag = node.Nodes[0].Tag;
                           node.Text = node.Nodes[0].Text;
                           node.Name = node.Nodes[0].Name;

                           node.Nodes[0].Remove();
                        }
                     }
                     else {
                        TreeNode pNode = node.Parent;

                        //RemoveFileFromTree(node.Tag.ToString());
                        node.Remove();

                        if (pNode.GetNodeCount(false) == 0) {
                           RemoveFileFromTree(pNode.Tag.ToString());
                           pNode.Remove();
                        }
                     }

                  }
                  catch (Exception ex) {
                     MessageBox.Show(this, "Error deleting file " + node.Text + "\r\n\r\n" + ex.Message, "Error Deleting File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }


                  DoResize();
               }
            }

         }
      }

      private void RemoveFileFromTree(string tag) {
         Control[] imagePanels = pnlImages.Controls.Find("ucFile", false);

         foreach (Control ipc in imagePanels) {
            Panel ip = (Panel)ipc;

            if (ip.Tag.ToString() == tag) {
               PictureBox pb = (PictureBox)(ip.Controls.Find("pbImage", false)[0]);

               if (pb.Image != null) {
                  pb.Image.Dispose();
                  pb.Image = null;
               }

               ip.Visible = false;
            }
         }
      }

      private void button1_Click(object sender, EventArgs e) {

      }

System.Windows.Forms.Timer resizeTimer = null;
      private void pnlImages_Resize(object sender, EventArgs e) {
         if (resizeTimer != null) {
            resizeTimer.Stop();
         }
         else {
            resizeTimer = new System.Windows.Forms.Timer() { Interval = 250 };
            resizeTimer.Tick += ResizeTimer_Tick;
         }

         resizeTimer.Start();
      }

      private void ResizeTimer_Tick(object sender, EventArgs e) {
         resizeTimer.Stop();
         DoResize();
      }

      private void DoResize() {
         Control[] fileViewers = pnlImages.Controls.Find("ucFile", false);

         int top = -pnlImages.VerticalScroll.Value;

         foreach (Control ucf in fileViewers) {
            FileViewer fv = (FileViewer)ucf;

            fv.Top = top;

            fv.SizeContent();

            top += fv.Height + 10;
         }

      }
   }
}
