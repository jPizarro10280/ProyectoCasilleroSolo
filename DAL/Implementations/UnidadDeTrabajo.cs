using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IDetalleFacturaDAL DetalleFacturaDAL { get; set; }
        public IDireccionDAL DireccionDAL { get; set; }
        public IFacturaDAL FacturaDAL { get; set; }
        public IPaqueteDAL PaqueteDAL { get; set; }
        public IPrealertaPaqueteDAL PrealertaPaqueteDAL { get; set; }
        public IPrealertumDAL PrealertumDAL { get; set; }
        public IRolDAL RolDAL { get; set; }
        public IUsuarioDAL UsuarioDAL { get; set; }
        public IUsuarioRolDAL UsuarioRolDAL { get; set; }

        private CasilleroProyectoContext _casilleroProyectoContext;

        public UnidadDeTrabajo(
            CasilleroProyectoContext casilleroProyectoContext,
            IDetalleFacturaDAL detalleFactura,
            IDireccionDAL direccionDAL,
            IFacturaDAL facturaDAL,
            IPaqueteDAL paqueteDAL,
            IPrealertaPaqueteDAL prealertaPaqueteDAL,
            IPrealertumDAL prealertumDAL,
            IRolDAL rolDAL,
            IUsuarioDAL usuarioDAL,
            IUsuarioRolDAL usuarioRolDAL)
        {
            this._casilleroProyectoContext = casilleroProyectoContext;
            this.DetalleFacturaDAL = detalleFactura;
            this.DireccionDAL = direccionDAL;
            this.FacturaDAL = facturaDAL;
            this.PaqueteDAL = paqueteDAL;
            this.PrealertaPaqueteDAL = prealertaPaqueteDAL;
            this.PrealertumDAL = prealertumDAL;
            this.RolDAL = rolDAL;
            this.UsuarioDAL = usuarioDAL;
            this.UsuarioRolDAL = usuarioRolDAL;
        }


        public bool Complete()
        {
            try
            {
                _casilleroProyectoContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._casilleroProyectoContext.Dispose();
        }
    }
}
