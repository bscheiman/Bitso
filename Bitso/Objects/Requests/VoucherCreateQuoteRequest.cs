#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class VoucherCreateQuoteRequest : BaseCreateQuoteRequest {
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("recipient_given_name")]
        public string RecipientGivenName { get; set; }
    }
}