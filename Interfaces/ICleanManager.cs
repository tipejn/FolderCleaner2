namespace FolderCleaner2.Console.Interfaces
{
    public interface ICleanManager
    {
        void DeleteBackup();
        void CleanFiles();
        void CleanFolders();
        double GetRegainedSpace();
    }
}
