#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class SpeiCreateQuoteRequest : BaseCreateQuoteRequest {
        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("clabe")]
        public string Clabe { get; set; }

        [JsonProperty("recipient_family_names")]
        public string RecipientFamilyNames { get; set; }

        [JsonProperty("recipient_given_names")]
        public string RecipientGivenNames { get; set; }
    }
}