using System.Collections.Generic;

namespace FolderCleaner2.Console.Interfaces
{
    public interface IItemsProcessor
    {
        void DeleteFiles(IEnumerable<string> filePaths);
        void MoveFiles(IEnumerable<string> filePaths, string destPath);
        void DeleteDirectories(IEnumerable<string> directoryPaths);
    }
}
