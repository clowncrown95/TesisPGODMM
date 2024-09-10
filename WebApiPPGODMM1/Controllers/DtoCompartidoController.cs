using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/DtoCompartido")]
    public class DtoCompartidoController : ApiController
    {
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.DTO.DTOUsuariocom> SelectAll()
        {
            return new Daos.DaoDto.DaoDtoNomCom().SelectAll();
        }
        [Route("SelectAllPercom")]
        [HttpGet]
        public List<Models.DTO.DTOPersonacom> SelectAllPercom()
        {
            return new Daos.DaoDto.DaoDtoNomCom().SelectAllPercom();
        }
        [Route("SelectAllOrdTra")]
        [HttpGet]
        public List<Models.DTO.DTOOrdenTrabajo> SelectAllOrdTra()
        {
            return new Daos.DaoDto.DaoDtoOrdenTrabajo().SelectAll();
        }
        [Route("SelectById")]
        [HttpGet]
        public Models.DTO.DTOOrdenTrabajo SelectById(int Id)
        {
            return new Daos.DaoDto.DaoDtoOrdenTrabajo().SelectById(Id);
        }
        [Route("Insert")]
        [HttpPost]
        public bool Insert(Models.DTO.DTOOrdenTrabajo model)
        {
            return new Daos.DaoDto.DaoDtoOrdenTrabajo().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.DTO.DTOOrdenTrabajo model)
        {
            return new Daos.DaoDto.DaoDtoOrdenTrabajo().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id)
        {
            return new Daos.DaoDto.DaoDtoOrdenTrabajo().Delete(Id);
        }
    }
}
