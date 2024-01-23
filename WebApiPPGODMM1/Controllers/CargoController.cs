using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/Cargo")]
    public class CargoController : ApiController
    {
        [Route("SelectXName")]
        [HttpGet]
        public Models.MCargo SelectXName(string CAR_NOMBRE)
        {
            return new Daos.DaoCargo().SelectXName(CAR_NOMBRE);
        }
        [Route("SelectById")]
        [HttpGet]
        public Models.MCargo SelectById(int Id)
        {
            return new Daos.DaoCargo().SelectById(Id);
        }
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.MCargo> SelectAll()
        {
            return new Daos.DaoCargo().SelectAll();
        }
        [Route("Insert")]
        [HttpPost]
        public int Insert(Models.MCargo model)
        {
            return new Daos.DaoCargo().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.MCargo model)
        {
            return new Daos.DaoCargo().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            return new Daos.DaoCargo().Delete(Id, Usuario, Fecha);
        }
    }
}
