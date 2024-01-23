using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPGODMM.Modelos
{
    public class Equipo
    {
        public int EQU_ID { get; set; }
        public int CAT_ID { get; set; }
        public string EQU_NOMBRE { get; set; }
        public string EQU_CODIGO { get; set; }
        public string EQU_DESCRIPCION { get; set; }
        public int EQU_TIEMPO { get; set; }
        public float EQU_COSTO { get; set; }
        public string EQU_CREA { get; set; }
        public string EQU_ACTUALIZO { get; set; }
        public DateTime EQU_FECHACREA { get; set; }
        public DateTime EQU_FECHAACTUA { get; set; }
        public bool EQU_ELIMINO { get; set; }
    }
}