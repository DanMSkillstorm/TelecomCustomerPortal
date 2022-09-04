using TelecomBackend.Models;
using Newtonsoft.Json;

namespace TelecomBackend
{
    public class Device
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }

        public Device() { }
        public Device(string accountId, DeviceDTO dto)
        {
            this.Id = Guid.NewGuid().ToString();
            this.AccountId = accountId;
            this.Name = dto.Name;
            this.PhoneNumber = dto.PhoneNumber;
        }
    }
}
