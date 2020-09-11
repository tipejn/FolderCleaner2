using FolderCleaner2.Console.Interfaces;
using System.IO;

namespace FolderCleaner2.Console.Validators
{
    public class ExtensionValidator : IFileValidator
    {
        private readonly IRepository _repository;

        public ExtensionValidator(IRepository repository)
        {
            _repository = repository;
        }
        public bool IsValid(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath);
            var forbiddenExtensions = _repository.GetForbiddenExtensions();
            var isValid = !forbiddenExtensions?.Contains(fileExtension) ?? false;
            return isValid;
        }
    }
}
