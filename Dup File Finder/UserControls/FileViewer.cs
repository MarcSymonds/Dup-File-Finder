using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Dup_File_Finder.UserControls {
   public partial class FileViewer : UserControl {
      public event EventHandler<FileViewerEventArgs> DeleteFile;

      private string FilePath { get; set; }

      public FileViewer() {
         InitializeComponent();
      }

      public void Set(DataRow drData) {
         this.Tag = (int)drData["id"];

         FilePath = drData["filePath"].ToString();

         txtFileName.Text = FilePath;
         txtDateCreated.Text = DateTime.FromFileTime((long)drData["dateCreated"]).ToString("dd/MM/yyyy HH:mm:ss");
         txtLastModified.Text = DateTime.FromFileTime((long)drData["dateLastModified"]).ToString("dd/MM/yyyy HH:mm:ss");
         txtSize.Text = ((long)drData["fileSize"]).ToString("#,##0");
         txtLastScanned.Text = ((DateTime)drData["dateLastScanned"]).ToString("dd/MM/yyyy HH:mm:ss");

         string ext = Path.GetExtension(FilePath).TrimStart('.').ToLower();

         if (ext == "jpg" || ext == "png" || ext == "gif" || ext == "bmp") {
            pbImage.Visible = true;
            pbImage.Load(FilePath);
         }
         else {
            pbImage.Visible = false;
            pbImage.Load("Assets/EmptyImage.bmp");
         }
      }

      private void btnDelete_Click(object sender, EventArgs e) {
         if (MessageBox.Show(this, "Delete the file " + FilePath + "?", "Delete File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
            DeleteFile.Invoke(this, new FileViewerEventArgs() { FilePath = FilePath });
         }
      }

      /// <summary>
      /// PictureBox controls hold loaded files open while displayed (I'm sure there is a good reason). While the file
      /// is open though, you can't delete the file. So we load a different image in to the PictureBox which forces it
      /// to release it's hold on the original file. We can then delete it.
      /// </summary>
      public void ClearImage() {
         pbImage.Visible = false;
         pbImage.Load("Assets/EmptyImage.bmp");
      }

      public void SizeContent() {
         if (pbImage.Visible) {
            int pbw = pbImage.Width;

            pbImage.Height = (int)((decimal)pbw / (pbImage.PreferredSize.Width == 0 ? pbw : pbImage.PreferredSize.Width) * pbImage.PreferredSize.Height);

            this.Height = pbImage.Height + pbImage.Top + 48;
         }
         else {
            this.Height = 110;
         }
      }
   }

   public class FileViewerEventArgs {
      public string FilePath { get; set; }
   }
}
