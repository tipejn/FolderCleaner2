using FolderCleaner2.Console.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FolderCleaner2.Console.BL
{
    public class CleanManager : ICleanManager
    {
        private readonly IItemsProcessor _fileProcessor;
        private readonly IEnumerable<IFileValidator> _validators;
        private readonly IItemsGetter _getter;
        private readonly IRepository _repository;

        public CleanManager(
            IItemsProcessor fileProcessor, 
            IEnumerable<IFileValidator> validators, 
            IItemsGetter getter, 
            IRepository repository)
        {
            _fileProcessor = fileProcessor;
            _validators = validators;
            _getter = getter;
            _repository = repository;
        }

        public void DeleteBackup()
        {
            var backupPath = _repository.GetBackupPath();
            var backupFiles = _getter.GetFiles(backupPath);
            _fileProcessor.DeleteFiles(backupFiles.Select(f => f.Path));
        }

        public void CleanFiles()
        {
            var targetPaths = _repository.GetTargetPaths();
            var files = _getter.GetFiles(targetPaths);
            var filesToDelete = files.Where(f => _validators.All(v => v.IsValid(f.Path)));
            var backupPath = _repository.GetBackupPath();
            _fileProcessor.MoveFiles(filesToDelete.Select(f => f.Path), backupPath);
        }

        public void CleanFolders()
        {
            var targetPaths = _repository.GetTargetPaths();
            var folders = _getter.GetFolders(targetPaths);
            var foldersToDelete = folders.Where(f => !f.HasItems);
            _fileProcessor.DeleteDirectories(foldersToDelete.Select(f => f.Path));
        }

        public double GetRegainedSpace()
        {
            var backupPath = _repository.GetBackupPath();
            var backupFiles = _getter.GetFiles(backupPath);
            var regainedSpaceInBytes = backupFiles.Sum(f => f.Size);
            var regainedSpaceInMb = regainedSpaceInBytes / 1_000_000;
            return regainedSpaceInMb;
        }
    }
}
