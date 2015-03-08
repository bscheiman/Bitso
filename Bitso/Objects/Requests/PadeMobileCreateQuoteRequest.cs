#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class PadeMobileCreateQuoteRequest : BaseCreateQuoteRequest {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}