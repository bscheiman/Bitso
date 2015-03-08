#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class UserTransactionsRequest : BasePostObject {
        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("sort")]
        public Sort Sort { get; set; }
    }

    public enum Sort {
        Desc,
        Asc
    }
}