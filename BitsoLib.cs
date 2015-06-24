#region
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using bscheiman.Common.Extensions;
using Bitso.Objects.Requests;
using Bitso.Objects.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp.Portable;

#endregion

namespace Bitso {
    public class BitsoLib {
        private const string BaseUrl = "https://api.bitso.com/v2/";
        public string ApiSecret { get; set; }
        public string ApiUser { get; set; }
        public int ClientId { get; set; }

        public BitsoLib(int clientId, string apiUser, string apiSecret) {
            clientId.ThrowIf(clientId <= 0, "Invalid clientId", "clientId");
            apiUser.ThrowIfNullOrEmpty("apiUser");
            apiSecret.ThrowIfNullOrEmpty("apiSecret");

            ClientId = clientId;
            ApiUser = apiUser;
            ApiSecret = apiSecret;
        }

        //test
        public Task<Dictionary<string, object>> BuyLimitOrderAsync(string book = "btc_mxn", decimal amount = 0M, decimal price = 0M) {
            book.ThrowIfNullOrEmpty("book");
            amount.ThrowIf(amount < 0, "Invalid amount", "amount");
            price.ThrowIf(price < 0, "Invalid price", "price");

            return PostAsync<Dictionary<string, object>>("buy", new BuyLimitOrderRequest {
                Book = book,
                Amount = amount,
                Price = price
            });
        }

        //test
        public Task<Dictionary<string, object>> BuyMarketOrderAsync(string book = "btc_mxn", decimal amount = 0M) {
            book.ThrowIfNullOrEmpty("book");
            amount.ThrowIf(amount < 0, "Invalid amount", "amount");

            return PostAsync<Dictionary<string, object>>("buy", new BuyMarketOrderRequest {
                Book = book,
                Amount = amount
            });
        }

        //test
        public Task<Dictionary<string, object>> CancelOrderAsync(string id) {
            id.ThrowIfNullOrEmpty("id");

            return PostAsync<Dictionary<string, object>>("cancel_order", new CancelOrderRequest {
                Id = id
            });
        }

        public Task<CreateTransfer> CreateBankWireTransferQuoteAsync(TransferQuote quote, string fullName, string accountNumber, string holderAddress,
                                                                     string bankAddress, string swift, string otherInstructions) {
            quote.ThrowIfNull("quote");
            quote.Quote.ThrowIfNull("quote.Quote");
            quote.Quote.Gross.ThrowIf(quote.Quote.Gross < 0, "Invalid amount", "quote.Quote.Gross");
            quote.Quote.Gross.ThrowIf(quote.Quote.Rate < 0, "Invalid rate", "quote.Quote.Rate");
            quote.Quote.Currency.ThrowIfNullOrEmpty("quote.Quote.Currency");
            fullName.ThrowIfNullOrEmpty("fullName");
            accountNumber.ThrowIfNullOrEmpty("accountNumber");
            holderAddress.ThrowIfNullOrEmpty("holderAddress");
            bankAddress.ThrowIfNullOrEmpty("bankAddress");
            swift.ThrowIfNullOrEmpty("swift");

            return CreateTransferQuoteAsync(quote, new BankWireCreateQuoteRequest {
                Amount = quote.Quote.Gross,
                Currency = quote.Quote.Currency,
                Rate = quote.Quote.Rate,
                PaymentOutlet = "bw",
                AccountHolderAddress = holderAddress,
                AccountNumber = accountNumber,
                BankAddress = bankAddress,
                OtherInstructions = otherInstructions,
                RecipientFullName = fullName,
                Swift = swift
            });
        }

        public Task<CreateTransfer> CreatePadeMobileTransferQuoteAsync(TransferQuote quote, string phoneNumber) {
            quote.ThrowIfNull("quote");
            quote.Quote.ThrowIfNull("quote.Quote");
            quote.Quote.Gross.ThrowIf(quote.Quote.Gross < 0, "Invalid amount", "quote.Quote.Gross");
            quote.Quote.Gross.ThrowIf(quote.Quote.Rate < 0, "Invalid rate", "quote.Quote.Rate");
            quote.Quote.Currency.ThrowIfNullOrEmpty("quote.Quote.Currency");
            phoneNumber.ThrowIfNullOrEmpty("phoneNumber");

            return CreateTransferQuoteAsync(quote, new PadeMobileCreateQuoteRequest {
                Amount = quote.Quote.Gross,
                Currency = quote.Quote.Currency,
                Rate = quote.Quote.Rate,
                PaymentOutlet = "pm",
                PhoneNumber = phoneNumber
            });
        }

