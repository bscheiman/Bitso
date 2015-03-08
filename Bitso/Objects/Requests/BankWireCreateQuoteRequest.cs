#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class BankWireCreateQuoteRequest : BaseCreateQuoteRequest {
        [JsonProperty("account_holder_address")]
        public string AccountHolderAddress { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("bank_address")]
        public string BankAddress { get; set; }

        [JsonProperty("other_instructions")]
        public string OtherInstructions { get; set; }

        [JsonProperty("recipient_full_name")]
        public string RecipientFullName { get; set; }

        [JsonProperty("swift")]
        public string Swift { get; set; }
    }
}