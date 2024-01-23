using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebAppPGODMM.Modelos;

namespace WebAppPGODMM.Servicios.DtoServicio
{
    public class DtoCompartidoServicio : ClienteBase
    {
        public List<Modelos.DTOM.DTOUsuCom> FindAllUser()
        {
            List<Modelos.DTOM.DTOUsuCom> resultado = new List<Modelos.DTOM.DTOUsuCom>();
            try
            {
                var Uri = url + "/DtoCompartido/SelectAll";
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<List<Modelos.DTOM.DTOUsuCom>>(PlacesJson);
                    }
                }
                else
                {
                    //error en el servicio
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }
    }
}