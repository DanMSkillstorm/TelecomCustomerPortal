using StormerMobileAPI.Context;
using StormerMobileAPI.Models;
using System;
using System.Threading.Tasks;

namespace StormerMobileAPI.Controllers
{
    public class AccountsCosmosController
    {
        public static async Task CreateNewAccount()
        {
            using (var context = new AccountContext())
            {
                await context.Database.EnsureCreatedAsync();

                var rand = new Random();
                int generated_id = rand.Next(1000, 9999);
                generated_id *= 10000000;
                DateTime currTime = DateTime.Now;
                int month = currTime.Month;
                generated_id += (month * 10000);
                int day = currTime.Day;
                generated_id += (day * 100);
                int minute = currTime.Minute;
                generated_id += minute;

                context.Add(
                    new Account{
                        Id = generated_id,
                        Username = "USERNAME2",
                        Password = "PASSWORD2"
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
