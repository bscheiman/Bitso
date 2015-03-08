#region
using System.Collections.Generic;
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Responses {
    public class Outlet {
        [JsonProperty("available")]
        public string Available { get; set; }

        [JsonProperty("daily_limit")]
        public string DailyLimit { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("maximum_transaction")]
        public string MaximumTransaction { get; set; }

        [JsonProperty("minimum_transaction")]
        public string MinimumTransaction { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("net")]
        public string Net { get; set; }

        [JsonProperty("required_fields")]
        public IList<string> RequiredFields { get; set; }

        [JsonProperty("verification_level_requirement")]
        public string VerificationLevelRequirement { get; set; }
    }
}