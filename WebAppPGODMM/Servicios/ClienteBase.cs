using System.Net.Http;

namespace WebAppPGODMM.Servicios
{
    public class ClienteBase
    {
        public HttpClient Client = new HttpClient();
        public string url { get; set; }
        public ClienteBase()
        {
            url = "http://localhost:51177/api";
        }
    }
}