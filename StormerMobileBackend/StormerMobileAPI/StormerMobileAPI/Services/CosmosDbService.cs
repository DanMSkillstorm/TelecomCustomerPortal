using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StormerMobileAPI.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using System;

namespace StormerMobileAPI.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;
        private IConfiguration _configuration;
        public CosmosDbService(IConfiguration configuration)
        {
            _configuration = configuration;
            string databaseName = _configuration.GetSection("CosmosDB:DatabaseName").Value;
            string containerName = _configuration.GetSection("CosmosDB:ContainerName").Value;
            string account = _configuration.GetSection("CosmosDB:Account").Value;
            string key = _configuration.GetSection("CosmosDB:Key").Value;
            CosmosClient client = new CosmosClient(account, key);
            var dbService = new CosmosDbService(client, databaseName, containerName);
            DatabaseResponse database = client.CreateDatabaseIfNotExistsAsync(databaseName).GetAwaiter().GetResult();
            database.Database.CreateContainerIfNotExistsAsync(containerName, "/id").GetAwaiter().GetResult();
            this._container = client.GetContainer(databaseName, containerName);
        }
        public CosmosDbService(
                CosmosClient dbClient,
                string databaseName,
                string containerName
            )
            {
                this._container = dbClient.GetContainer(databaseName, containerName);
            }

        #region ACCOUNT ACTIONS
        public async Task AddAccountAsync(AccountDTO accountDTO)
        {
            var test = this._container.GetItemLinqQueryable<Account>(true)
                .Where(a => a.Username == accountDTO.Username)
                .AsEnumerable()
                .Any();
            if (test)
            {
                throw new Exception("Username is taken");
            }

            var rand = new Random();
            int generated_Id = rand.Next(10, 99);
            DateTime currTime = DateTime.Now;
            int day = currTime.Day;
            generated_Id = Convert.ToInt32(string.Format("{0}{1}", generated_Id, day));
            int hour = currTime.Hour;
            generated_Id = Convert.ToInt32(string.Format("{0}{1}", generated_Id, hour));
            int minute = currTime.Minute;
            generated_Id = Convert.ToInt32(string.Format("{0}{1}", generated_Id, minute));
            string generated_Id_string = generated_Id.ToString();
            var account = new Account(accountDTO, generated_Id_string);
            await this._container.CreateItemAsync<Account>(account, new PartitionKey(account.id));
        }

        public async Task DeleteAccountAsync(string username)
        {
            Account accountToFind = this._container.GetItemLinqQueryable<Account>(true)
                .Where(a => a.Username == username)
                .AsEnumerable()
                .First();

            await this._container.DeleteItemAsync<Account>(accountToFind.id, new PartitionKey(accountToFind.id));
        }

        public async Task<Account> GetAccountAsync(string username)
        {
            try
            {
                Account accountToFind = this._container.GetItemLinqQueryable<Account>(true)
                .Where(a => a.Username == username)
                .AsEnumerable()
                .First();
                //find a way to handle empty Query Exception to return custom exception
                if (accountToFind == null)
                {
                    throw new Exception("Username not found");
                }
                ItemResponse<Account> account = await this._container.ReadItemAsync<Account>(accountToFind.id, new PartitionKey(accountToFind.id));
                return account.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task UpdateAccountAsync(string username, AccountDTO accountDTO)
        {
            Account accountToFind = this._container.GetItemLinqQueryable<Account>(true)
                .Where(a => a.Username == username)
                .AsEnumerable()
                .First();
            //find a way to handle empty Query Exception to return custom exception
            var account = new Account(accountDTO, accountToFind.id);
            await this._container.UpsertItemAsync<Account>(account, new PartitionKey(account.id));
        }

        #endregion
    }
}