        public Task<CreateTransfer> CreateRippleTransferQuoteAsync(TransferQuote quote, string rippleAddress) {
            quote.ThrowIfNull("quote");
            quote.Quote.ThrowIfNull("quote.Quote");
            quote.Quote.Gross.ThrowIf(quote.Quote.Gross < 0, "Invalid amount", "quote.Quote.Gross");
            quote.Quote.Gross.ThrowIf(quote.Quote.Rate < 0, "Invalid rate", "quote.Quote.Rate");
            quote.Quote.Currency.ThrowIfNullOrEmpty("quote.Quote.Currency");
            rippleAddress.ThrowIfNullOrEmpty("rippleAddress");

            return CreateTransferQuoteAsync(quote, new RippleCreateQuoteRequest {
                Amount = quote.Quote.Gross,
                Currency = quote.Quote.Currency,
                Rate = quote.Quote.Rate,
                PaymentOutlet = "rp",
                RippleAddress = rippleAddress
            });
        }

        public Task<CreateTransfer> CreateSpeiTransferQuoteAsync(TransferQuote quote, string givenName, string familyNames, string bankName,
                                                                 string clabe) {
            quote.ThrowIfNull("quote");
            quote.Quote.ThrowIfNull("quote.Quote");
            quote.Quote.Gross.ThrowIf(quote.Quote.Gross < 0, "Invalid amount", "quote.Quote.Gross");
            quote.Quote.Gross.ThrowIf(quote.Quote.Rate < 0, "Invalid rate", "quote.Quote.Rate");
            quote.Quote.Currency.ThrowIfNullOrEmpty("quote.Quote.Currency");
            givenName.ThrowIfNullOrEmpty("givenName");
            familyNames.ThrowIfNullOrEmpty("familyNames");
            bankName.ThrowIfNullOrEmpty("bankName");
            clabe.ThrowIfNullOrEmpty("clabe");
            clabe.ThrowIf(clabe.Length != 18, "Invalid CLABE length", "clabe");

            return CreateTransferQuoteAsync(quote, new SpeiCreateQuoteRequest {
                Amount = quote.Quote.Gross,
                Currency = quote.Quote.Currency,
                Rate = quote.Quote.Rate,
                PaymentOutlet = "sp",
                RecipientGivenNames = givenName,
                RecipientFamilyNames = familyNames,
                BankName = bankName,
                Clabe = clabe
            });
        }

        public Task<CreateTransfer> CreateVoucherTransferQuoteAsync(TransferQuote quote, string email, string givenName) {
            quote.ThrowIfNull("quote");
            quote.Quote.ThrowIfNull("quote.Quote");
            quote.Quote.Gross.ThrowIf(quote.Quote.Gross < 0, "Invalid amount", "quote.Quote.Gross");
            quote.Quote.Gross.ThrowIf(quote.Quote.Rate < 0, "Invalid rate", "quote.Quote.Rate");
            quote.Quote.Currency.ThrowIfNullOrEmpty("quote.Quote.Currency");
            email.ThrowIfNullOrEmpty("email");
            givenName.ThrowIfNullOrEmpty("givenName");

            return CreateTransferQuoteAsync(quote, new VoucherCreateQuoteRequest {
                Amount = quote.Quote.Gross,
                Currency = quote.Quote.Currency,
                Rate = quote.Quote.Rate,
                PaymentOutlet = "vo",
                EmailAddress = email,
                RecipientGivenName = givenName
            });
        }

        //test
        public Task<Dictionary<string, object>> DepositBitcoinAsync(string id) {
            id.ThrowIfNullOrEmpty("id");

            return PostAsync<Dictionary<string, object>>("bitcoin_deposit_address", new BasePostObject());
        }

        public Task<Balance> GetBalanceAsync() {
            return PostAsync<Balance>("balance", new BasePostObject());
        }

        //test
        public Task<Dictionary<string, object>> GetOpenOrdersAsync(string book = "btc_mxn") {
            book.ThrowIfNullOrEmpty("book");

            return PostAsync<Dictionary<string, object>>("open_orders", new OpenOrdersRequest {
                Book = book
            });
        }

        public Task<OrderBook> GetOrderBookAsync() {
            return GetAsync<OrderBook>("order_book");
        }

        public Task<Ticker> GetTickerAsync(string book = "btc_mxn") {
            book.ThrowIfNullOrEmpty("book");

            return GetAsync<Ticker>("ticker", null, new Parameter {
                Name = "book",
                Value = book,
                Type = ParameterType.QueryString
            });
        }

        public Task<List<Transaction>> GetTransactionsAsync(string book = "btc_mxn", bool perHour = true) {
            book.ThrowIfNullOrEmpty("book");

            return GetAsync<List<Transaction>>("transactions", null, new Parameter {
                Name = "book",
                Value = book,
                Type = ParameterType.QueryString
            }, new Parameter {
                Name = "time",
                Value = perHour ? "hour" : "minute",
                Type = ParameterType.QueryString
            });
        }

        public Task<TransferQuote> GetTransferQuoteAsync(decimal amount, string currency = "MXN", bool showFull = false) {
            currency.ThrowIfNullOrEmpty("currency");
            amount.ThrowIf(amount < 0, "Invalid currency", "amount");

            return PostAsync<TransferQuote>("transfer_quote", new TransferQuoteRequest {
                Amount = amount,
                Currency = currency,
                Full = showFull
            });
        }

