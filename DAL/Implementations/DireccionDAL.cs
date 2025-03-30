using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DireccionDAL : DALGenericoImpl<Direccion>, IDireccionDAL
    {

        private CasilleroProyectoContext _context;

        public DireccionDAL(CasilleroProyectoContext context) : base(context)
        {
            _context = context;
        }

    }
}
