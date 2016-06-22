using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Configuration;

namespace DexCMS.Base.Mvc.Models
{
    public class ReCaptcha
    {
        public static bool IsValid(HttpRequestBase request)
        {
            string encodedResponse = request.Form["g-Recaptcha-Response"];
            var client = new System.Net.WebClient();
            string PrivateKey = WebConfigurationManager.AppSettings["ReCaptchaPrivateKey"];
            var GoogleReply = client.DownloadString(
                string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", 
                PrivateKey, encodedResponse));
            ReCaptcha captchaResponse = JsonConvert.DeserializeObject<ReCaptcha>(GoogleReply);
            return captchaResponse.Success.ToLower() == "true";
        }

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private string m_Success;
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }


        private List<string> m_ErrorCodes;
    }
}
