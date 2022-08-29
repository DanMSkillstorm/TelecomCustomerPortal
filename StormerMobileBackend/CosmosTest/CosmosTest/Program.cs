using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace CosmosTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateItem().Wait();
        }
        private static async Task CreateItem()
        {
            var _cosmoURL = "https://telecom-project-db.documents.azure.com:443/";
            var _cosmoKEY = "wRvBT0T05loywHfw4rBJJbhfsSRexp4bNaAc02RDpuQTGMMFOX08DCSRtTilRM93Q7m5WEjJiWHwifxWPl0ATg==";
            var _databaseName = "testContainerDB";

            CosmosClient client = new CosmosClient(_cosmoURL, _cosmoKEY);
            Database database = await client.CreateDatabaseIfNotExistsAsync(_databaseName);

            Container container = await database.CreateContainerIfNotExistsAsync(
                "MyContainerName", "/partitionKeyPath", 400
            );

            dynamic testItem = new
            {
                id = Guid.NewGuid().ToString(),
                partitionKeyPath = "myTestPkValue",
                details = "details go in here"
            };

            ItemResponse<dynamic> response = await container.CreateItemAsync(testItem);
        }
    }
}