using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IDetalleFacturaHelper
    {
        void Add(DetalleFacturaViewModel detalleFactura);
        void Update(DetalleFacturaViewModel detalleFactura);
        void Delete(int id);
        List<DetalleFacturaViewModel> Get();
        DetalleFacturaViewModel GetByID(int id);
    }
}
