#region
using System.Collections.Generic;
using System.Threading.Tasks;
using bscheiman.Common.Extensions;
using Bitso.Objects;
using RestSharp;

#endregion

namespace Bitso {
    public class BitsoLib {
        private const string BaseUrl = "https://api.bitso.com/v2/";
        public string ApiSecret { get; set; }
        public string ApiUser { get; set; }
        public int ClientId { get; set; }

        public BitsoLib(int clientId, string apiUser, string apiSecret) {
            ClientId = clientId;
            ApiUser = apiUser;
            ApiSecret = apiSecret;
        }

        public Task<Balance> GetBalanceAsync() {
            return PostAsync<Balance>("balance", new BasePostObject());
        }

        public Task<OrderBook> GetOrderBookAsync() {
            return GetAsync<OrderBook>("order_book");
        }

        public Task<Ticker> GetTickerAsync(string book = "btc_mxn") {
            return GetAsync<Ticker>("ticker", null, new Parameter {
                Name = "book",
                Value = book,
                Type = ParameterType.QueryString
            });
        }

        public Task<Transaction[]> GetTransactionsAsync(string book = "btc_mxn", bool perHour = true) {
            return GetAsync<Transaction[]>("transactions", null, new Parameter {
                Name = "book",
                Value = book,
                Type = ParameterType.QueryString
            }, new Parameter {
                Name = "time",
                Value = perHour ? "hour" : "minute",
                Type = ParameterType.QueryString
            });
        }

        #region Helpers
        internal Task<T> DeleteAsync<T>(string url, params Parameter[] parameters) where T : new() {
            var tcs = new TaskCompletionSource<T>();
            var client = GetClient(url);

            client.ExecuteAsync(GetRequest(url, Method.DELETE, null, parameters), response => tcs.SetResult(response.Content.FromJson<T>()));

            return tcs.Task;
        }

        internal Task<T> GetAsync<T>(string url, BasePostObject obj = null, params Parameter[] parameters) {
            var tcs = new TaskCompletionSource<T>();
            var client = GetClient(url);

            client.ExecuteAsync(GetRequest(url, Method.GET, obj, parameters), response => tcs.SetResult(response.Content.FromJson<T>()));

            return tcs.Task;
        }

        internal RestClient GetClient(string url) {
            var client = new RestClient(BaseUrl) {
                UserAgent = "Bitso.NET"
            };

            return client;
        }

        internal RestRequest GetRequest(string url, Method method, BasePostObject obj, params Parameter[] parameters) {
            var request = new RestRequest(url, method);

            foreach (var p in parameters)
                request.AddParameter(p);

            request.AddParameter("application/json", obj.ToJson(), ParameterType.RequestBody);

            return request;
        }

        internal Task<T> PostAsync<T>(string url, BasePostObject obj, params Parameter[] parameters) where T : new() {
            var tcs = new TaskCompletionSource<T>();
            var client = GetClient(url);

            obj.Setup(ApiUser, ClientId, ApiSecret);
            client.ExecuteAsync(GetRequest(url, Method.POST, obj, parameters), response => tcs.SetResult(response.Content.FromJson<T>()));

            return tcs.Task;
        }

        internal Task<T> PutAsync<T>(string url, BasePostObject obj, params Parameter[] parameters) where T : new() {
            var tcs = new TaskCompletionSource<T>();
            var client = GetClient(url);

            obj.Setup(ApiUser, ClientId, ApiSecret);
            client.ExecuteAsync(GetRequest(url, Method.PUT, obj, parameters), response => tcs.SetResult(response.Content.FromJson<T>()));

            return tcs.Task;
        }
        #endregion
    }
}