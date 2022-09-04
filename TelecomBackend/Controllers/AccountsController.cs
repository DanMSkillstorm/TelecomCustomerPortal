using Microsoft.AspNetCore.Mvc;
using TelecomBackend.Models;
using TelecomBackend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelecomBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        #region CREATE CONTEXT
        private readonly IAccountsCosmosDbService _context;

        public AccountsController(IAccountsCosmosDbService context)
        {
            _context = context;
        }

        #endregion

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(string id)
        {
            Account account = await _context.GetAccountAsync(id);
            return account;
        }

        // POST api/<AccountsController>
        [HttpPost]
        public async Task<ActionResult<Account>> CreateNewAccount(string id)
        {
            await _context.AddAccountAsync(id);
            return NoContent();
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _context.DeleteAccountAsync(id);
        }
    }
}
