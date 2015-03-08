#region
using System;
using System.Collections.Generic;
using bscheiman.Common.Extensions;
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Responses {
    public class Order {
        [JsonProperty("btc_amount")]
        public decimal BtcAmount { get; set; }

        [JsonProperty("btc_pending")]
        public decimal BtcPending { get; set; }

        [JsonProperty("btc_received")]
        public decimal BtcReceived { get; set; }

        [JsonProperty("confirmation_code")]
        public string ConfirmationCode { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        public DateTime CreatedAtDt {
            get { return CreatedAt.FromEpoch().ToLocalTime(); }
        }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("currency_amount")]
        public decimal CurrencyAmount { get; set; }

        [JsonProperty("currency_fees")]
        public decimal CurrencyFees { get; set; }

        [JsonProperty("currency_settled")]
        public decimal CurrencySettled { get; set; }

        [JsonProperty("expires_epoch")]
        public long ExpiresEpoch { get; set; }

        public DateTime ExpiresEpochDt {
            get { return ExpiresEpoch.FromEpoch().ToLocalTime(); }
        }

        [JsonProperty("fields")]
        public Dictionary<string, object> Fields { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("payment_outlet_id")]
        public string PaymentOutletId { get; set; }

        [JsonProperty("qr_img_uri")]
        public string QrImgUri { get; set; }

        [JsonProperty("status")]
        public OrderStatus Status { get; set; }

        [JsonProperty("user_uri")]
        public string UserUri { get; set; }

        [JsonProperty("wallet_address")]
        public string WalletAddress { get; set; }

        public static implicit operator string(Order tx) {
            return tx.Id;
        }

        public static implicit operator Order(string tx) {
            return new Order {
                Id = tx
            };
        }
    }
}