using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPGODMM.Modelos
{
    public class DetOrdTra
    {
        public int DTOR_ID { get; set; }
        public int ORD_ID { get; set; }
        public int RTEC_ID { get; set; }
        public int EQU_ID { get; set; }
        public string DTOR_DETALLE { get; set; }
        public string DTOR_CREA { get; set; }
        public string DTOR_ACTUALIZO { get; set; }
        public DateTime DTOR_FECHACREA { get; set; }
        public DateTime DTOR_FECHAACTUA { get; set; }
        public bool DTOR_ELIMINO { get; set; }
    }
}