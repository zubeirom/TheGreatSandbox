namespace AzureDataLake
{
    using Azure.Storage.Files.DataLake;
    using System.IO;
    using System.Threading.Tasks;

    public class DataLakeManager : IDataLakeManager
    {

        DataLakeServiceClient dataLakeClient;

        public DataLakeManager(DataLakeServiceClient dataLakeClient)
        {
            this.dataLakeClient = dataLakeClient;
        }

        public async Task<DataLakeFileSystemClient> CreateFileSystem(string fileSystemName)
        {
            return await this.dataLakeClient.CreateFileSystemAsync(fileSystemName);
        }

        public async Task<DataLakeDirectoryClient> CreateDirectory(DataLakeFileSystemClient fileSystemClient, string directoryName, string subdirectoryName)
        {
            DataLakeDirectoryClient directoryClient = await fileSystemClient.CreateDirectoryAsync(directoryName);

            return await directoryClient.CreateSubDirectoryAsync(subdirectoryName);
        }

        public Task<DataLakeDirectoryClient> RenameDirectory(DataLakeFileSystemClient fileSystemClient, string directoryPath, string subdirectoryName, string subdirectoryNameNew)
        {
            throw new NotImplementedException();
        }

        public Task<DataLakeDirectoryClient> MoveDirectory(DataLakeFileSystemClient fileSystemClient, string directoryPathFrom, string directoryPathTo, string subdirectoryName)
        {
            throw new NotImplementedException();
        }

        public Task UploadFile(DataLakeDirectoryClient directoryClient, string fileName, string localPath)
        {
            throw new NotImplementedException();
        }

        public Task AppendDataToFile(DataLakeDirectoryClient directoryClient, string fileName, Stream stream)
        {
            throw new NotImplementedException();
        }

        public Task DownloadFile(DataLakeDirectoryClient directoryClient, string fileName, string localPath)
        {
            throw new NotImplementedException();
        }

        public Task ListFilesInDirectory(DataLakeFileSystemClient fileSystemClient, string directoryName)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDirectory(DataLakeFileSystemClient fileSystemClient, string directoryName)
        {
            throw new NotImplementedException();
        }

        public async Task<DataLakeDirectoryClient> GetDirectoryClient(DataLakeFileSystemClient fileSystemClient, string directoryName)
        {
            var f = fileSystemClient.GetDirectoryClient(directoryName);
            return f;
        }
    }
}
