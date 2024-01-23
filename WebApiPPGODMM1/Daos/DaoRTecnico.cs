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
    public class DaoRTecnico : IRTecnico
    {
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string deleteQuery = "UPDATE [dbo].[TBL_RESTECNICO] SET RTEC_ELIMINO = 1, RTEC_ACTUALIZO = @Usuario, RTEC_FECHAACTUA = @Fecha WHERE RTEC_ID = @Id";
                var rowsAffected = db.ExecuteScalar<int>(deleteQuery, new { Id, Usuario, Fecha });
                return true;
            }
        }

        public int Insert(MRTecnico model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string sql = "INSERT INTO [dbo].[TBL_RESTECNICO] ( DTOR_id, RTEC_DESCRIPCION, RTEC_RESPALDO, RTEC_COSTO, RTEC_FIRMA, RTEC_CREO, RTEC_ACTUALIZO, RTEC_FECHACREO, RTEC_FECHAACTUA, RTEC_ELIMINO) VALUES ( @DTOR_ID, @RTEC_DESCRIPCION, RTEC_RESPALDO, RTEC_COSTO, RTEC_FIRMA, @RTEC_CREO, @RTEC_ACTUALIZO, @RTEC_FECHACREO, @RTEC_FECHAACTUA, @RTEC_ELIMINO)";
                var rowsAffected = db.ExecuteScalar<int>(sql, new { model.DTOR_ID, model.RTEC_DESCRIPCION, model.RTEC_RESPALDO, model.RTEC_COSTO, model.RTEC_FIRMA, model.RTEC_CREO, model.RTEC_ACTUALIZO, model.RTEC_FECHACREO, model.RTEC_FECHAACTUA, model.RTEC_ELIMINO });
                return rowsAffected;
            }
        }

        public List<MRTecnico> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT * FROM [dbo].[TBL_RESTECNICO] WHERE RTEC_ELIMINO = 0 ";
                var results = db.Query<Models.MRTecnico>(findByAnyQuery);
                return results.ToList();
            }
        }

        public MRTecnico SelectById(int Id)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_RESTECNICO] WHERE RTEC_ID = @Id";
                return db.QuerySingle<Models.MRTecnico>(getQuery, new { Id });
            }
        }

        public bool Update(MRTecnico model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string updateQuery = "UPDATE [dbo].[TBL_RESTECNICO] SET DTOR_ID = @DTOR_ID, RTEC_DESCRIPCION = @RTEC_DESCRIPCION, RTEC_RESPALDO = @RTEC_RESPALDO, RTEC_COSTO = @RTEC_COSTO, RTEC_FIRMA = @RTECFIRMA, RTEC_ACTUALIZO = @RTEC_ACTUALIZO, RTEC_FECHAACTUA = @RTEC_FECHAACTUA WHERE RTEC_ID = @RTEC_ID";
                var rowsAffected = db.ExecuteScalar<int>(updateQuery, new { model.DTOR_ID, model.RTEC_DESCRIPCION, model.RTEC_RESPALDO, model.RTEC_COSTO, model.RTEC_FIRMA, model.RTEC_ACTUALIZO, model.RTEC_FECHAACTUA });
                return rowsAffected == 1 ? true : false;
            }
        }
    }
}