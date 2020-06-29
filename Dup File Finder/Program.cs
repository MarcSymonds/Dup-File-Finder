using Dup_File_Finder.forms;
using System;
using System.Windows.Forms;

namespace Dup_File_Finder {
   static class Program {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main() {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new frmMain());
      }
   }
}
