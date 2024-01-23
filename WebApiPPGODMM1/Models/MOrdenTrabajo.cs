using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPPGODMM1.Models
{
    public class MOrdenTrabajo
    {
        public int ORD_ID { get; set; }
        public int USU_ID { get; set; }
        public int LOC_ID { get; set; }
        public DateTime ORD_FECHAINI { get; set; }
        public DateTime ORD_FECHAFIN { get; set; }
        public int ORD_NUMERO { get; set; }
        public string ORD_CREO { get; set; }
        public string ORD_ACTUALIZO { get; set; }
        public DateTime ORD_FECHACREO { get; set; }
        public DateTime ORD_FECHAACTUA { get; set; }
        public bool ORD_ELIMINO { get; set; }
    }
}