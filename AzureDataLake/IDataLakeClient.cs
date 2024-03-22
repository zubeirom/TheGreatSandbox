using Azure.Storage.Files.DataLake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDataLake
{
    public interface IDataLakeClient
    {
        public DataLakeServiceClient GetDataLakeServiceClient();
    }
}
