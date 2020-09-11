using System.Collections.Generic;

namespace FolderCleaner2.Console.Interfaces
{
    public interface IRepository
    {
        IEnumerable<string> GetTargetPaths();
        string GetBackupPath();
        int GetMaxDaysWithoutAccess();
        ICollection<string> GetForbiddenExtensions();
    }
}
