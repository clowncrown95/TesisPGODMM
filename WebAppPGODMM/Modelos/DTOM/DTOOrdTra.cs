using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPGODMM.Modelos.DTOM
{
    public class DTOOrdTra
    {
        public int ORD_ID { get; set; }
        public int USU_USUARIO { get; set; }
        public int LOC_NOMBRE { get; set; }
        public string EST_NOMBRE { get; set; }
        public DateTime ORD_FECHAINI { get; set; }
        public DateTime ORD_FECHAFIN { get; set; }
        public int ORD_NUMERO { get; set; }
        public int EQU_NOMBRE { get; set; }
        public string DTOR_DETALLE { get; set; }
        public string RTEC_DESCRIPCION { get; set; }
        public string RTEC_RESPALDO { get; set; }
        public float RTEC_COSTO { get; set; }
        public string RTEC_FIRMA { get; set; }
    }
}