using FolderCleaner2.Console.Models;
using System.Collections.Generic;

namespace FolderCleaner2.Console.Interfaces
{
    public interface IItemsGetter
    {
        IEnumerable<FileModel> GetFiles(IEnumerable<string> targetPaths);
        IEnumerable<FileModel> GetFiles(string targetPath);
        IEnumerable<FolderModel> GetFolders(IEnumerable<string> targetPaths);
    }
}
