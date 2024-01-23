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
    public class DaoOrdenTrabajo : IOrdenTrabajo
    {
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string deleteQuery = "UPDATE [dbo].[TBL_ORDENTRABAJO] SET ORD_ELIMINO = 1, ORD_ACTUALIZO = @Usuario, ORD_FECHAACTUA = @Fecha WHERE ORD_ID = @Id";
                var rowsAffected = db.ExecuteScalar<int>(deleteQuery, new { Id, Usuario, Fecha });
                return true;
            }
        }

        public int Insert(MOrdenTrabajo model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string sql = "INSERT INTO [dbo].[TBL_ORDENTRABAJO] ( USU_ID, LOC_ID, ORD_FECHAINI, ORD_FECHAFIN, ORD_NUMERO, ORD_CREO, ORD_ACTUALIZO, ORD_FECHACREO, ORD_FECHAACTUA, ORD_ELIMINO) VALUES ( @USU_ID, @LOC_ID, @ORD_FECHAINI, @ORD_FECHAFIN, @ORD_NUMERO, @ORD_CREO, @ORD_ACTUALIZO, @ORD_FECHACREO, @ORD_FECHAACTUA, @ORD_ELIMINO)";
                var rowsAffected = db.ExecuteScalar<int>(sql, new { model.USU_ID, model.LOC_ID, model.ORD_FECHAINI, model.ORD_FECHAFIN, model.ORD_NUMERO, model.ORD_CREO, model.ORD_ACTUALIZO, model.ORD_FECHACREO, model.ORD_FECHAACTUA, model.ORD_ELIMINO });
                return rowsAffected;
            }
        }

        public List<MOrdenTrabajo> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT * FROM [dbo].[TBL_ORDENTRABAJO] WHERE ORD_ELIMINO = 0 ";
                var results = db.Query<Models.MOrdenTrabajo>(findByAnyQuery);
                return results.ToList();
            }
        }

        public MOrdenTrabajo SelectById(int Id)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_ORDENTRABAJO] WHERE ORD_ID = @Id";
                return db.QuerySingle<Models.MOrdenTrabajo>(getQuery, new { Id });
            }
        }

        public bool Update(MOrdenTrabajo model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string updateQuery = "UPDATE [dbo].[TBL_ORDENTRABAJO] SET USU_ID=@USU_ID,LOC_ID = @LOC_ID, ORD_FECHAINI = @ORD_FECHAINI, ORD_FECHAFIN = @ORD_FECHAFIN, ORD_NUMERO = @ORD_NUMERO, ORD_ACTUALIZO = @ORD_ACTUALIZO, ORD_FECHAACTUA = @ORD_FECHAACTUA WHERE ORD_ID = @ORD_ID";
                var rowsAffected = db.ExecuteScalar<int>(updateQuery, new { model.ORD_ID, model.USU_ID, model.LOC_ID, model.ORD_FECHAINI, model.ORD_FECHAFIN, model.ORD_NUMERO, model.ORD_ACTUALIZO, model.ORD_FECHAACTUA });
                return rowsAffected == 1 ? true : false;
            }
        }
    }
}