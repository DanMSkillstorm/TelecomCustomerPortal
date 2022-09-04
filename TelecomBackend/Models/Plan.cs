using TelecomBackend.Models;
using Newtonsoft.Json;
namespace TelecomBackend
{
    public class Plan
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public int DeviceCount { get; set; }
        public int DeviceLimit { get; set; }
        public float Price { get; set; }
        public Plan() { }
        public Plan(string accountId, PlanDTO dto)
        {
            this.Id = Guid.NewGuid().ToString();
            this.AccountId = accountId;
            this.Name = dto.Name;
            this.DeviceCount = dto.DeviceCount;
            this.DeviceLimit = dto.DeviceLimit;
            this.Price = dto.Price;

        }
    }
}
