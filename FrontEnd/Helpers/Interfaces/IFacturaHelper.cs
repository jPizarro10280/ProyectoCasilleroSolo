using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IFacturaHelper
    {
        FacturaViewModel Add(FacturaViewModel factura);
        FacturaViewModel Update(FacturaViewModel factura);
        void Delete(int id);
        List<FacturaViewModel> Get();
        FacturaViewModel GetByID(int id);
    }
}
