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
    public class DaoEstado : IEstado
    {
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string deleteQuery = "UPDATE [dbo].[TBL_ESTADO] SET EST_ELIMINO = 1, EST_ACTUALIZO = @Usuario, EST_FECHAACTUA = @Fecha WHERE EST_ID = @Id";
                var rowsAffected = db.ExecuteScalar<int>(deleteQuery, new { Id, Usuario, Fecha });
                return true;
            }
        }

        public int Insert(MEstado model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string sql = "INSERT INTO [dbo].[TBL_ESTADO] (ORD_ID, EST_NOMBRE, EST_DESCRIPCION, EST_CREA, EST_ACTUALIZO, EST_FECHACREA, EST_FECHAACTUA, EST_ELIMINO) VALUES (@ORD_ID, @EST_NOMBRE, @EST_DESCRIPCION, @EST_CREA, @EST_ACTUALIZO, @EST_FECHACREA, @EST_FECHAACTUA, @EST_ELIMINO)";
                var rowsAffected = db.ExecuteScalar<int>(sql, new { model.ORD_ID, model.EST_NOMBRE, model.EST_DESCRIPCION, model.EST_CREA, model.EST_ACTUALIZO, model.EST_FECHACREA, model.EST_FECHAACTUA, model.EST_ELIMINO });
                return rowsAffected;
            }
        }

        public List<MEstado> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT * FROM [dbo].[TBL_ESTADO] WHERE EST_ELIMINO = 0 ";
                var results = db.Query<Models.MEstado>(findByAnyQuery);
                return results.ToList();
            }
        }

        public MEstado SelectById(int Id)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_ESTADO] WHERE EST_ID = @Id";
                return db.QuerySingle<Models.MEstado>(getQuery, new { Id });
            }
        }

        public bool Update(MEstado model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string updateQuery = "UPDATE [dbo].[TBL_ESTADO] SET ORD_ID = @ORD_ID, EST_NOMBRE = @EST_NOMBRE, EST_DESCRIPCION = @EST_DESCRIPCION, EST_ACTUALIZO = @EST_ACTUALIZO, EST_FECHAACTUA = @EST_FECHAACTUA WHERE EST_ID = @EST_ID";
                var rowsAffected = db.ExecuteScalar<int>(updateQuery, new { model.EST_ID, model.ORD_ID, model.EST_NOMBRE, model.EST_DESCRIPCION, model.EST_ACTUALIZO, model.EST_FECHAACTUA });
                return rowsAffected == 1 ? true : false;
            }
        }
    }
}