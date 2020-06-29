using Dup_File_Finder.Helpers;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Dup_File_Finder.Forms {
   public partial class frmScan : Form {
      private Thread scanThread = null;
      private readonly ScanCompleteEventHandler onScanComplete = null;

      public frmScan() {
         InitializeComponent();

         onScanComplete = new ScanCompleteEventHandler(OnScanComplete);
      }

      protected override void OnLoad(EventArgs e) {
         base.OnLoad(e);

         using (Database db = new Database()) { 
            DataTable dtDirs = db.GetScanDirs();

            if (dtDirs != null && dtDirs.Rows.Count > 0) {
               foreach (DataRow drDir in dtDirs.Rows) {
                  cbbDirectory.Items.Add(drDir["dirPath"]);
               }
            }
         }
      }

      private void btnFindDirectory_Click(object sender, EventArgs e) {
         if ( fbdPickDirectory.ShowDialog(this) == DialogResult.OK) {
            cbbDirectory.Text = fbdPickDirectory.SelectedPath;
         }
      }

      private void btnStartScan_Click(object sender, EventArgs e) {
         string dir = cbbDirectory.Text.Trim();

         if (dir.Length == 0) {
            MessageBox.Show(this, "Please enter or select the directory to scan.", "Select Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
         else if (!Directory.Exists(dir)) {
            MessageBox.Show(this, "The specified directory could not be found.", "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
         else {
            cbbDirectory.Enabled = false;
            btnFindDirectory.Enabled = false;
            btnStartScan.Enabled = false;
            btnCancelScan.Enabled = true;

            try {
               txtScanLog.Clear();

               scanThread = new Thread(ScanDirectory);
               scanThread.Start(dir);
            }
            catch (Exception ex) {
               MessageBox.Show(this, "Error starting thread to scan directory: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               ResetControls();

               scanThread = null;
            }
            finally {

            }
         }
      }
      protected override void OnClosing(CancelEventArgs e) {
         base.OnClosing(e);

         if (scanThread != null) {
            scanThread.Abort();

            ResetControls();
         }
      }

      private void ResetControls() {
         cbbDirectory.Enabled = true;
         btnFindDirectory.Enabled = true;
         btnStartScan.Enabled = true;
         btnCancelScan.Enabled = false;
      }

      private void OnScanComplete(object sender, ScanCompleteEventArgs e) {
         ResetControls();
         scanThread = null;

         if (e.Success) {
            for (int i = cbbDirectory.Items.Count -1; i >= 0; i--) {
               if (e.ScanDir.Equals(cbbDirectory.Items[i].ToString(), StringComparison.CurrentCultureIgnoreCase)) {
                  cbbDirectory.Items.RemoveAt(i);
               }
            }

            cbbDirectory.Items.Insert(0, e.ScanDir);
            cbbDirectory.Text = e.ScanDir;
         }
      }

      /// <summary>
      /// Run in a thread.
      /// </summary>
      /// <param name="dir">Directory to start scanning at.</param>
      private void ScanDirectory(object dir) {
         string sdir = dir.ToString();
         bool success = false;

         try {
            FileScanner scanner = new FileScanner();

            scanner.ScanFiles(this, Thread.CurrentThread, sdir);

            LogAction("Scan complete");

            using (Database db = new Database()) { 
               db.SaveScanDir(sdir);
            }

            success = true;
         }
         catch (ThreadAbortException taex) {
            LogAction("Scan aborted: " + taex.Message);
         }
         catch (Exception ex) {
            LogAction("Scan interrupted: " + ex.Message + " (" + ex.ToString() + ")");
         }
         finally {
            BeginInvoke(onScanComplete, new object[] { this, new ScanCompleteEventArgs { ScanDir = sdir, Success = success } });
         }
      }

      private delegate void SafeCallDelegate(string action);

      public void LogAction(string action) {
         if (txtScanLog.InvokeRequired) {
            try {
               SafeCallDelegate d = new SafeCallDelegate(LogAction);

               txtScanLog.Invoke(d, new object[] { action });
            }
            catch { }
         }
         else {
            txtScanLog.AppendText(action);
            txtScanLog.AppendText("\r\n");
         }
      }

      private void btnCancelScan_Click(object sender, EventArgs e) {
         if (scanThread != null) {
            scanThread.Abort();
         }

         ResetControls();
      }
   }


}
