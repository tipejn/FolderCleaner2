using FolderCleaner2.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace FolderCleaner2.Console.BL
{
    public class ItemsProcessor : IItemsProcessor
    {
        public void DeleteFiles(IEnumerable<string> filePaths)
        {
            foreach (var filePath in filePaths)
            {
                TryDeleteFile(filePath);
            }
        }

        public void MoveFiles(IEnumerable<string> filePaths, string destPath)
        {
            foreach (var filePath in filePaths)
            {
                TryMoveFile(filePath, destPath);
            }
        }

        public void DeleteDirectories(IEnumerable<string> directoryPaths)
        {
            foreach (var directoryPath in directoryPaths)
            {
                TryDeleteDirectory(directoryPath);
            }
        }

        private bool TryMoveFile(string filePath, string destFolderPath)
        {
            try
            {
                var shortFileName = Path.GetFileName(filePath);
                var newFileName = Path.Combine(destFolderPath, shortFileName);
                File.Move(filePath, newFileName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool TryDeleteFile(string filePath)
        {
            try
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
                File.Delete(filePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool TryDeleteDirectory(string directoryPath)
        {
            try
            {
                Directory.Delete(directoryPath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
