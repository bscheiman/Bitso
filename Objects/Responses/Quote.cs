#region
using System;
using System.Collections.Generic;
using bscheiman.Common.Extensions;
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Responses {
    public class Quote {
        [JsonProperty("btc_amount")]
        public decimal BtcAmount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("expires_epoch")]
        public long ExpiresEpoch { get; set; }

        public DateTime ExpiresEpochDt {
            get { return ExpiresEpoch.FromEpoch().ToLocalTime(); }
        }

        [JsonProperty("gross")]
        public decimal Gross { get; set; }

        [JsonProperty("outlets")]
        public Dictionary<string, Outlet> Outlets { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        public DateTime TimestampDt {
            get { return Timestamp.FromEpoch().ToLocalTime(); }
        }
    }
}