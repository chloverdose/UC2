using System;
using Windows.Web.Http;
using System.Threading.Tasks;
using GSF.Security;

namespace UitslagControle2.Services
{
    class Webservice
    {
        public static bool AuthLDAP(string username, string password)
        {
            try
            {
                LdapSecurityProvider sec = new LdapSecurityProvider(username + "@ctsgroup.nl");
                sec.Initialize();
                sec.Authenticate(password);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> Get(string url)
        {
            //Create an HTTP client object
            HttpClient httpClient = new HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            Uri requestUri = new Uri(url);

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return httpResponseBody;
        }

        public async Task<string> Send(string url, string data)
        {
            //byte[] postBytes = Encoding.ASCII.GetBytes(data);

            //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //webRequest.Method = "POST";
            //webRequest.ContentType = "application/json";
            //webRequest.ContentLength = postBytes.Length;

            //Stream postStream = webRequest.GetRequestStream();
            //postStream.Write(postBytes, 0, postBytes.Length);
            //postStream.Close();

            //HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            //Stream responseStream = webResponse.GetResponseStream();
            //StreamReader responseStreamReader = new StreamReader(responseStream);

            //string response = await(responseStreamReader.ReadToEnd());

            //webResponse.Close();
            //responseStream.Close();
            //responseStreamReader.Close();

            return null;
        }
    }
}
