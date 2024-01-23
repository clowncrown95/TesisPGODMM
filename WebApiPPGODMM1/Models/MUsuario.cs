using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPPGODMM1.Models
{
    public class MUsuario
    {
        public int USU_ID { get; set; }
        public int ROL_ID { get; set; }
        public int PER_ID { get; set; }
        public string USU_USUARIO { get; set; }
        public string USU_PASSWORD { get; set; }
        public string USU_ESTADO { get; set; }
        public string USU_CREO { get; set; }
        public string USU_ACTUALIZO { get; set; }
        public DateTime USU_FECHACREA {  get; set; }
        public DateTime USU_FECHAACTUA { get; set; }
        public bool USU_ELIMINO { get; set; }
    }
}