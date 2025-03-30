using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IDetalleFacturaHelper
    {
        DetalleFacturaViewModel Add(DetalleFacturaViewModel detalleFactura);
        DetalleFacturaViewModel Update(DetalleFacturaViewModel detalleFactura);
        void Delete(int id);
        List<DetalleFacturaViewModel> Get();
        DetalleFacturaViewModel GetByID(int id);
    }
}
