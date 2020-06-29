using Dup_File_Finder.Forms;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace Dup_File_Finder.Helpers {
   public class FileScanner {
      /// <summary>
      /// Cryptographic object which will be used for generating the file hashes.
      /// </summary>
      private SHA256 sha256 = SHA256.Create();

      public void ScanFiles(frmScan frm, Thread thread, string startDirectory) {
         using (Database db = new Database()) { 
               ScanFiles(frm, thread, db, startDirectory, 1);
         }
      }

      /// <summary>
      /// Scan files in a directory.
      /// This function is recursive, in that once it has scanned the files, it will look for directories 
      /// and recall this function for each directory.
      /// </summary>
      /// <param name="frm">The owner form to which the log is written.</param>
      /// <param name="thread">The thread that code is running in. Could use Thread.CurrentThread, but what the heck.</param>
      /// <param name="db">Database for doing database things.</param>
      /// <param name="dir">Directory to scan</param>
      /// <param name="depth">Counter to indicate how many subdirectories (i.e. recursions) deep it has scanned.</param>
      private void ScanFiles(frmScan frm, Thread thread, Database db, string dir, int depth) {
         frm.LogAction(string.Format("Scanning directory {0} ({1})", dir, depth));

         try {
            string[] files = Directory.GetFiles(dir, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string file in files) {
               bool fileChanged = false;
               bool newFile = false;

               // If the thread is no longer running, then stop what we are doing.
               //
               if (thread.ThreadState != ThreadState.Running) {
                  return;
               }

               // Get the file info.
               //
               FileInfo fi = new FileInfo(file);

               // Look up the file in the DB.
               //
               DataTable dtFile = db.GetFile(file);

               if (dtFile.Rows.Count == 0) {
                  // If the file is not in the DB, then it is a new file (obvs).
                  //
                  fileChanged = true;
                  newFile = true;
               }
               else {
                  DataRow drFile = dtFile.Rows[0];

                  // Use dates and size to determine if a file has changed since the last scan.
                  //
                  long dateCreated = (long)drFile["dateCreated"];
                  long dateLastModified = (long)drFile["dateLastModified"];
                  long fileSize = (long)drFile["fileSize"];

                  if (fi.CreationTime.ToFileTime() != dateCreated || fi.LastWriteTime.ToFileTime() != dateLastModified || fi.Length != fileSize) {
                     fileChanged = true;
                  }
               }

               if (fileChanged) {
                  if (newFile) {
                     frm.LogAction(string.Format("New file: {0}", file));
                  }
                  else {
                     frm.LogAction(string.Format("Updated file: {0}", file));
                  }

                  // Calculate the hash for the file.
                  //
                  string hash = GetFileHash(file);

                  // Save the file info and hash to the DB.
                  //
                  db.SaveFile(file, fi, hash, newFile);
               }
            }

            // Now look for and scan subdirectories.
            //
            string[] dirs = Directory.GetDirectories(dir, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string sdir in dirs) {
               if (thread.ThreadState != ThreadState.Running) {
                  return;
               }

               ScanFiles(frm, thread, db, sdir, depth + 1);
            }
         }
         catch(UnauthorizedAccessException ex) {
            frm.LogAction(ex.Message);
         }
         finally {

         }
      }

      /// <summary>
      /// Generate a SHA256 hash of a files contents.
      /// </summary>
      /// <param name="filePath">The file to generate the hash for.</param>
      /// <returns>64 character string representing the 512 bit hash of the file.</returns>
      private string GetFileHash(string filePath) {
         string hash = "";
         byte[] sha;

         using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read)) {
            sha = sha256.ComputeHash(stream);
         }

         foreach (byte b in sha) {
            hash += b.ToString("x2");
         }

         return hash;
      }
   }
}

