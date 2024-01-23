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
    public class DaoPersona : IPersona
    {
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string deleteQuery = "UPDATE [dbo].[TBL_PERSONA] SET PER_ELIMINO = 1, PER_ACTUALIZO = @Usuario, PER_FECHAACTUA = @Fecha WHERE PER_ID = @Id";
                var rowsAffected = db.ExecuteScalar<int>(deleteQuery, new { Id, Usuario, Fecha });
                return true;
            }
        }

        public int Insert(MPersona model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string sql = "INSERT INTO [dbo].[TBL_PERSONA] ( CAR_ID, PER_APELLIDO, PER_NOMBRE, PER_CEDULA, PER_DIRECCION, PER_TELEFONO, PER_CORREO, PER_CREO, PER_ACTUALIZO, PER_FECHACREA, PER_FECHAACTUA, PER_ELIMINO) VALUES (@CAR_ID, @USU_ID, @ORD_ID, @ROL_ID, @PER_APELLIDO, @PER_NOMBRE, @PER_CEDULA, @PER_DIRECCION, @PER_TELEFONO, @PER_CORREO, @PER_CREO, @PER_ACTUALIZO, @PER_FECHACREA, @PER_FECHAACTUA, @PER_ELIMINO)";
                var rowsAffected = db.ExecuteScalar<int>(sql, new { model.CAR_ID, model.PER_APELLIDO, model.PER_NOMBRE, model.PER_CEDULA, model.PER_DIRECCION, model.PER_TELEFONO, model.PER_CORREO, model.PER_CREO, model.PER_ACTUALIZO, model.PER_FECHACREA, model.PER_FECHAACTUA, model.PER_ELIMINO });
                return rowsAffected;
            }
        }

        public List<MPersona> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT * FROM [dbo].[TBL_PERSONA] WHERE PER_ELIMINO = 0 ";
                var results = db.Query<Models.MPersona>(findByAnyQuery);
                return results.ToList();
            }
        }

        public MPersona SelectById(int Id)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_PERSONA] WHERE PER_ID = @Id";
                return db.QuerySingle<Models.MPersona>(getQuery, new { Id });
            }
        }

        public bool Update(MPersona model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string updateQuery = "UPDATE [dbo].[TBL_PERSONA] SET CAR_ID = @CAR_ID, PER_APELLIDO = @PER_APELLIDO, PER_NOMBRE = @PER_NOMBRE, PER_CEDULA = @PER_CEDULA, PER_DIRECCION = @PER_DIRECCION, PER_TELEFONO = @PER_TELEFONO, PER_CORREO = @PER_CORREO, PER_ACTUALIZO = @PER_ACTUALIZO, PER_FECHAACTUA = @PER_FECHAACTUA WHERE PER_ID = @PER_ID";
                var rowsAffected = db.ExecuteScalar<int>(updateQuery, new { model.PER_ID, model.CAR_ID, model.PER_APELLIDO, model.PER_NOMBRE, model.PER_CEDULA, model.PER_DIRECCION, model.PER_TELEFONO, model.PER_CORREO, model.PER_ACTUALIZO, model.PER_FECHAACTUA });
                return rowsAffected == 1 ? true : false;
            }
        }
    }
}