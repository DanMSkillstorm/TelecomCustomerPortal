using System.ComponentModel.DataAnnotations;

namespace StormerMobileAPI.Models
{
    public class Device
    {
        [Key]
        int Id { get; set; }
        int PlanId { get; set; }
        string Name { get; set; }
    }
}
