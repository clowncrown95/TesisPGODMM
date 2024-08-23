using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPPGODMM1.Daos.DaoDto
{
    public class DaoDtoOrdenTrabajo
    {
        /*select O.ORD_ID, U.USU_USUARIO, L.LOC_NOMBRE, O.ORD_FECHAINI, O.ORD_FECHAFIN, O.ORD_NUMERO, DO.DTOR_DETALLE, E.EQU_NOMBRE, R.RTEC_DESCIPCION, R.RTEC_RESPALDO, R.RTEC_COSTO, R.RTEC_FIRMA
        from TBL_ORDENTRABAJO O INNER JOIN TBL_USUARIO U ON O.USU_ID = U.USU_ID INNER JOIN TBL_LOCAL L ON O.LOC_ID = L.LOC_ID INNER JOIN TBL_DETALLEORDENTRABAJO DO ON O.ORD_ID = DO.ORD_ID
        INNER JOIN TBL_EQUIPO E ON DO.EQU_ID = E.EQU_ID INNER JOIN TBL_RESTECNICO R ON DO.RTEC_ID = R.RTEC_ID*/

        public List<DTOOrdenTrabajo> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT O.ORD_ID, U.USU_USUARIO, L.LOC_NOMBRE, O.ORD_FECHAINI, O.ORD_FECHAFIN, O.ORD_NUMERO, DO.DTOR_DETALLE, E.EQU_NOMBRE, R.RTEC_DESCIPCION, R.RTEC_RESPALDO, R.RTEC_COSTO, R.RTEC_FIRMA" +
                    "from TBL_ORDENTRABAJO O INNER JOIN TBL_USUARIO U ON O.USU_ID = U.USU_ID INNER JOIN TBL_LOCAL L ON O.LOC_ID = L.LOC_ID INNER JOIN TBL_DETALLEORDENTRABAJO DO ON O.ORD_ID = DO.ORD_ID" +
                    "INNER JOIN TBL_EQUIPO E ON DO.EQU_ID = E.EQU_ID INNER JOIN TBL_RESTECNICO R ON DO.RTEC_ID = R.RTEC_ID WHERE O.ORD_ELIMINO = 0";
                var results = db.Query<Models.DTO.DTOUsuariocom>(findByAnyQuery);
                return results.ToList();
            }
        }

    }
}