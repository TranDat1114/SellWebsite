using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using Newtonsoft.Json;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels.Customer;

namespace SellWebsite.Utility.Helpers
{
    public static class PaypalHelpers
    {
        public static int RunPaypalDemo()
        {
            try
            {
                Task.Run(async () =>
                {
                    HttpClient http = GetPaypalHttpClient();
                    // Step 1: Get an access token
                    PayPalAccessToken accessToken = await GetPayPalAccessTokenAsync(http);
                    //Log.Information("Access Token \n{@accessToken}", accessToken);
                    // Step 2: Create the payment
                    PayPalPaymentCreatedResponse createdPayment = await CreatePaypalPaymentAsync(http, accessToken);
                    //Log.Information("Created payment \n{@createdPayment}", createdPayment);
                    // Step 3: Get the approval_url and paste it into a browser
                    // It should look something like this: https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-97965369EL8295114
                    var approval_url = createdPayment.links.First(x => x.rel == "approval_url").href;
                    //Log.Information("approval_url\n{approval_url}", approval_url);
                    //
                    // IMPORTANT: Stop the program here, and re-run only the section below (comment out Step 2 and Step 3) and paste in the correct paymentId and payerId
                    //
                    // Step 4: When paypal redirects to the return_url, we need to grab the PayerID and the paymentId and execute the payment
                    var paymentId = "PAY-9LN814307S704373KK6UFTHI";
                    var payerId = "LMWV7AASBDUQQ";
                    PayPalPaymentExecutedResponse executedPayment = await ExecutePaypalPaymentAsync(http, accessToken, paymentId, payerId);
                    //Log.Information("Executed payment \n{@executedPayment}", executedPayment);
                }).Wait();

            }
            catch (Exception ex)
            {
                //Log.Error(ex, "Failed to login to PalPal");
                return 1;
            }

            return 0;
        }
        private static HttpClient GetPaypalHttpClient()
        {
            const string sandbox = "https://api.sandbox.paypal.com";

            var http = new HttpClient
            {
                BaseAddress = new Uri(sandbox),
                Timeout = TimeSpan.FromSeconds(30),
            };

            return http;
        }

        public static async Task<PayPalAccessToken> GetPayPalAccessTokenAsync(HttpClient http)
        {
            var clientId = "AT8NzeQwpAwOIbpxgM3K_WyB-1ZhBO_vhy8NjMqtYMOdG_k5N-R2B69d6ZCD5hGc7_qr0KHuCCI3RypZ";
            var secret = "ENpJaoAamL_KbLznSxZujPJLYWlwWjj-llowMtkLRtgbk3zGxz4GiH13hDEC4UXrVIrqsy7v1PFiOtpH";

            byte[] bytes = Encoding.GetEncoding("iso-8859-1").GetBytes($"{clientId}:{secret}");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/v1/oauth2/token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));

            var form = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials"
            };

            request.Content = new FormUrlEncodedContent(form);

            HttpResponseMessage response = await http.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            PayPalAccessToken accessToken = JsonConvert.DeserializeObject<PayPalAccessToken>(content);
            return accessToken;
        }

        public static async Task<PayPalPaymentCreatedResponse> CreatePaypalPaymentAsync(HttpClient http, PayPalAccessToken accessToken)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "v1/payments/payment");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);

            var payment = JObject.FromObject(new
            {
                intent = "sale",
                redirect_urls = new
                {
                    return_url = "https://localhost:7196/" + $"/Customer/ShoppingCart/OrderConfirmation?id=",
                    cancel_url = "https://localhost:7196/" + "Customer/ShoppingCart/Index"
                },
                payer = new { payment_method = "paypal" },
                transactions = JArray.FromObject(new[]
                {
            new
            {
                amount = new
                {
                    total = 7.47,
                    currency = "USD"
                }
            }
        })
            });

            request.Content = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await http.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            PayPalPaymentCreatedResponse paypalPaymentCreated = JsonConvert.DeserializeObject<PayPalPaymentCreatedResponse>(content);
            return paypalPaymentCreated;
        }

        public static async Task<PayPalPaymentExecutedResponse> ExecutePaypalPaymentAsync(HttpClient http, PayPalAccessToken accessToken, string paymentId, string payerId)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v1/payments/payment/{paymentId}/execute");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);

            var payment = JObject.FromObject(new
            {
                payer_id = payerId
            });

            request.Content = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await http.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            PayPalPaymentExecutedResponse executedPayment = JsonConvert.DeserializeObject<PayPalPaymentExecutedResponse>(content);
            return executedPayment;
        }
    }
}
