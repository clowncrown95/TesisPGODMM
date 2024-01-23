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
    public class DaoLocal : ILocal
    {
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string deleteQuery = "UPDATE [dbo].[TBL_LOCAL] SET LOC_ELIMINO = 1, LOC_ACTUALIZO = @Usuario, LOC_FECHAACTUA = @Fecha WHERE LOC_ID = @Id";
                var rowsAffected = db.ExecuteScalar<int>(deleteQuery, new { Id, Usuario, Fecha });
                return true;
            }
        }

        public int Insert(MLocal model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string sql = "INSERT INTO [dbo].[TBL_LOCAL] ( LOC_NOMBRE, LOC_NUMERO, LOC_CREO, LOC_ACTUALIZO, LOC_FECHACREA, LOC_FECHAACTUA, LOC_ELIMINO) VALUES ( @LOC_NOMBRE, @LOC_NUMERO, @LOC_CREO, @LOC_ACTUALIZO, @LOC_FECHACREA, @LOC_FECHAACTUA, @LOC_ELIMINO)";
                var rowsAffected = db.ExecuteScalar<int>(sql, new {  model.LOC_NOMBRE, model.LOC_NUMERO, model.LOC_CREO, model.LOC_ACTUALIZO, model.LOC_FECHACREA, model.LOC_FECHAACTUA, model.LOC_ELIMINO });
                return rowsAffected;
            }
        }

        public List<MLocal> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT * FROM [dbo].[TBL_LOCAL] WHERE LOC_ELIMINO = 0 ";
                var results = db.Query<Models.MLocal>(findByAnyQuery);
                return results.ToList();
            }
        }

        public MLocal SelectById(int Id)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_LOCAL] WHERE CAR_ID = @Id";
                return db.QuerySingle<Models.MLocal>(getQuery, new { Id });
            }
        }

        public bool Update(MLocal model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string updateQuery = "UPDATE [dbo].[TBL_LOCAL] SET  LOC_NOMBRE = @LOC_NOMBRE, LOC_NUMERO = @LOC_NUMERO, LOC_ACTUALIZO = @LOC_ACTUALIZO, LOC_FECHAACTUA = @LOC_FECHAACTUA WHERE LOC_ID = @LOC_ID";
                var rowsAffected = db.ExecuteScalar<int>(updateQuery, new { model.LOC_NOMBRE, model.LOC_NUMERO, model.LOC_ACTUALIZO, model.LOC_FECHAACTUA });
                return rowsAffected == 1 ? true : false;
            }
        }
    }
}
