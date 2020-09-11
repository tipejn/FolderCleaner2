using FolderCleaner2.Console.Interfaces;
using System;

namespace FolderCleaner2.Console
{
    public class FolderCleanerApplication
    {
        private readonly ICleanManager _cleanManager;

        public FolderCleanerApplication(ICleanManager cleanManager)
        {
            _cleanManager = cleanManager;
        }

        public void Run()
        {
            try
            {
                DeleteBackup();
                CleanFiles();
                CleanFolders();
                ShowRegainedSpace();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Unknown error: {ex.Message}");
            }
        }

        private void DeleteBackup()
        {
            _cleanManager.DeleteBackup();
        }

        private void CleanFiles()
        {
            _cleanManager.CleanFiles();
        }

        private void CleanFolders()
        {
            _cleanManager.CleanFolders();
        }

        private void ShowRegainedSpace()
        {
            var regainedSpace = _cleanManager.GetRegainedSpace();
            System.Console.WriteLine($"Regained {regainedSpace:0.##} MB");
            System.Console.ReadKey();
        }
    }
}
