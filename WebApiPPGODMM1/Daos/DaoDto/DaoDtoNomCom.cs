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
    }
}