using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;

public class Program
{
    private static readonly string EndpointUri = "https://pdendy.documents.azure.com:443/>";

    private static readonly string PrimaryKey = "<8FLYDY98Z2P3sFM4ow2FnVfMw1tBysKKQnnywzzNpsbR1ePQf0LxYJ4844BZpqcmXcTbDAWxpFtj0jNSxSKobw==>";

    private CosmosClient _client;

    private Database _database;

    private Container _container;

    private string databaseId = "SeussSignalsDatabase";
    private string containerId = "SeussSignalsContainer";

    public static async Task Main(string[] args) { 
        try
        {
            Console.WriteLine("Beginning operations...\n");
            Program p = new Program();
            await p.SeussSignalsAsync();
        }
        catch (CosmosException cosmosException)
        {
            Console.WriteLine("Cosmos Exceptions with Status {0}: {1} \n", cosmosException.StatusCode, cosmosException);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: {0}", ex);
        }
        finally
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public async Task SeussSignalsAsync()
    {
        this._client = new CosmosClient(EndpointUri, PrimaryKey);
    }

    private async Task CreateDatabaseAsync()
    {
        this._database = await this._client.CreateDatabaseIfNotExistsAsync(databaseId);
        Console.WriteLine("Created Database: {0} \n", this._database.Id);
    }
}