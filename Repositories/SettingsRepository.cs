using FolderCleaner2.Console.Configurations;
using FolderCleaner2.Console.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace FolderCleaner2.Console.Repositories
{
    public class SettingsRepository : IRepository
    {
        private readonly FolderCleanerSettings _settings;

        public SettingsRepository(IOptions<FolderCleanerSettings> options)
        {
            _settings = options.Value;
        }
        public string GetBackupPath()
        {
            return _settings.BackupPath;
        }

        public ICollection<string> GetForbiddenExtensions()
        {
            return _settings.ForbiddenExtensions;
        }

        public int GetMaxDaysWithoutAccess()
        {
            return _settings.MaxDaysWithoutAccess;
        }

        public IEnumerable<string> GetTargetPaths()
        {
            return _settings.TargetPaths;
        }
    }
}
