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
    public class DaoCategoria : ICategoria
    {
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string deleteQuery = "UPDATE [dbo].[TBL_CATEGORIA] SET CAT_ELIMINO = 1, CAT_ACTUALIZO = @Usuario, CAT_FECHAACTUA = @Fecha WHERE CAT_ID = @Id";
                var rowsAffected = db.ExecuteScalar<int>(deleteQuery, new { Id, Usuario, Fecha });
                return true;
            }
        }

        public int Insert(MCategoria model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string sql = "INSERT INTO [dbo].[TBL_CATEGORIA] (CAT_NOMBRE,CAT_DESCRIPCION, CAT_PORCENTAJE, CAT_CREO, CAT_ACTUALIZO, CAT_FECHACREO, CAT_FECHAACTUA, CAT_ELIMINO) VALUES (@CAT_NOMBRE, @CAT_DESCRIPCION, @CAT_PORCENTAJE, @CAT_CREO, @CAT_ACTUALIZO, @CAT_FECHACREO, @CAT_FECHAACTUA, @CAT_ELIMINO)";
                var rowsAffected = db.ExecuteScalar<int>(sql, new { model.CAT_NOMBRE, model.CAT_DESCRIPCION, model.CAT_PORCENTAJE, model.CAT_CREO, model.CAT_ACTUALIZO, model.CAT_FECHACREO, model.CAT_FECHAACTUA, model.CAT_ELIMINO });
                return rowsAffected;
            }
        }

        public List<MCategoria> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT * FROM [dbo].[TBL_CATEGORIA] WHERE CAT_ELIMINO = 0 ";
                var results = db.Query<Models.MCategoria>(findByAnyQuery);
                return results.ToList();
            }
        }

        public MCategoria SelectById(int Id)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_CATEGORIA] WHERE CAT_ID = @Id";
                return db.QuerySingle<Models.MCategoria>(getQuery, new { Id });
            }
        }

        public bool Update(MCategoria model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string updateQuery = "UPDATE [dbo].[TBL_CATEGORIA] SET CAT_NOMBRE = @CAT_NOMBRE, CAT_DESCRIPCION = @CAT_DESCRIPCION, CAT_PORCENTAJE = CAT_PORCENTAJE, CAT_ACTUALIZO = @CAT_ACTUALIZO, CAT_FECHAACTUA = @CAT_FECHAACTUA WHERE CAT_ID = @CAT_ID";
                var rowsAffected = db.ExecuteScalar<int>(updateQuery, new { model.CAT_ID, model.CAT_NOMBRE, model.CAT_DESCRIPCION, model.CAT_PORCENTAJE, model.CAT_ACTUALIZO, model.CAT_FECHAACTUA });
                return rowsAffected == 1 ? true : false;
            }
        }
    }
}