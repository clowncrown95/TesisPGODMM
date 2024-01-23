using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPGODMM.Modelos
{
    public class Rol
    {
        public int ROL_ID { get; set; }
        public string ROL_NOMBRRE { get; set; }
        public string ROL_DESCRIPCION { get; set; }
        public string ROL_CREA { get; set; }
        public string ROL_ACTUALIZO { get; set; }
        public DateTime ROL_FECHACREA { get; set; }
        public DateTime ROL_FECHAACTUA { get; set; }
        public bool ROL_ELIMINO { get; set; }
    }
}