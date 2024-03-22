using Azure.Storage.Files.DataLake;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzureDataLake
{
    public class Program
    {
        public static Stream GetStreamWithStreamWriter(string sampleString, Encoding? encoding = null)
        {
            encoding ??= Encoding.UTF8;

            var stream = new MemoryStream(encoding.GetByteCount(sampleString));
            using var writer = new StreamWriter(stream, encoding, -1, true);
            writer.Write(sampleString);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }

        public static async Task Execute()
        {
            const string ASAKeyEnvName = "ASA_KEY";
            const string ASANameEnvName = "ASA_NAME";

            var asaKey = Environment.GetEnvironmentVariable(ASAKeyEnvName);
            var asaName = Environment.GetEnvironmentVariable(ASANameEnvName);

            if (asaKey == null || asaName == null)
            {
                throw new Exception("Azure Storage Account Key or Name not found");
            }

            IDataLakeClient dlc = new DataLakeClient(asaName, asaKey);
            DataLakeServiceClient dataLakeServiceClient = dlc.GetDataLakeServiceClient();

            IDataLakeManager dataLakeManager = new DataLakeManager(dataLakeServiceClient);

            var fileSystemName = "thegreatfilesystem";

            // var fileSystem = await dataLakeManager.CreateFileSystem(fileSystemName.ToLower());

            var fileSystem = dataLakeServiceClient.GetFileSystemClient(fileSystemName);

            var directoryName = "TheGreatDirectory";

            // var subdirectoryName = "TheGreatSubDirectory";

            //var directoryClient = await dataLakeManager.CreateDirectory(fileSystem, directoryName, subdirectoryName);

            var directoryClient = fileSystem.GetDirectoryClient(directoryName);

            var fileName = "1cbd6c07-c89e-404e-adb3-23a4f15b3f10";

            var fileClient = directoryClient.GetFileClient(fileName);

            await fileClient.CreateIfNotExistsAsync();

            var data = new Dictionary<string, string>()
            {
                { "Id", fileName },
                { "data", "SomeRandomInformation" }
            };

            var json = JsonConvert.SerializeObject(data);

            var stream = GetStreamWithStreamWriter(json);

            long fileSize = fileClient.GetProperties().Value.ContentLength;

            await fileClient.AppendAsync(stream, offset: fileSize);

            await fileClient.FlushAsync(position: fileSize + stream.Length);
        }

        public static async Task Main(string[] args)
        {
            try
            {
                await Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}
