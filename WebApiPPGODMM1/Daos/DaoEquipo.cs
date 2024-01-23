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
    public class DaoEquipo : IEquipo
    {
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string deleteQuery = "UPDATE [dbo].[TBL_EQUIPO] SET EQU_ELIMINO = 1, EQU_ACTUALIZO = @Usuario, EQU_FECHAACTUA = @Fecha WHERE EQU_ID = @Id";
                var rowsAffected = db.ExecuteScalar<int>(deleteQuery, new { Id, Usuario, Fecha });
                return true;
            }
        }

        public int Insert(MEquipo model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string sql = "INSERT INTO [dbo].[TBL_EQUIPO] (CAT_ID, EQU_NOMBRE, EQU_CODIGO, EQU_DESCRIPCION, EQU_TIEMPO, EQU_COSTO, EQU_CREA, EQU_ACTUALIZO, EQU_FECHACREA, EQU_FECHAACTUA, EQU_ELIMINO) VALUES (@CAT_ID, @EQU_NOMBRE, @EQU_CODIGO, @EQU_DESCRIPCION, @EQU_TIEMPO, @EQU_COSTO, @EQU_CREA, @EQU_ACTUALIZO, @EQU_FECHACREA, @EQU_FECHAACTUA, @EQU_ELIMINO)";
                var rowsAffected = db.ExecuteScalar<int>(sql, new { model.CAT_ID, model.EQU_NOMBRE, model.EQU_CODIGO, model.EQU_DESCRIPCION, model.EQU_TIEMPO, model.EQU_COSTO, model.EQU_CREA, model.EQU_ACTUALIZO, model.EQU_FECHACREA, model.EQU_FECHAACTUA, model.EQU_ELIMINO });
                return rowsAffected;
            }
        }

        public List<MEquipo> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string findByAnyQuery = "SELECT * FROM [dbo].[TBL_EQUIPO] WHERE EQU_ELIMINO = 0 ";
                var results = db.Query<Models.MEquipo>(findByAnyQuery);
                return results.ToList();
            }
        }

        public MEquipo SelectById(int Id)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string getQuery = "SELECT * FROM [dbo].[TBL_EQUIPO] WHERE EQU_ID = @Id";
                return db.QuerySingle<Models.MEquipo>(getQuery, new { Id });
            }
        }

        public bool Update(MEquipo model)
        {
            using (IDbConnection db = new SqlConnection(Conexion.GetConnection()))
            {
                const string updateQuery = "UPDATE [dbo].[TBL_EQUIPO] SET CAT_ID = @CAT_ID, EQU_NOMBRE = @EQU_NOMBRE, EQU_CODIGO = @EQU_CODIGO, EQU_DESCRIPCION = @EQU_DESCRIPCION, EQU_TIEMPO = @EQU_TIEMPO, EQU_COSTO = @EQU_COSTO, EQU_ACTUALIZO = @EQU_ACTUALIZO, EQU_FECHAACTUA = @EQU_FECHAACTUA WHERE EQU_ID = @EQU_ID";
                var rowsAffected = db.ExecuteScalar<int>(updateQuery, new { model.EQU_ID, model.CAT_ID, model.EQU_NOMBRE, model.EQU_CODIGO, model.EQU_DESCRIPCION, model.EQU_TIEMPO, model.EQU_COSTO, model.EQU_ACTUALIZO, model.EQU_FECHAACTUA });
                return rowsAffected == 1 ? true : false;
            }
        }
    }
}