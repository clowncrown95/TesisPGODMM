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
    public class DaoUsuario : IUsuario
    {
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string deleteQuery = "UPDATE [dbo].[TBL_USUARIO] SET USU_ELIMINO = 1, USU_ACTUALIZO = @Usuario, USU_FECHAACTUA = @Fecha WHERE USU_ID = @Id";
                var rowsAffected = db.ExecuteScalar<int>(deleteQuery, new { Id, Usuario, Fecha });
                return true;
            }
        }

        public int Insert(MUsuario model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string sql = "INSERT INTO [dbo].[TBL_USUARIO] ( ROL_ID, PER_ID, USU_USUARIO, USU_PASSWORD, USU_ESTADO, USU_CREO, USU_ACTUALIZO, USU_FECHACREA, USU_FECHAACTUA, USU_ELIMINO) VALUES ( @ROL_ID, @PER_ID, @USU_USUARIO, @USU_PASSWORD, @USU_ESTADO, @USU_CREO, @USU_ACTUALIZO, @USU_FECHACREA, @USU_FECHAACTUA, @USU_ELIMINO)";
                var rowsAffected = db.ExecuteScalar<int>(sql, new { model.ROL_ID, model.PER_ID, model.USU_USUARIO, model.USU_PASSWORD, model.USU_ESTADO, model.USU_CREO, model.USU_ACTUALIZO, model.USU_FECHACREA, model.USU_FECHAACTUA, model.USU_ELIMINO });
                return rowsAffected;
            }
        }

        public List<MUsuario> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT * FROM [dbo].[TBL_USUARIO] WHERE USU_ELIMINO = 0 ";
                var results = db.Query<Models.MUsuario>(findByAnyQuery);
                return results.ToList();
            }
        }

        public MUsuario SelectById(int Id)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_USUARIO] WHERE USU_ID = @Id";
                return db.QuerySingle<Models.MUsuario>(getQuery, new { Id });
            }
        }

        public MUsuario SelectByLogin(String usuario, String password)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_USUARIO] WHERE USU_USUARIO = @usuario and USU_PASSWORD = @password";
                return db.QuerySingle<Models.MUsuario>(getQuery, new { usuario , password });
            }
        }

        public bool Update(MUsuario model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string updateQuery = "UPDATE [dbo].[TBL_USUARIO] SET ROL_ID=@ROL_ID, PER_ID = @PER_ID, USU_USUARIO = @USU_USUARIO, USU_PASSWORD = @USU_PASSWORD, USU_ESTADO = @USU_ESTADO, USU_ACTUALIZO = @USU_ACTUALIZO, USU_FECHAACTUA = @USU_FECHAACTUA WHERE USU_ID = @USU_ID";
                var rowsAffected = db.ExecuteScalar<int>(updateQuery, new { model.ROL_ID, model.USU_ID, model.PER_ID, model.USU_USUARIO, model.USU_PASSWORD, model.USU_ESTADO, model.USU_ACTUALIZO, model.USU_FECHAACTUA });
                return rowsAffected == 1 ? true : false;
            }
        }
    }
}