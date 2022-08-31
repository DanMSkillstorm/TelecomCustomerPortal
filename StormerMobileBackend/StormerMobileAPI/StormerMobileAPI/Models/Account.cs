using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StormerMobileAPI.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Plan>? Plans { get; set; }

        public Account() { }
        public Account(AccountDTO dto, string id)
        {
            this.id = id;
            this.Username = dto.Username;
            this.Password = dto.Password;
        }
    }
}
