using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace UitslagControle.Services
{
    class Network
    {
        readonly string BaseUrl = "http://domino.ctsgroup.nl:82/webintern/webservices.nsf/";
        readonly string typeEnv = "live";
        readonly string kewillEnv = "2";
        readonly string skipEU = "false";

        public async Task<string> HttpGetAsync(Uri url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(url);
                httpResponse.EnsureSuccessStatusCode();
                return await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
        }

        public Task<string> HttpPostAsync(Uri url)
        {
            throw new NotImplementedException();
        }

        public Task<string> HttpPostAsync(Uri url, String body)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetProfileValuesAsync(String username)
        {
            Uri url = new Uri(BaseUrl + "UCT_getProfileValues.xsp?user=" + username + "&typeEnv=" + typeEnv);
            return await HttpGetAsync(url);
        }

        public async Task<string> PostChangeWeegschaalAsync(String username, String weegschaal)
        {
            Uri url = new Uri(BaseUrl + "UCT_changeWeegschaal.xsp?user=" + username +
                "&weegschaal=" + weegschaal + "&typeEnv=" + typeEnv);
            return await HttpPostAsync(url);
        }

        public async Task<string> PostPrintBackingcardsAsync(String dossiernummer, String printer)
        {
            Uri url = new Uri(BaseUrl + "UCT_printBackingcards.xsp?dosvlg=" + dossiernummer +
                "&typeEnv=" + typeEnv + "&printer=" + printer);
            return await HttpPostAsync(url);
        }

        public async Task<string> PostAfrondenAsync(String dossiernummer, String username, String printer, String transporter, String opdrachtgever)
        {
            Uri url = new Uri(BaseUrl + "UCT_afronden.xsp?dosvlg=" + dossiernummer + "&typeEnv=" + typeEnv + "&user=" + username +
                "&printer=" + printer + "&transporter=" + transporter + "&tsmopdRnropd=" + opdrachtgever);
            return await HttpGetAsync(url);
        }

        public async Task<string> PostReopenFileDataAsync(String dossiernummer)
        {
            Uri url = new Uri(BaseUrl + "UCT_reopenFileData.xsp?dosvlg=" + dossiernummer + "&typeEnv=" + typeEnv);
            return await HttpGetAsync(url);
        }

        public async Task<string> GetTransporterAsync(String opdrachtgever, String collisoort, String country, String stad, String aantal)
        {
            Uri url = new Uri(BaseUrl + "UCT_getTransporter.xsp?zoek=" + opdrachtgever + "&cont=" +
                collisoort + "&country=" + country + "&plaats=" + stad + "&inputTextAantal=" + aantal);
            return await HttpGetAsync(url);
        }

        public async Task<string> PostPrintExtraDocumentsAsync(String dossiernummer, String printer, String referentie, String opdrachtgever)
        {
            Uri url = new Uri(BaseUrl + "UCT_printExtraDocuments.xsp?dosvlg=" + dossiernummer + "&typeEnv=" +
                typeEnv + "&printer=" + printer + "&ref=" + referentie + "&rnropd=" + opdrachtgever);
            return await HttpPostAsync(url);
        }

        public async Task<string> PostCreatePakbonAsync(String dossiernummer, String printer)
        {
            Uri url = new Uri(BaseUrl + "UCT_createPakbon.xsp?dosvlg=" + dossiernummer +
                "&typeEnv=" + typeEnv + "&printer=" + printer);
            return await HttpPostAsync(url);
        }

        public async Task<string> GetCreatePakbonAsync(String dossiernummer)
        {
            Uri url = new Uri(BaseUrl + "UCT_createPakbon.xsp?dosvlg=" + dossiernummer +
                "&typeEnv=" + typeEnv + "&printer=Open%20PDF");
            return await HttpGetAsync(url);
        }

        public async Task<string> PostSaveFileDataAsync(String dossiernummer, String action, String body)
        {
            Uri url = new Uri(BaseUrl + "UCT_saveFileData.xsp?dosvlg=" + dossiernummer +
                "&typeEnv=" + typeEnv + "&action=" + action);
            return await HttpPostAsync(url, body);
        }

        public async Task<string> GetFileDataKewillAsync(String dossiernummer)
        {
            Uri url = new Uri(BaseUrl + "UCT_getFileDataKewill.xsp?dosvlg=" +
                dossiernummer + "&typeEnv=" + typeEnv + "&kewillEnv=" + kewillEnv);
            return await HttpGetAsync(url);
        }

        public async Task<string> PostCreateInvoiceAsync(String dossiernummer, String printer)
        {
            Uri url = new Uri(BaseUrl + "UCT_createInvoice.xsp?dosvlg=" + dossiernummer +
                "&typeEnv=" + typeEnv + "&printer=" + printer + "&skipEU=" + skipEU);
            return await HttpPostAsync(url);
        }

        public async Task<string> GetCreateInvoiceAsync(String dossiernummer)
        {
            Uri url = new Uri(BaseUrl + "UCT_createInvoice.xsp?dosvlg=" + dossiernummer +
                "&typeEnv=" + typeEnv + "&printer=Open%20PDF&skipEU=" + skipEU);
            return await HttpGetAsync(url);
        }

        public async Task<string> PostDeleteFileDataAsync(String dossiernummer)
        {
            Uri url = new Uri(BaseUrl + "UCT_deleteFileData.xsp?dosvlg=" + dossiernummer + "&typeEnv=" + typeEnv);
            return await HttpPostAsync(url);
        }

        public async Task<string> PostReprintLabelAsync(String dossiernummer, String printer)
        {
            Uri url = new Uri(BaseUrl + "UCT_reprintLabel.xsp?dosvlg=" +
                dossiernummer + "&typeEnv=" + typeEnv + "&printer=" + printer);
            return await HttpPostAsync(url);
        }

        public async Task<string> GetReprintLabelAsync(String dossiernummer)
        {
            Uri url = new Uri(BaseUrl + "UCT_reprintLabel.xsp?dosvlg=" +
                dossiernummer + "&typeEnv=" + typeEnv + "&printer=Open%20PDF");
            return await HttpGetAsync(url);
        }

        public async Task<string> PostRegisterWithTransporterAsync(String dossiernummer, String printer, String transporter, String opdrachtgever)
        {
            Uri url = new Uri(BaseUrl + "UCT_registerWithTransporter.xsp?dosvlg=" + dossiernummer +
                "&typeEnv=" + typeEnv + "&printer=" + printer + "&transporter=" + transporter + "&tsmopdRnropd=" + opdrachtgever);
            return await HttpPostAsync(url);
        }

        public async Task<string> GetRegisterWithTransporterAsync(String dossiernummer, String transporter, String opdrachtgever)
        {
            Uri url = new Uri(BaseUrl + "UCT_registerWithTransporter.xsp?dosvlg=" + dossiernummer + "&typeEnv=" +
                typeEnv + "&printer=Open%20PDF&transporter=" + transporter + "&tsmopdRnropd=" + opdrachtgever);
            return await HttpGetAsync(url);
        }

        public async Task<string> PostChangeTemplatesAsync(String username, String action)
        {
            Uri url = new Uri(BaseUrl + "UCT_changeTemplates.xsp?user=" + username + "&templates=" + action + "&typeEnv=" + typeEnv);
            return await HttpPostAsync(url);
        }

        public async Task<string> PostChangePrinterAsync(String username, String printer)
        {
            Uri url = new Uri(BaseUrl + "UCT_changePrinter.xsp?user=" + username + "&printer=" + printer + "&typeEnv=" + typeEnv);
            return await HttpPostAsync(url);
        }

        public async Task<string> PostPrintStaticDocumentsAsync(String dossiernummer, String printer)
        {
            Uri url = new Uri(BaseUrl + "UCT_printStaticDocuments.xsp?dosvlg=" +
                dossiernummer + "&typeEnv=live&printer=" + printer);
            return await HttpPostAsync(url);
        }

        public async Task<string> GetPrintStaticDocumentsAsync(String dossiernummer)
        {
            Uri url = new Uri(BaseUrl + "UCT_printStaticDocuments.xsp?dosvlg=" +
                dossiernummer + "&typeEnv=" + typeEnv + "&printer=Open%20PDF");
            return await HttpGetAsync(url);
        }
    }
}
