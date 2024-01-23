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
    public class DaoCargo : ICargo
    {

        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string deleteQuery = "UPDATE [dbo].[TBL_CARGO] SET CAR_ELIMINO = 1, CAR_ACTUALIZO = @Usuario, CAR_FECHAACTUA = @Fecha WHERE CAR_ID = @Id";
                var rowsAffected = db.ExecuteScalar<int>(deleteQuery, new { Id, Usuario, Fecha });
                return true;
            }
        }

        public int Insert(Models.MCargo model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string sql = "INSERT INTO [dbo].[TBL_CARGO] (CAR_NOMBRE,CAR_DESCRIPCION, CAR_CREO, CAR_ACTUALIZO, CAR_FECHACREA, CAR_FECHAACTUA, CAR_ELIMINO) VALUES (@CAR_NOMBRE, @CAR_DESCRIPCION, @CAR_CREO, @CAR_ACTUALIZO, @CAR_FECHACREA, @CAR_FECHAACTUA, @CAR_ELIMINO)";
                var rowsAffected = db.ExecuteScalar<int>(sql, new { model.CAR_NOMBRE, model.CAR_DESCRIPCION, model.CAR_CREO, model.CAR_ACTUALIZO, model.CAR_FECHACREA, model.CAR_FECHAACTUA, model.CAR_ELIMINO });
                return rowsAffected;
            }
        }

        public List<Models.MCargo> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT * FROM [dbo].[TBL_CARGO] WHERE CAR_ELIMINO = 0 ";
                var results = db.Query<Models.MCargo>(findByAnyQuery);
                return results.ToList();
            }
        }

        public MCargo SelectById(int Id)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_CARGO] WHERE CAR_ID = @Id";
                return db.QuerySingle<Models.MCargo>(getQuery, new { Id });
            }
        }

        public Models.MCargo SelectXName(string CAR_NOMBRE)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_CARGO] WHERE CAR_NOMBRE = @CAR_NOMBRE";
                return db.QuerySingle<Models.MCargo>(getQuery, new { CAR_NOMBRE});
            } 
        }

        public bool Update(Models.MCargo model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string updateQuery = "UPDATE [dbo].[TBL_CARGO] SET CAR_NOMBRE = @CAR_NOMBRE, CAR_DESCRIPCION = @CAR_DESCRIPCION, CAR_ACTUALIZO = @CAR_ACTUALIZO, CAR_FECHAACTUA = @CAR_FECHAACTUA WHERE CAR_ID = @CAR_ID";
                var rowsAffected = db.ExecuteScalar<int>(updateQuery, new { model.CAR_ID, model.CAR_NOMBRE, model.CAR_DESCRIPCION, model.CAR_ACTUALIZO, model.CAR_FECHAACTUA });
                return rowsAffected == 1 ? true : false;
            }
        }
    }
     
}


