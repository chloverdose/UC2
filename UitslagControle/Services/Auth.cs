using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace UitslagControle.Services
{
    class Auth 
    {
        public async Task<bool> LdapAsync(string username, string password)
        {
            Uri requestUri = new Uri("https://japi.ctsgroup.nl/ctsauth/api/ldap");
            string key = "21b611ab7c2c404e63dcdac5631f880c46bd6f4618eed39423bc019629027767";

            HttpClient httpClient = new HttpClient();
            var headers = httpClient.DefaultRequestHeaders;

            headers.Authorization = new Windows.Web.Http.Headers.HttpCredentialsHeaderValue(key);
            headers.Add("Relay-Authorization-Type", "ldap");
            headers.Add("Relay-Authorization", "Basic " + StringToBase64(username, password));
            headers.Add("Relay-Authorization-App", "UC2");

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                return true;
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                return false;
            }
        }

        static private string StringToBase64(string username, string password)
        {
            string toConvert = username + ":" + password;
            var bytes = Encoding.UTF8.GetBytes(toConvert);
            return Convert.ToBase64String(bytes);
        }
    }
}
