using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPGODMM.Modelos
{
    public class Categoria
    {
        public int CAT_ID { get; set; }
        public string CAT_NOMBRE { get; set; }
        public string CAT_DESCRIPCION { get; set; }
        public float CAT_PORCENTAJE { get; set; }
        public string CAT_CREO { get; set; }
        public string CAT_ACTUALIZO { get; set; }
        public DateTime CAT_FECHACREO { get; set; }
        public DateTime CAT_FECHAACTUA { get; set; }
        public bool CAT_ELIMINO { get; set; }
    }
}