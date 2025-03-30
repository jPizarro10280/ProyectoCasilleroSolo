using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IFacturaHelper
    {
        void Add(FacturaViewModel factura);
        void Update(FacturaViewModel factura);
        void Delete(int id);
        List<FacturaViewModel> Get();
        FacturaViewModel GetByID(int id);
    }
}
