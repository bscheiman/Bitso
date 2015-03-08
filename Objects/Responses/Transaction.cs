#region
using System;
using bscheiman.Common.Extensions;
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Responses {
    public class Transaction {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        public DateTime DateDt {
            get { return Date.FromEpoch().ToLocalTime(); }
        }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("tid")]
        public int Tid { get; set; }
    }
}