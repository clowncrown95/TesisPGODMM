﻿using Newtonsoft.Json;
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
    public class RolServicio : ClienteBase
    {
        public List<Rol> FindAllRol()
        {
            List<Rol> resultado = new List<Rol>();
            try
            {
                var Uri = url + "/api/Rol/SelectAll";
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<List<Rol>>(PlacesJson);
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
        public Rol GetRol(int id)
        {
            Rol resultado = new Rol();
            try
            {
                var Uri = url + "/api/Rol/SelectById?ROL_ID" + id;
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<Rol>(PlacesJson);
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
        public int InsertRol(Rol rol)
        {
            int resultado = 0;
            try
            {
                var Uri = url + "/api/Rol/Insert";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(rol);
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

        public bool UpdateRol(Rol rol)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/api/Rol/Update";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(rol);
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
        public bool DeleteRol(int Id, string LastModifierId, DateTime LastModified)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/api/Rol/Delete?ROL_ID=" + Id + "&ROL_ACTUALIZO=" + LastModifierId + "&ROL_FECHAACTUA=" + LastModified + "";
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