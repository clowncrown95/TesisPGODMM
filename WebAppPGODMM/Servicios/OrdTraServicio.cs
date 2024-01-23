using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using WebAppPGODMM.Modelos;

namespace WebAppPGODMM.Servicios
{
    public class OrdTraServicio : ClienteBase
    {
        public List<OrdTra> FindAllOrdTra()
        {
            List<OrdTra> resultado = new List<OrdTra>();
            try
            {
                var Uri = url + "/api/OrdenTrabajo/SelectAll";
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<List<OrdTra>>(PlacesJson);
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
        public OrdTra GetOrdTra(int id)
        {
            OrdTra resultado = new OrdTra();
            try
            {
                var Uri = url + "/api/OrdenTrabajo/SelectById?ORD_ID" + id;
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<OrdTra>(PlacesJson);
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
        public int InsertOrdTra(OrdTra ordTra)
        {
            int resultado = 0;
            try
            {
                var Uri = url + "/api/OrdenTrabajo/Insert";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(ordTra);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = Client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    resultado = JsonConvert.DeserializeObject<int>(PlacesJson);
                }
                else
                {
                    // resultado diferente de 200 o succesfull
                }

            }
            catch (Exception ex)
            {
                //error
            }
            return resultado;
        }

        public bool UpdateOrdTra(OrdTra ordTra)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/api/OrdenTrabajo/Update";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(ordTra);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = Client.PutAsync(Uri, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    resultado = JsonConvert.DeserializeObject<bool>(PlacesJson);
                }
                else
                {
                    // resultado diferente de 200 o succesfull
                }

            }
            catch (Exception ex)
            {
                //error
            }
            return resultado;
        }
        public bool DeleteOrdTra(int Id, string LastModifierId, DateTime LastModified)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/api/OrdenTrabajo/Delete?ORD_ID=" + Id + "&ORD_ACTUALIZO=" + LastModifierId + "&ORD_FECHAACTUA=" + LastModified + "";
                var Client = new HttpClient();
                var response = Client.DeleteAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    resultado = JsonConvert.DeserializeObject<bool>(PlacesJson);//true o false
                }
                else
                {
                    // resultado diferente de 200 o succesfull
                }

            }
            catch (Exception ex)
            {
                //error
            }
            return resultado;
        }
    }
}