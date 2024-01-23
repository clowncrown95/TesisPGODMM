using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiPPGODMM1.Models;

namespace WebApiPPGODMM1.Daos
{
    public class DaoDetalleOrdenTrabajo : IDetalleOrdenTrabajo
    {
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string deleteQuery = "UPDATE [dbo].[TBL_DETALLEORDENTRABAJO] SET DTOR_ELIMINO = 1, DTOR_ACTUALIZO = @Usuario, DTOR_FECHAACTUA = @Fecha WHERE DTOR_ID = @Id";
                var rowsAffected = db.ExecuteScalar<int>(deleteQuery, new { Id, Usuario, Fecha });
                return true;
            }
        }

        public int Insert(MDetalleOrdenTrabajo model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string sql = "INSERT INTO [dbo].[TBL_DETALLEORDENTRABAJO] (ORD_ID, RTEC_ID, EQU_ID, DTOR_DETALLE, DTOR_CREA, DTOR_ACTUALIZO, DTOR_FECHACREA, DTOR_FECHAACTUA, DTOR_ELIMINO) VALUES (@ORD_ID, @RTEC_ID, @EQU_ID, @DTOR_DETALLE, @DTOR_CREA, @DTOR_ACTUALIZO, @DTOR_FECHACREA, @DTOR_FECHAACTUA, @DTOR_ELIMINO)";
                var rowsAffected = db.ExecuteScalar<int>(sql, new { model.ORD_ID, model.RTEC_ID, model.EQU_ID, model.DTOR_DETALLE, model.DTOR_CREA, model.DTOR_ACTUALIZO, model.DTOR_FECHACREA, model.DTOR_FECHAACTUA, model.DTOR_ELIMINO });
                return rowsAffected;
            }
        }

        public List<MDetalleOrdenTrabajo> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT * FROM [dbo].[TBL_DETALLEORDENTRABAJO] WHERE DTOR_ELIMINO = 0 ";
                var results = db.Query<Models.MDetalleOrdenTrabajo>(findByAnyQuery);
                return results.ToList();
            }
        }

        public MDetalleOrdenTrabajo SelectById(int Id)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_DETALLEORDENTRABAJO] WHERE DTOR_ID = @Id";
                return db.QuerySingle<Models.MDetalleOrdenTrabajo>(getQuery, new { Id });
            }
        }

        public bool Update(MDetalleOrdenTrabajo model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string updateQuery = "UPDATE [dbo].[TBL_DETALLEORDENTRABAJO] SET ORD_ID = @ORD_ID, RTEC_ID = @RTEC_ID, EQU_ID = @EQU_ID, DTOR_DETALLE = @DTOR_DETALLE, DTOR_ACTUALIZO = @DTOR_ACTUALIZO, DTOR_FECHAACTUA = @DTOR_FECHAACTUA WHERE DTOR_ID = @DTOR_ID";
                var rowsAffected = db.ExecuteScalar<int>(updateQuery, new { model.DTOR_ID, model.ORD_ID, model.RTEC_ID, model.EQU_ID, model.DTOR_DETALLE, model.DTOR_ACTUALIZO, model.DTOR_FECHAACTUA });
                return rowsAffected == 1 ? true : false;
            }
        }
    }
}