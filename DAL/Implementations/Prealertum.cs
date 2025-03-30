using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class PrealertumDAL : DALGenericoImpl<Prealertum>, IPrealertumDAL
    {

        private CasilleroProyectoContext _context;

        public PrealertumDAL(CasilleroProyectoContext context) : base(context)
        {
            _context = context;
        }

    }
}
