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
    public class DaoRol : IRol
    {
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string deleteQuery = "UPDATE [dbo].[TBL_ROL] SET ROL_ELIMINO = 1, ROL_ACTUALIZO = @Usuario, ROL_FECHAACTUA = @Fecha WHERE ROL_ID = @Id";
                var rowsAffected = db.ExecuteScalar<int>(deleteQuery, new { Id, Usuario, Fecha });
                return true;
            }
        }

        public int Insert(MRol model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string sql = "INSERT INTO [dbo].[TBL_ROL] (ROL_NOMBRRE, ROL_DESCRIPCION, ROL_CREA, ROL_ACTUALIZO, ROL_FECHACREA, ROL_FECHAACTUA, ROL_ELIMINO) VALUES (@ROL_NOMBRRE, @ROL_DESCRIPCION, @ROL_CREA, @ROL_ACTUALIZO, @ROL_FECHACREA, @ROL_FECHAACTUA, @ROL_ELIMINO)";
                var rowsAffected = db.ExecuteScalar<int>(sql, new { model.ROL_NOMBRRE, model.ROL_DESCRIPCION, model.ROL_CREA, model.ROL_ACTUALIZO, model.ROL_FECHACREA, model.ROL_FECHAACTUA, model.ROL_ELIMINO });
                return rowsAffected;
            }
        }

        public List<MRol> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT * FROM [dbo].[TBL_ROL] WHERE ROL_ELIMINO = 0 ";
                var results = db.Query<Models.MRol>(findByAnyQuery);
                return results.ToList();
            }
        }

        public MRol SelectById(int Id)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_ROL] WHERE ROL_ID = @Id";
                return db.QuerySingle<Models.MRol>(getQuery, new { Id });
            }
        }

        public bool Update(MRol model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string updateQuery = "UPDATE [dbo].[TBL_ROL] SET ROL_NOMBRRE = @ROL_NOMBRRE, ROL_DESCRIPCION = @ROL_DESCRIPCION, ROL_ACTUALIZO = @ROL_ACTUALIZO, ROL_FECHAACTUA = @ROL_FECHAACTUA WHERE ROL_ID = @ROL_ID";
                var rowsAffected = db.ExecuteScalar<int>(updateQuery, new { model.ROL_ID, model.ROL_NOMBRRE, model.ROL_DESCRIPCION, model.ROL_ACTUALIZO, model.ROL_FECHAACTUA });
                return rowsAffected == 1 ? true : false;
            }
        }
    }
}