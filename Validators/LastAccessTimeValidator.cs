using FolderCleaner2.Console.Interfaces;
using System;
using System.IO;

namespace FolderCleaner2.Console.Validators
{
    public class LastAccessTimeValidator : IFileValidator
    {
        private readonly IRepository _repository;

        public LastAccessTimeValidator(IRepository repository)
        {
            _repository = repository;
        }
        public bool IsValid(string filePath)
        {
            var lastTimeAccess = File.GetLastAccessTimeUtc(filePath);
            var daysWithoutAccess = (DateTime.UtcNow - lastTimeAccess).Days;
            var maxDaysWithoutAccess = _repository.GetMaxDaysWithoutAccess();
            var isValid = daysWithoutAccess > maxDaysWithoutAccess;
            return isValid;
        }
    }
}
