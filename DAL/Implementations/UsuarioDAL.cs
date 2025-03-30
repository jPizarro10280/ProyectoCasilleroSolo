using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UsuarioDAL : DALGenericoImpl<Usuario>, IUsuarioDAL
    {

        private CasilleroProyectoContext _context;

        public UsuarioDAL(CasilleroProyectoContext context) : base(context)
        {
            _context = context;
        }

    }
}