        //test
        public Task<Dictionary<string, object>> GetUserTransactionsAsync(string book = "btc_mxn", int offset = 0, int limit = 100,
                                                                         Sort sort = Sort.Desc) {
            book.ThrowIfNullOrEmpty("book");
            offset.ThrowIf(offset < 0, "Invalid offset", "offset");
            limit.ThrowIf(limit > 100 || limit < 0, "Invalid limit", "limit");

            return PostAsync<Dictionary<string, object>>("user_transactions", new UserTransactionsRequest {
                Book = book,
                Offset = offset,
                Limit = limit,
                Sort = sort
            });
        }

        public Task<CreateTransfer> ReviewTransferAsync(CreateTransfer transfer) {
            transfer.ThrowIfNull("transfer");
            transfer.Order.ThrowIfNull("transfer.Order");
            transfer.Order.Id.ThrowIfNullOrEmpty("transfer.Order.Id");

            return GetAsync<CreateTransfer>("transfer/{txId}", null, new Parameter {
                Name = "txId",
                Value = transfer.Order.Id,
                Type = ParameterType.UrlSegment
            });
        }

        //test
        public Task<Dictionary<string, object>> RippleWithdrawAsync(string currency, decimal amount, string address) {
            currency.ThrowIfNullOrEmpty("currency");
            address.ThrowIfNullOrEmpty("address");
            amount.ThrowIf(amount < 0, "Invalid amount", "amount");

            return PostAsync<Dictionary<string, object>>("ripple_withdrawal", new RippleWithdrawRequest {
                Currency = currency,
                Amount = amount,
                Address = address
            });
        }

        //test
        public Task<Dictionary<string, object>> SellLimitOrderAsync(string book, decimal amount, decimal price) {
            book.ThrowIfNullOrEmpty("book");
            amount.ThrowIf(amount < 0, "Invalid amount", "amount");
            price.ThrowIf(price < 0, "Invalid price", "price");

            return PostAsync<Dictionary<string, object>>("sell", new SellLimitOrderRequest {
                Book = book
            });
        }

        //test
        public Task<Dictionary<string, object>> SellMarketOrderAsync(string book, decimal amount) {
            book.ThrowIfNullOrEmpty("book");
            amount.ThrowIf(amount < 0, "Invalid amount", "amount");

            return PostAsync<Dictionary<string, object>>("sell", new SellMarketOrderRequest {
                Book = book,
                Amount = amount
            });
        }

        //test
        public Task<Dictionary<string, object>> WithdrawBitcoinAsync(string address, decimal amount) {
            address.ThrowIfNullOrEmpty("address");
            amount.ThrowIf(amount < 0, "Invalid amount", "amount");

            return PostAsync<Dictionary<string, object>>("bitcoin_withdrawal", new WithdrawBitcoinRequest {
                Address = address,
                Amount = amount
            });
        }

        internal Task<CreateTransfer> CreateTransferQuoteAsync(TransferQuote quote, BaseCreateQuoteRequest request) {
            return PostAsync<CreateTransfer>("transfer_create", request);
        }

        #region Helpers
        internal async Task<T> DeleteAsync<T>(string url, params Parameter[] parameters) where T : new() {
            return await Send<T>(url, HttpMethod.Delete, null, parameters);
        }

        private async Task<T> Send<T>(string url, HttpMethod method, BasePostObject obj, params Parameter[] parameters) where T : new() {
            var client = GetClient(url);
            var jsonSettings = new JsonSerializerSettings {
                Error = delegate(object sender, ErrorEventArgs args) { args.ErrorContext.Handled = true; }
            };

            if (obj != null)
                obj.Setup(ApiUser, ClientId, ApiSecret);

            var response = await client.Execute(GetRequest(url, method, obj, parameters));

            return JsonConvert.DeserializeObject<T>(GetString(response.RawBytes), jsonSettings);
        }

        internal async Task<T> GetAsync<T>(string url, BasePostObject obj = null, params Parameter[] parameters) where T : new() {
            return await Send<T>(url, HttpMethod.Get, obj, parameters);
        }

        internal RestClient GetClient(string url) {
            return new RestClient(BaseUrl);
        }

        internal RestRequest GetRequest(string url, HttpMethod method, BasePostObject obj, params Parameter[] parameters) {
            var request = new RestRequest(url, method);

            foreach (var p in parameters)
                request.AddParameter(p);

            if (obj != null)
                request.AddBody(obj);

            return request;
        }

        internal async Task<T> PostAsync<T>(string url, BasePostObject obj, params Parameter[] parameters) where T : new() {
            return await Send<T>(url, HttpMethod.Post, obj, parameters);
        }

        private string GetString(byte[] bytes) {
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        internal async Task<T> PutAsync<T>(string url, BasePostObject obj, params Parameter[] parameters) where T : new() {
            return await Send<T>(url, HttpMethod.Put, obj, parameters);
        }
        #endregion
    }
}