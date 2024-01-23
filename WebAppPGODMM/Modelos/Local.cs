using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPGODMM.Modelos
{
    public class Local
    {
        public int LOC_ID { get; set; }
        public string LOC_NOMBRE { get; set; }
        public int LOC_NUMERO { get; set; }
        public string LOC_CREO { get; set; }
        public string LOC_ACTUALIZO { get; set; }
        public DateTime LOC_FECHACREA { get; set; }
        public DateTime LOC_FECHAACTUA { get; set; }
        public bool LOC_ELIMINO { get; set; }
    }
}