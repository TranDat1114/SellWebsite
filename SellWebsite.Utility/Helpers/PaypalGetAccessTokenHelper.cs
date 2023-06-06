using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using PayPal.Api;

using SellWebsite.Models.Models;

namespace SellWebsite.Utility.Helpers
{
    public static class PaypalGetAccessTokenHelper
    {
        public static HttpClient GetPaypalHttpClient()
        {
            const string sandbox = "https://api.sandbox.paypal.com";

            var http = new HttpClient
            {
                BaseAddress = new Uri(sandbox),
                Timeout = TimeSpan.FromSeconds(30),
            };

            return http;
        }

        public static async Task<PayPalAccessToken> GetPayPalAccessTokenAsync(PaypalSettings paypalSettings)
        {
            var httpUri = GetPaypalHttpClient();
            var clientId = paypalSettings.ClientId; // client id của bạn
            var secret = paypalSettings.Secret; //secret key của bạn

            byte[] bytes = Encoding.GetEncoding("iso-8859-1").GetBytes($"{clientId}:{secret}");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/v1/oauth2/token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));

            var form = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials"
            };

            request.Content = new FormUrlEncodedContent(form);

            HttpResponseMessage response = await httpUri.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            PayPalAccessToken accessToken = JsonConvert.DeserializeObject<PayPalAccessToken>(content);
            return accessToken;
        }


       
    }
}
