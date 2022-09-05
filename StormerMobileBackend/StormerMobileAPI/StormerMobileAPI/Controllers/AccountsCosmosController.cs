//using StormerMobileAPI.Context;
//using StormerMobileAPI.Models;
//using System;
//using System.Threading.Tasks;

//namespace StormerMobileAPI.Controllers
//{
//    public class AccountsCosmosController
//    {
//        public static async Task CreateNewAccount()
//        {
//            using (var context = new AccountContext())
//            {
//                await context.Database.EnsureCreatedAsync();

//                var rand = new Random();
//                int generated_id = rand.Next(10, 99);
//                DateTime currTime = DateTime.Now;
//                int day = currTime.Day;
//                generated_id = Convert.ToInt32(string.Format("{0}{1}", generated_id, day));
//                int hour = currTime.Hour;
//                generated_id = Convert.ToInt32(string.Format("{0}{1}", generated_id, hour));
//                int minute = currTime.Minute;
//                generated_id = Convert.ToInt32(string.Format("{0}{1}", generated_id, minute));

//                context.Add(
//                    new Account{
//                        Id = generated_id,
//                        Username = "USERNAME",
//                        Password = "PASSWORD"
//                    }
//                );
//                await context.SaveChangesAsync();
//            }
//        }
//    }
//}
