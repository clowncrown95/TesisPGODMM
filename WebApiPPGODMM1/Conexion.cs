using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApiPPGODMM1
{
    public class Conexion
    {
        public Conexion() {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-EC")
            {
                DateTimeFormat = { ShortDatePattern = "dd/MM/yyyy" },
                NumberFormat =
                {
                    CurrencyDecimalSeparator = ".",
                    CurrencyGroupSeparator = ",",
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = ","
                }
            };
            
        }
        public static String GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        }
    }
}