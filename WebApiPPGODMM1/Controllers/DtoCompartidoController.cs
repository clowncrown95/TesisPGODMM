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
    }
}
