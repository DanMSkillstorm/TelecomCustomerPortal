using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StormerMobileAPI.Models
{
    public class Plan
    {
        [Key]
        int Id { get; set; }
        int AccountId { get; set; } 
        string PlanName { get; set; }
        int DeviceCount { get; set; } = 0;
        int DeviceLimit { get; set; }
        float Price { get; set; }

        ICollection<Device> Devices { get; set; }
        ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
