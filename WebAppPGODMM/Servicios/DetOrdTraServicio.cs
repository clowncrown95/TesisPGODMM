using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Web;
using WebAppPGODMM.Modelos;

namespace WebAppPGODMM.Servicios
{
    public class DetOrdTraServicio : ClienteBase
    {
        public List<DetOrdTra> FindAllDetOrdTra()
        {
            List<DetOrdTra> resultado = new List<DetOrdTra>();
            try
            {
                var Uri = url + "/api/DetalleOrdenTrabajo/SelectAll";
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<List<DetOrdTra>>(PlacesJson);
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
        public DetOrdTra GetDetOrdTra(int id)
        {
            DetOrdTra resultado = new DetOrdTra();
            try
            {
                var Uri = url + "/api/DetalleOrdenTrabajo/SelectById?DTOR_ID" + id;
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<DetOrdTra>(PlacesJson);
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
        public int InsertDetOrdTra(DetOrdTra detOrdTra)
        {
            int resultado = 0;
            try
            {
                var Uri = url + "/api/DetalleOrdenTrabajo/Insert";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(detOrdTra);
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

        public bool UpdateDetOrdTra(DetOrdTra detOrdTra)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/api/DetalleOrdenTrabajo/Update";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(detOrdTra);
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
        public bool DeleteDetOrdTra(int Id, string LastModifierId, DateTime LastModified)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/api/DetalleOrdenTrabajo/Delete?DTOR_ID=" + Id + "&DTOR_ACTUALIZO=" + LastModifierId + "&DTOR_FECHAACTUA=" + LastModified + "";
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