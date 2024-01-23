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
    }
}
