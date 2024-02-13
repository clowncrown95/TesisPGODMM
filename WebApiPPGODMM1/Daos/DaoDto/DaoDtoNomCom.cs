using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApiPPGODMM1.Models;
using WebApiPPGODMM1.Models.DTO;
using Dapper;

namespace WebApiPPGODMM1.Daos.DaoDto
{
    public class DaoDtoNomCom
    {
        public List<DTOUsuariocom> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT U.USU_ID, R.ROL_NOMBRRE, isnull(P.PER_NOMBRE +' '+ P.PER_APELLIDO,'SIN DATOS') AS NOMBRECOM , U.USU_USUARIO, U.USU_ESTADO FROM TBL_USUARIO AS U  inner join TBL_ROL AS R ON U.ROL_ID = R.ROL_ID left join TBL_PERSONA AS P ON U.PER_ID = P.PER_ID WHERE U.USU_ELIMINO = 0  ";
                var results = db.Query<Models.DTO.DTOUsuariocom>(findByAnyQuery);
                return results.ToList();
            }
        }
        public List<DTOPersonacom> SelectAllPercom()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT P.PER_ID, C.CAR_NOMBRE, U.USU_USUARIO, isnull(P.PER_NOMBRE +' '+ P.PER_APELLIDO,'SIN DATOS') AS NOMBRECOM, P.PER_CEDULA, P.PER_DIRECCION, P.PER_TELEFONO, P.PER_CORREO\r\nFROM TBL_PERSONA AS P inner join TBL_CARGO AS C ON P.CAR_ID = C.CAR_ID\r\nleft join TBL_USUARIO AS U ON P.USU_ID = U.USU_ID WHERE P.PER_ELIMINO = 0";
                var results = db.Query<Models.DTO.DTOPersonacom> (findByAnyQuery);
                return results.ToList();
            }
        }
     }
}