using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IDetalleFacturaDAL DetalleFacturaDAL { get; }   
        IDireccionDAL DireccionDAL { get; }
        IFacturaDAL FacturaDAL { get; }
        IPaqueteDAL PaqueteDAL { get; }
        IPrealertaPaqueteDAL PrealertaPaqueteDAL { get; }
        IPrealertumDAL PrealertumDAL { get; }
        IRolDAL RolDAL { get; }
        IUsuarioDAL UsuarioDAL { get; }
        IUsuarioRolDAL UsuarioRolDAL { get; }



        bool Complete();
    }
}
