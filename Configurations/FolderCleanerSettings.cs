using System.Collections.Generic;

namespace FolderCleaner2.Console.Configurations
{
    public class FolderCleanerSettings
    {
        public ICollection<string> TargetPaths { get; set; }
        public string BackupPath { get; set; }
        public int MaxDaysWithoutAccess { get; set; }
        public ICollection<string> ForbiddenExtensions { get; set; }
    }
}
