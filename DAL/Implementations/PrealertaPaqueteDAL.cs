using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class PrealertaPaqueteDAL : DALGenericoImpl<PrealertaPaquete>, IPrealertaPaqueteDAL
    {

        private CasilleroProyectoContext _context;

        public PrealertaPaqueteDAL(CasilleroProyectoContext context) : base(context)
        {
            _context = context;
        }

    }
}
