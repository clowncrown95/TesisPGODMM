using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPGODMM.Modelos
{
    public class Persona
    {
        public int PER_ID { get; set; }
        public int CAR_ID { get; set; }
        public string PER_APELLIDO { get; set; }
        public string PER_NOMBRE { get; set; }
        public string PER_CEDULA { get; set; }
        public string PER_DIRECCION { get; set; }
        public int PER_TELEFONO { get; set; }
        public string PER_CORREO { get; set; }
        public string PER_CREO { get; set; }
        public string PER_ACTUALIZO { get; set; }
        public DateTime PER_FECHACREA { get; set; }
        public DateTime PER_FECHAACTUA { get; set; }
        public bool PER_ELIMINO { get; set; }
    }
}