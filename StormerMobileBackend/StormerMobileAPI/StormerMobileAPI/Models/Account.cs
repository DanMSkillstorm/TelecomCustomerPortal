using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StormerMobileAPI.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Plan>? Plans { get; set; }

    }
}
