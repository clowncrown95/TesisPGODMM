using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

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