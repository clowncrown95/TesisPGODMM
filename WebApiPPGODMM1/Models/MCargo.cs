using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPPGODMM1.Models
{
    public class MCargo
    {
        public int CAR_ID { get; set; }
        public string CAR_NOMBRE { get; set; }
        public string CAR_DESCRIPCION { get; set; }
        public string CAR_CREO { get; set; }
        public string CAR_ACTUALIZO { get; set; }
        public DateTime CAR_FECHACREA { get; set; }
        public DateTime CAR_FECHAACTUA { get; set; }
        public bool CAR_ELIMINO { get; set; }
    }
}