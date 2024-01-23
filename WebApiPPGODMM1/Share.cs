using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPPGODMM1
{
    public interface IShare<S>
    {
        int Insert(S model);
        bool Update(S model);
        bool Delete(int Id, string Usuario, DateTime Fecha);
        S SelectById(int Id);
        List<S> SelectAll();
    }
    public interface ICargo : IShare<Models.MCargo>
    {
        //TODO
        //Métodos
        Models.MCargo SelectXName(string CAR_NOMBRE);
    }
    public interface ICategoria : IShare<Models.MCategoria>
    {
         
    }
    public interface IDetalleOrdenTrabajo : IShare<Models.MDetalleOrdenTrabajo>
    {
         
    }
    public interface IEquipo : IShare<Models.MEquipo>
    {
          
    }
    public interface IEstado : IShare<Models.MEstado>
    {
         
    }
    public interface ILocal : IShare<Models.MLocal>
    {
         
    }
    public interface IOrdenTrabajo : IShare<Models.MOrdenTrabajo>
    {
         
    }
    public interface IPersona : IShare<Models.MPersona>
    {
         
    }
    public interface IRol : IShare<Models.MRol>
    {
         
    }
    public interface IRTecnico : IShare<Models.MRTecnico>
    {
         
    }
    public interface IUsuario : IShare<Models.MUsuario>
    {

    }
}