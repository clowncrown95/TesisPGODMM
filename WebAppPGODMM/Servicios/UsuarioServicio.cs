using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using WebAppPGODMM.Modelos;
using Newtonsoft.Json;
using System.Text;

namespace WebAppPGODMM.Servicios
{
    public class UsuarioServicio : ClienteBase 
    {
        public List<Usuario> FindAllUser()
        {
            List<Usuario> resultado = new List<Usuario>();
            try
            {
                var Uri = url + "/Usuario/SelectAll";
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<List<Usuario>>(PlacesJson);
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
        public Usuario GetUser(int id)
        {
            Usuario resultado = new Usuario();
            try
            {
                var Uri = url + "/Usuario/SelectById?USU_ID=" + id;
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<Usuario>(PlacesJson);
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
        public int InsertUser(Usuario User)
        {
            int resultado = 0;
            try
            {
                var Uri = url + "/Usuario/Insert";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(User);
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
            catch (Exception)
            {
                //error
            }
            return resultado;
        }

        public bool UpdateUser(Usuario User)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/Usuario/Update";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(User);
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
            catch (Exception)
            {
                //error
            }
            return resultado;
        }
        public bool DeleteUser(int Id, string LastModifierId, DateTime LastModified)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/Usuario/Delete?USU_ID=" + Id + "&USU_ACTUALIZO=" + LastModifierId + "&USU_FECHAACTUA=" + LastModified + "";
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
            catch (Exception)
            {
                //error
            }
            return resultado;
        }
        public Usuario GetLoginUser(String usuario, String password)
        {
            Usuario resultado = new Usuario();
            try
            {
                var Uri = url + "/Usuario/SelectByLogin?usuario=" + usuario + "&password=" + password;
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<Usuario>(PlacesJson);
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