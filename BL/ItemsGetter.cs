using FolderCleaner2.Console.Interfaces;
using FolderCleaner2.Console.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FolderCleaner2.Console.BL
{
    public class ItemsGetter : IItemsGetter
    {
        public IEnumerable<FileModel> GetFiles(IEnumerable<string> targetPaths)
        {
            var files = new List<FileModel>();
            foreach (var targetPath in targetPaths)
            {
                var targetFiles = GetFiles(targetPath);
                files.AddRange(targetFiles);
            }
            return files;
        }

        public IEnumerable<FolderModel> GetFolders(IEnumerable<string> targetPaths)
        {
            var folders = new List<FolderModel>();
            foreach (var tagetPath in targetPaths)
            {
                var targetFilePaths = Directory.EnumerateDirectories(tagetPath, FolderCleanerConsts.SEARCH_PATTERN_ALL, SearchOption.AllDirectories);
                var targetFolders = targetFilePaths.Select(f => new FolderModel
                {
                    Path = f,
                    HasItems = Directory.EnumerateFileSystemEntries(f).Any()
                });
                folders.AddRange(targetFolders);
            }
            return folders;
        }

        public IEnumerable<FileModel> GetFiles(string targetPath)
        {
            var targetFilePaths = Directory.EnumerateFiles(targetPath, FolderCleanerConsts.SEARCH_PATTERN_ALL, SearchOption.AllDirectories);
            var targetFiles = targetFilePaths.Select(f =>
            {
                var fileInfo = new FileInfo(f);
                var fileSize = fileInfo.Length;
                return new FileModel
                {
                    Path = f,
                    Size = fileSize
                };
            });
            return targetFiles;
        }
    }
}
