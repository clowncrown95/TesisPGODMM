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
    public class RTecnicoServicio : ClienteBase
    {
        public List<RTecnico> FindAllRTecnico()
        {
            List<RTecnico> resultado = new List<RTecnico>();
            try
            {
                var Uri = url + "/api/RTecnico/SelectAll";
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<List<RTecnico>>(PlacesJson);
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
        public RTecnico GetRTecnico(int id)
        {
            RTecnico resultado = new RTecnico();
            try
            {
                var Uri = url + "/api/RTecnico/SelectById?RTEC_ID" + id;
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<RTecnico>(PlacesJson);
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
        public int InsertRTecnico(RTecnico rTecnico)
        {
            int resultado = 0;
            try
            {
                var Uri = url + "/api/RTecnico/Insert";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(rTecnico);
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

        public bool UpdateRTecnico(RTecnico rTecnico)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/api/RTecnico/Update";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(rTecnico);
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
        public bool DeleteRTecnico(int Id, string LastModifierId, DateTime LastModified)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/api/RTecnico/Delete?RTEC_ID=" + Id + "&RTEC_ACTUALIZO=" + LastModifierId + "&RTEC_FECHAACTUA=" + LastModified + "";
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