using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.System;
using UitslagControle.Services;

namespace UitslagControle.Services
{
    class Logging
    {
        public async Task StartSessionAsync()
        {
            JsonObject ob = new JsonObject
            {
                { "actie", JsonValue.Parse("create") },
                { "typeEnv", JsonValue.Parse("live") },
                { "origin_application", JsonValue.Parse("UCtool") },
                { "origin_server", JsonValue.Parse("nvt") },
                { "origin_database", JsonValue.Parse("nvt") },
                { "origin_agentName", JsonValue.Parse("sessie") },
                { "origin_user", JsonValue.Parse(KnownUserProperties.AccountName) },
                { "body", JsonValue.Parse(DateTime.Now.ToString("HH:mm:ss") + " > " + "Inlog actie<br>") },
                { "shortMessage", JsonValue.Parse("2") },
                { "meta_error_severity", JsonValue.Parse("0") }
            };

            string postString = ob.ToString();
            Uri uri = new Uri("http://domino.ctsgroup.nl:82/webintern/logservices.nsf/logService.xsp");
            Network net = new Network();

            await net.HttpPostAsync(uri, postString);
        }
    }
}
