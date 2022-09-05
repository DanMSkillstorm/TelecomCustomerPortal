using System.ComponentModel.DataAnnotations;

namespace StormerMobileAPI.Models
{
    public class PhoneNumber
    {
        [Key]
        int Number { get; set; }
        int AccountId { get; set; }
        string DeviceName { get; set; }
    }
}
