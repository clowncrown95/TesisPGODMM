using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebAppPGODMM.Modelos;

namespace WebAppPGODMM.Servicios
{
    public class CargoServicio : ClienteBase
    {
        public List<Cargo> FindAllCargo()
        {
            List<Cargo> resultado = new List<Cargo>();
            try
            {
                var Uri = url + "/Cargo/SelectAll";
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<List<Cargo>>(PlacesJson);
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
        public Cargo GetCargo(int id)
        {
            Cargo resultado = new Cargo();
            try
            {
                var Uri = url + "/Cargo/SelectById?Id=" + id;
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<Cargo>(PlacesJson);
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
        public int InsertCargo(Cargo cargo)
        {
            int resultado = 0;
            try
            {
                var Uri = url + "/Cargo/Insert";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(cargo);
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

        public bool UpdateCargo(Cargo cargo)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/Cargo/Update";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(cargo);
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
        public bool DeleteCargo(int Id, string LastModifierId, DateTime LastModified)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/Cargo/Delete?Id=" + Id + "&Usuario=" + LastModifierId + "&Fecha=" + LastModified + "";
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