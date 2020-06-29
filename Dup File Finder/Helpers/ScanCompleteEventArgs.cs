using System;

namespace Dup_File_Finder.Helpers {
   public delegate void ScanCompleteEventHandler(object sdender, ScanCompleteEventArgs eventArgs);

   public class ScanCompleteEventArgs :EventArgs{
      public bool Success { get; set; }
      public string ScanDir { get; set; }
   }
}
