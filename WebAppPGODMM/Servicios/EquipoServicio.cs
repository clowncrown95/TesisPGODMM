using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebAppPGODMM.Modelos;

namespace WebAppPGODMM.Servicios
{
    public class EquipoServicio : ClienteBase
    {
        public List<Equipo> FindAllEquipo()
        {
            List<Equipo> resultado = new List<Equipo>();
            try
            {
                var Uri = url + "/Equipo/SelectAll";
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<List<Equipo>>(PlacesJson);
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

        public List<Equipo> FindListEquipo()
        {
            List<Equipo> resultado = new List<Equipo>();
            try
            {
                var Uri = url + "/Equipo/SelectList";
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<List<Equipo>>(PlacesJson);
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

        public Equipo GetEquipo(int id)
        {
            Equipo resultado = new Equipo();
            try
            {
                var Uri = url + "/Equipo/SelectById?Id=" + id;
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<Equipo>(PlacesJson);
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
        public int InsertEquipo(Equipo equipo)
        {
            int resultado = 0;
            try
            {
                var Uri = url + "/Equipo/Insert";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(equipo);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = Client.PostAsync(Uri, content).Result;
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

        public bool UpdateEquipo(Equipo equipo)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/Equipo/Update";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(equipo);
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
        public bool DeleteEquipo(int Id, string LastModifierId, DateTime LastModified)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/Equipo/Delete?Id=" + Id + "&Usuario=" + LastModifierId + "&Fecha=" + LastModified + "";
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