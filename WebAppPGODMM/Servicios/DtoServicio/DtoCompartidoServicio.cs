using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using WebAppPGODMM.Modelos;
using WebAppPGODMM.Modelos.DTOM;

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
        public List<Modelos.DTOM.DTOPerCom> FindAllPersonas()
        {
            List<Modelos.DTOM.DTOPerCom> resultado = new List<Modelos.DTOM.DTOPerCom>();
            try
            {
                var Uri = url + "/DtoCompartido/SelectAllPercom";
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<List<Modelos.DTOM.DTOPerCom>>(PlacesJson);
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

        public List<Modelos.DTOM.DTOOrdTra> FindAllOrder()
        {
            List<Modelos.DTOM.DTOOrdTra> resultado = new List<Modelos.DTOM.DTOOrdTra>();
            try
            {
                var Uri = url + "/DtoCompartido/SelectAllOrder";
                HttpResponseMessage response = Client.GetAsync(Uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string PlacesJson = response.Content.ReadAsStringAsync().Result;
                    if (PlacesJson.Length > 0)
                    {
                        resultado = JsonConvert.DeserializeObject<List<Modelos.DTOM.DTOOrdTra>>(PlacesJson);
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
        public OrdTra GetOT(int id)
        {
            OrdTra resultado = new OrdTra();
            try
            {
                var Uri = url + "/DtoCompartido/SelectById?Id=" + id;
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
        public int InsertOT(OrdTra ordTra)
        {
            int resultado = 0;
            try
            {
                var Uri = url + "/DtoCompartido/Insert";
                var Client = new HttpClient();
                var data = JsonConvert.SerializeObject(ordTra);
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

        public bool UpdateOT(OrdTra ordTra)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/DtoCompartido/Update";
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
        public bool DeleteDTOOT(int Id)
        {
            bool resultado = false;
            try
            {
                var Uri = url + "/DtoCompartido/Delete?Id=" + Id + "";
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