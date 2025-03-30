using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IFacturaService
    {
        FacturaDTO AddFactura(FacturaDTO factura);
        FacturaDTO UpdateFactura(FacturaDTO factura);
        void DeleteFactura(int id);
        List<FacturaDTO> GetFacturas();
        FacturaDTO GetFacturaByID(int id);
    }
}
