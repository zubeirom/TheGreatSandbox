namespace AzureDataLake
{
    using Azure.Storage;
    using Azure.Storage.Files.DataLake;
    using System;

    public class DataLakeClient : IDataLakeClient
    {
        string accountName;
        string accountKey;

        public DataLakeClient(string accountName, string accountKey)
        {
            this.accountName = accountName;
            this.accountKey = accountKey;
        }

        public DataLakeServiceClient GetDataLakeServiceClient()
        {
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(this.accountName, this.accountKey);

            string url = $"https://{this.accountName}.dfs.core.windows.net";

            DataLakeServiceClient dataLakeServiceClient = new DataLakeServiceClient(new Uri(url), sharedKeyCredential);

            return dataLakeServiceClient;
        }
    }
}
