using System.Collections.Generic;
using System.Threading.Tasks;
using StormerMobileAPI.Models;

namespace StormerMobileAPI.Services
{
    public interface ICosmosDbService
    {
        //Task<IEnumerable<Account>> GetAccountsAsync(string query);
        Task<Account> GetAccountAsync(string username);
        Task AddAccountAsync(AccountDTO acountDTO);
        Task UpdateAccountAsync(string username, AccountDTO accountDTO);
        Task DeleteAccountAsync(string username);
    }
}