using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using StormerMobileAPI.Context;
using StormerMobileAPI.Models;
using StormerMobileAPI.Services;

namespace StormerMobileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ICosmosDbService _context;

        public AccountsController(ICosmosDbService context)
        {
            _context = context;
        }


        // GET: api/Accounts/5
        [HttpGet("{username}")]
        public async Task<ActionResult<Account>> GetAccount(string username)
        {
            //if (_context.Accounts == null)
            //{
            //    return NotFound();
            //}
            var account = await _context.GetAccountAsync(username);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{username}")]
        public async Task<IActionResult> PutAccount(string username, AccountDTO accountDTO)
        {
            await _context.UpdateAccountAsync(username, accountDTO);

            return NoContent();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountDTO>> PostAccount(AccountDTO accountDTO)
        {

            await _context.AddAccountAsync(accountDTO);

            return NoContent();
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteAccount(string username)
        {
            var account = await _context.GetAccountAsync(username);
            if (account == null)
            {
                return NotFound();
            }

            await _context.DeleteAccountAsync(username);

            return NoContent();
        }
    }
}
