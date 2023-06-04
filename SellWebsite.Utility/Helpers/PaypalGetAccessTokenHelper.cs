using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PayPal.Api;

namespace SellWebsite.Utility.Helpers
{
    public static class PaypalGetAccessTokenHelper
    {

        public static Dictionary<string, string> GetConfig(string mode)
        {
            return new Dictionary<string, string>()
            {
                {"mode", mode }
            };
        }

        private static string GetAccessToken(PaypalSettings paypalSettings)
        {
            string accessToken = new OAuthTokenCredential(paypalSettings.ClientId, paypalSettings.Secret, GetConfig(paypalSettings.Mode)).GetAccessToken();

            return accessToken;
        }

        public static APIContext GetAPIContext(PaypalSettings paypalSettings)
        {
            var apiContext = new APIContext(GetAccessToken(paypalSettings));
            apiContext.Config = GetConfig(paypalSettings.Mode);
            return apiContext;
        }
    }
}
