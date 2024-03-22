using Azure.Storage.Files.DataLake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDataLake
{
    public interface IDataLakeManager
    {
        public Task<DataLakeFileSystemClient> CreateFileSystem(string fileSystemName);
        public Task<DataLakeDirectoryClient> GetDirectoryClient(DataLakeFileSystemClient fileSystemClient, string directoryName);  
        public Task<DataLakeDirectoryClient> CreateDirectory(DataLakeFileSystemClient fileSystemClient, string directoryName, string subdirectoryName);
        public Task<DataLakeDirectoryClient> RenameDirectory(DataLakeFileSystemClient fileSystemClient, string directoryPath, string subdirectoryName, string subdirectoryNameNew);
        public Task<DataLakeDirectoryClient> MoveDirectory(DataLakeFileSystemClient fileSystemClient, string directoryPathFrom, string directoryPathTo, string subdirectoryName);
        public Task UploadFile(DataLakeDirectoryClient directoryClient, string fileName, string localPath);
        public Task AppendDataToFile(DataLakeDirectoryClient directoryClient, string fileName, Stream stream);
        public Task DownloadFile(DataLakeDirectoryClient directoryClient, string fileName, string localPath);
        public Task ListFilesInDirectory(DataLakeFileSystemClient fileSystemClient, string directoryName);
        public Task DeleteDirectory(DataLakeFileSystemClient fileSystemClient, string directoryName);
    }
}
