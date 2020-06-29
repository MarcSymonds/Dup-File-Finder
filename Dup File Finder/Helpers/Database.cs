using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Configuration;

namespace Dup_File_Finder.Helpers {
   /// <summary>
   /// Note: User used for connecting to DB needs GLOBAL.SELECT privilege to execute SPs. Without this, you get a "Data Is Null" error.
   /// </summary>
   public class Database : IDisposable {
      private static string connectionString = null;
      private MySqlConnection dbConn = null;

      private MySqlCommand cmdGetFile = null;
      private MySqlCommand cmdAddFile = null;
      private MySqlCommand cmdUpdateFile = null;

      private MySqlCommand cmdGetScanDirs = null;
      private MySqlCommand cmdSaveScanDir = null;

      private MySqlCommand cmdGetDuplicateFiles = null;
      private MySqlCommand cmdRemoveFile = null;

      private bool disposedValue=false;

      public Database() {
         dbConn = new MySqlConnection(connectionString);
         dbConn.Open();
      }

      static Database() {
         connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
      }

      protected virtual void Dispose(bool disposing) {
         if (!disposedValue) {
            if (disposing) {
               if (dbConn != null) {
                  dbConn.Close();
                  dbConn.Dispose();
                  dbConn = null;
               }
            }
            disposedValue = true;
         }
      }

      public void Dispose() {
         // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
         Dispose(disposing: true);
         GC.SuppressFinalize(this);
      }

      private MySqlCommand buildGetFileCmd() {
         if (cmdGetFile == null) {
            cmdGetFile = new MySqlCommand("getFile", dbConn);
            cmdGetFile.CommandType = CommandType.StoredProcedure;

            cmdGetFile.Parameters.Add("$filePath", MySqlDbType.VarChar);
         }

         return cmdGetFile;
      }

      private MySqlCommand buildAddFileCmd() {
         if (cmdAddFile == null) {
            cmdAddFile = new MySqlCommand("addFile", dbConn);
            cmdAddFile.CommandType = CommandType.StoredProcedure;

            cmdAddFile.Parameters.Add("$filePath", MySqlDbType.VarChar);
            cmdAddFile.Parameters.Add("$dateLastScanned", MySqlDbType.DateTime);
            cmdAddFile.Parameters.Add("$fileSize", MySqlDbType.Int64);
            cmdAddFile.Parameters.Add("$dateCreated", MySqlDbType.Int64);
            cmdAddFile.Parameters.Add("$dateLastModified", MySqlDbType.Int64);
            cmdAddFile.Parameters.Add("$hash", MySqlDbType.String, 64);
         }

         return cmdAddFile;
      }

      private MySqlCommand buildUpdateFileCmd() {
         if (cmdUpdateFile == null) {
            cmdUpdateFile = new MySqlCommand("updateFile", dbConn);
            cmdUpdateFile.CommandType = CommandType.StoredProcedure;

            cmdUpdateFile.Parameters.Add("$filePath", MySqlDbType.VarChar);
            cmdUpdateFile.Parameters.Add("$dateLastScanned", MySqlDbType.DateTime);
            cmdUpdateFile.Parameters.Add("$fileSize", MySqlDbType.Int64);
            cmdUpdateFile.Parameters.Add("$dateCreated", MySqlDbType.Int64);
            cmdUpdateFile.Parameters.Add("$dateLastModified", MySqlDbType.Int64);
            cmdUpdateFile.Parameters.Add("$hash", MySqlDbType.String, 64);
         }

         return cmdUpdateFile;
      }

      public DataTable GetFile(string filePath) {
         MySqlCommand cmd = cmdGetFile ?? buildGetFileCmd();

         cmd.Parameters["$filePath"].Value = filePath;

         DataTable dtData = new DataTable();
         MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
         dtData.Load(reader);

         return dtData;
      }

      public void SaveFile(string filePath, FileInfo fi, string hash, bool newFile) {
         MySqlCommand cmd;

         if (newFile) {
            cmd = cmdAddFile ?? buildAddFileCmd();
         }
         else {
            cmd = cmdUpdateFile ?? buildUpdateFileCmd();
         }

         cmd.Parameters["$filePath"].Value = filePath;
         cmd.Parameters["$dateLastScanned"].Value = DateTime.Now;
         cmd.Parameters["$fileSize"].Value = fi.Length;

         // Was having issues saving file date/time to DB, so changed to using FileTime, which is a long value.
         //
         cmd.Parameters["$dateCreated"].Value = fi.CreationTime.ToFileTime();
         cmd.Parameters["$dateLastModified"].Value = fi.LastWriteTime.ToFileTime();

         cmd.Parameters["$hash"].Value = hash;

         cmd.ExecuteNonQuery();
      }

      private MySqlCommand BuildGetScanDirsCmd() {
         if (cmdGetScanDirs == null) {
            cmdGetScanDirs = new MySqlCommand("getScanDirs", dbConn);
            cmdGetScanDirs.CommandType = CommandType.StoredProcedure;
         }

         return cmdGetScanDirs;
      }

      public DataTable GetScanDirs() {
         MySqlCommand cmd = cmdGetScanDirs ?? BuildGetScanDirsCmd();

         DataTable dtData = new DataTable();
         MySqlDataReader reader = cmd.ExecuteReader();
         dtData.Load(reader);

         return dtData;
      }

      private MySqlCommand BuildSaveScanDirCmd() {
         if (cmdSaveScanDir == null) {
            cmdSaveScanDir = new MySqlCommand("saveScanDir", dbConn);
            cmdSaveScanDir.CommandType = CommandType.StoredProcedure;

            cmdSaveScanDir.Parameters.Add("$dirPath", MySqlDbType.VarChar);
         }

         return cmdSaveScanDir;
      }

      public void SaveScanDir(string scanDir) {
         MySqlCommand cmd = cmdSaveScanDir ?? BuildSaveScanDirCmd();

         cmd.Parameters["$dirPath"].Value = scanDir;

         cmd.ExecuteNonQuery();
      }

      private MySqlCommand BuildGetDuplicateFilesCmd() {
         if (cmdGetDuplicateFiles == null) {
            cmdGetDuplicateFiles = new MySqlCommand("getDuplicateFiles", dbConn);
            cmdGetDuplicateFiles.CommandType = CommandType.StoredProcedure;
         }

         return cmdGetDuplicateFiles;
      }

      public DataTable GetDuplicateFiles() {
         MySqlCommand cmd = cmdGetDuplicateFiles ?? BuildGetDuplicateFilesCmd();

         MySqlDataReader reader = cmd.ExecuteReader();
         DataTable dtData = new DataTable();
         dtData.Load(reader);

         return dtData;
      }

      private MySqlCommand BuildRemoveFileCmd() {
         if (cmdRemoveFile == null) {
            cmdRemoveFile = new MySqlCommand("removeFile", dbConn);
            cmdRemoveFile.CommandType = CommandType.StoredProcedure;

            cmdRemoveFile.Parameters.Add("$filePath", MySqlDbType.VarChar);
         }

         return cmdRemoveFile;
      }

      public void RemoveFile(string filePath) {
         MySqlCommand cmd = cmdRemoveFile ?? BuildRemoveFileCmd();

         cmdRemoveFile.Parameters["$filePath"].Value = filePath;

         cmd.ExecuteNonQuery();
      }
   }
}