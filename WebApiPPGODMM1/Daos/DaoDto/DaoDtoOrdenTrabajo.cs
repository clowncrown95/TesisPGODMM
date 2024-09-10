using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiPPGODMM1.Models.DTO;

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
                string findByAnyQuery = $@"SELECT O.ORD_ID, U.USU_USUARIO, L.LOC_NOMBRE, O.ORD_FECHAINI, O.ORD_FECHAFIN, O.ORD_NUMERO, DO.DTOR_DETALLE, E.EQU_NOMBRE, R.RTEC_DESCIPCION, R.RTEC_RESPALDO, R.RTEC_COSTO, R.RTEC_FIRMA
                    from TBL_ORDENTRABAJO AS O 
                    INNER JOIN TBL_USUARIO AS U ON O.USU_ID = U.USU_ID 
                    INNER JOIN TBL_LOCAL AS L ON O.LOC_ID = L.LOC_ID 
                    INNER JOIN TBL_DETALLEORDENTRABAJO AS DO ON O.ORD_ID = DO.ORD_ID
                    INNER JOIN TBL_EQUIPO AS E ON DO.EQU_ID = E.EQU_ID 
                    INNER JOIN TBL_RESTECNICO AS R ON DO.RTEC_ID = R.RTEC_ID WHERE O.ORD_ELIMINO = 0";
                var results = db.Query<Models.DTO.DTOOrdenTrabajo>(findByAnyQuery);
                return results.ToList();
            }
        }
        public bool Insert(DTOOrdenTrabajo ordenTrabajo)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        // Insertar en la tabla TBL_ORDENTRABAJO
                        string insertOrdenQuery = @"
                        INSERT INTO TBL_ORDENTRABAJO (USU_ID, LOC_ID, ORD_FECHAINI, ORD_FECHAFIN, ORD_NUMERO, ORD_ELIMINO)
                        VALUES (@USU_ID, @LOC_ID, @ORD_FECHAINI, @ORD_FECHAFIN, @ORD_NUMERO, 0);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                        int ordenId = db.Query<int>(insertOrdenQuery, new
                        {
                            USU_ID = ordenTrabajo.USU_USUARIO,  // Asume que tienes el ID del usuario
                            LOC_ID = ordenTrabajo.LOC_NOMBRE,   // Asume que tienes el ID del local
                            ORD_FECHAINI = ordenTrabajo.ORD_FECHAINI,
                            ORD_FECHAFIN = ordenTrabajo.ORD_FECHAFIN,
                            ORD_NUMERO = ordenTrabajo.ORD_NUMERO
                        }, transaction).Single();

                        // Paso 1: Insertar en la tabla TBL_RESTECNICO
                        string insertRestecnicoQuery = @"
                        INSERT INTO TBL_RESTECNICO (RTEC_DESCIPCION, RTEC_RESPALDO, RTEC_COSTO, RTEC_FIRMA)
                        VALUES (@RTEC_DESCIPCION, @RTEC_RESPALDO, @RTEC_COSTO, @RTEC_FIRMA);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                        int rtecId = db.Query<int>(insertRestecnicoQuery, new
                        {
                            RTEC_DESCIPCION = ordenTrabajo.RTEC_DESCIPCION,
                            RTEC_RESPALDO = ordenTrabajo.RTEC_RESPALDO,
                            RTEC_COSTO = ordenTrabajo.RTEC_COSTO,
                            RTEC_FIRMA = ordenTrabajo.RTEC_FIRMA
                        }, transaction).Single();

                        // Insertar en la tabla TBL_DETALLEORDENTRABAJO
                        string insertDetalleOrdenQuery = @"
                        INSERT INTO TBL_DETALLEORDENTRABAJO (ORD_ID, EQU_ID, DTOR_DETALLE, RTEC_ID)
                        VALUES (@ORD_ID, @EQU_ID, @DTOR_DETALLE, @RTEC_ID)";

                        db.Execute(insertDetalleOrdenQuery, new
                        {
                            ORD_ID = ordenId,
                            EQU_ID = ordenTrabajo.EQU_NOMBRE,   // Asume que tienes el ID del equipo
                            DTOR_DETALLE = ordenTrabajo.DTOR_DETALLE,
                            RTEC_ID = ordenTrabajo.RTEC_DESCIPCION // Asume que tienes el ID del técnico
                        }, transaction);

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        public bool Update(DTOOrdenTrabajo ordenTrabajo)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        // Actualizar la tabla TBL_ORDENTRABAJO
                        string updateOrdenQuery = @"
                        UPDATE TBL_ORDENTRABAJO 
                        SET USU_ID = @USU_ID, LOC_ID = @LOC_ID, ORD_FECHAINI = @ORD_FECHAINI, ORD_FECHAFIN = @ORD_FECHAFIN, ORD_NUMERO = @ORD_NUMERO
                        WHERE ORD_ID = @ORD_ID";

                        db.Execute(updateOrdenQuery, new
                        {
                            USU_ID = ordenTrabajo.USU_USUARIO,
                            LOC_ID = ordenTrabajo.LOC_NOMBRE,
                            ORD_FECHAINI = ordenTrabajo.ORD_FECHAINI,
                            ORD_FECHAFIN = ordenTrabajo.ORD_FECHAFIN,
                            ORD_NUMERO = ordenTrabajo.ORD_NUMERO,
                            ORD_ID = ordenTrabajo.ORD_ID
                        }, transaction);

                        /*// Paso 1: Actualizar en la tabla TBL_RESTECNICO
                        string updateRestecnicoQuery = @"
                        UPDATE TBL_RESTECNICO 
                        SET RTEC_DESCIPCION = @RTEC_DESCIPCION, 
                        RTEC_RESPALDO = @RTEC_RESPALDO, 
                        RTEC_COSTO = @RTEC_COSTO, 
                        RTEC_FIRMA = @RTEC_FIRMA
                        WHERE RTEC_ID = @RTEC_ID";

                        db.Execute(updateRestecnicoQuery, new
                        {
                            RTEC_DESCIPCION = ordenTrabajo.RTEC_DESCIPCION,
                            RTEC_RESPALDO = ordenTrabajo.RTEC_RESPALDO,
                            RTEC_COSTO = ordenTrabajo.RTEC_COSTO,
                            RTEC_FIRMA = ordenTrabajo.RTEC_FIRMA,
                            RTEC_ID = ordenTrabajo.RTEC_ID // ID del técnico que ya existe y deseas actualizar
                        }, transaction);*/

                        // Actualizar la tabla TBL_DETALLEORDENTRABAJO
                        string updateDetalleOrdenQuery = @"
                        UPDATE TBL_DETALLEORDENTRABAJO 
                        SET EQU_ID = @EQU_ID, DTOR_DETALLE = @DTOR_DETALLE, RTEC_ID = @RTEC_ID
                        WHERE ORD_ID = @ORD_ID";

                        db.Execute(updateDetalleOrdenQuery, new
                        {
                            EQU_ID = ordenTrabajo.EQU_NOMBRE,
                            DTOR_DETALLE = ordenTrabajo.DTOR_DETALLE,
                            RTEC_ID = ordenTrabajo.RTEC_DESCIPCION,
                            ORD_ID = ordenTrabajo.ORD_ID
                        }, transaction);

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        public bool Delete(int ordenId)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                string deleteQuery = @"
                UPDATE TBL_ORDENTRABAJO 
                SET ORD_ELIMINO = 1
                WHERE ORD_ID = @ORD_ID";

                int rowsAffected = db.Execute(deleteQuery, new { ORD_ID = ordenId });
                return rowsAffected > 0;
            }
        }

        public DTOOrdenTrabajo SelectById(int ordenId)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                string query = @"
                SELECT O.ORD_ID, U.USU_USUARIO, L.LOC_NOMBRE, O.ORD_FECHAINI, O.ORD_FECHAFIN, O.ORD_NUMERO, 
                DO.DTOR_DETALLE, E.EQU_NOMBRE, R.RTEC_DESCIPCION, R.RTEC_RESPALDO, R.RTEC_COSTO, R.RTEC_FIRMA
                FROM TBL_ORDENTRABAJO AS O 
                INNER JOIN TBL_USUARIO AS U ON O.USU_ID = U.USU_ID 
                INNER JOIN TBL_LOCAL AS L ON O.LOC_ID = L.LOC_ID 
                INNER JOIN TBL_DETALLEORDENTRABAJO AS DO ON O.ORD_ID = DO.ORD_ID
                INNER JOIN TBL_EQUIPO AS E ON DO.EQU_ID = E.EQU_ID 
                INNER JOIN TBL_RESTECNICO AS R ON DO.RTEC_ID = R.RTEC_ID 
                WHERE O.ORD_ID = @ORD_ID AND O.ORD_ELIMINO = 0";

                return db.QueryFirstOrDefault<DTOOrdenTrabajo>(query, new { ORD_ID = ordenId });
            }
        }

    }
}