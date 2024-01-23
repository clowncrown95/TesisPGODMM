using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/Categoria")]
    public class CategoriaController : ApiController
    {
        [Route("SelectById")]
        [HttpGet]
        public Models.MCategoria SelectById(int Id)
        {
            return new Daos.DaoCategoria().SelectById(Id);
        }
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.MCategoria> SelectAll()
        {
            return new Daos.DaoCategoria().SelectAll();
        }
        [Route("Insert")]
        [HttpPost]
        public int Insert(Models.MCategoria model)
        {
            return new Daos.DaoCategoria().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.MCategoria model)
        {
            return new Daos.DaoCategoria().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            return new Daos.DaoCategoria().Delete(Id, Usuario, Fecha);
        }

    }
}
