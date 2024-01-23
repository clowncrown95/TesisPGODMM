using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPGODMM.Modelos
{
    public class RTecnico
    {
        public int RTEC_ID { get; set; }
        public int DTOR_ID { get; set; }
        public string RTEC_DESCRIPCION { get; set; }
        public string RTEC_RESPALDO { get; set; }
        public float RTEC_COSTO { get; set; }
        public string RTEC_FIRMA { get; set; }
        public string RTEC_CREO { get; set; }
        public string RTEC_ACTUALIZO { get; set; }
        public DateTime RTEC_FECHACREO { get; set; }
        public DateTime RTEC_FECHAACTUA { get; set; }
        public bool RTEC_ELIMINO { get; set; }
    }
}