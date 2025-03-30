using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IDetalleFacturaService
    {
        DetalleFacturaDTO AddDetalleFactura(DetalleFacturaDTO detalleFactura);
        DetalleFacturaDTO UpdateDetalleFactura(DetalleFacturaDTO detalleFactura);
        void DeleteDetalleFactura(int id);
        List <DetalleFacturaDTO> GetDetalleFacturas();
        DetalleFacturaDTO GetDetalleFacturaByID(int id);
    }
}
