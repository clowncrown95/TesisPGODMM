using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPPGODMM1.Models
{
    public class MEstado
    {
        public int EST_ID { get; set; }
        public int ORD_ID { get; set; }
        public string EST_NOMBRE { get; set; }
        public string EST_DESCRIPCION { get; set; }
        public string EST_CREA { get; set; }
        public string EST_ACTUALIZO { get; set; }
        public DateTime EST_FECHACREA { get; set; }
        public DateTime EST_FECHAACTUA { get; set; }
        public bool EST_ELIMINO { get; set; }
    }
}