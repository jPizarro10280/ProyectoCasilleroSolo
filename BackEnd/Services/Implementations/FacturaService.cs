using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class FacturaService : IFacturaService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public FacturaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Factura Convertir(FacturaDTO factura)
        {
            return new Factura()
            {
                Id = factura.Id,
                UsuarioId = factura.UsuarioId,
                PaqueteId = factura.PaqueteId,
                FechaEmision = factura.FechaEmision,
                MontoTotal = factura.MontoTotal,
                Impuestos = factura.Impuestos,
                Estado = factura.Estado
            };
        }

        FacturaDTO Convertir(Factura factura)
        {
            return new FacturaDTO()
            {
                Id = factura.Id,
                UsuarioId = factura.UsuarioId,
                PaqueteId = factura.PaqueteId,
                FechaEmision = factura.FechaEmision,
                MontoTotal = factura.MontoTotal,
                Impuestos = factura.Impuestos,
                Estado = factura.Estado
            };
        }

        public FacturaDTO AddFactura(FacturaDTO factura)
        {
            try
            {
                var facturaEntity = Convertir(factura);
                _unidadDeTrabajo.FacturaDAL.Add(facturaEntity);
                _unidadDeTrabajo.Complete();
                return factura;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteFactura(int id)
        {
            var factura = new Factura { Id = id };
            _unidadDeTrabajo.FacturaDAL.Remove(factura);
            _unidadDeTrabajo.Complete();
        }

        public List<FacturaDTO> GetFacturas()
        {
            var result = _unidadDeTrabajo.FacturaDAL.GetAll();
            List<FacturaDTO> facturas = new List<FacturaDTO>();
            foreach (var item in result)
            {
                facturas.Add(Convertir(item));
            }
            return facturas;
        }

        public FacturaDTO UpdateFactura(FacturaDTO factura)
        {
            try
            {
                var facturaEntity = Convertir(factura);
                _unidadDeTrabajo.FacturaDAL.Update(facturaEntity);
                _unidadDeTrabajo.Complete();
                return factura;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FacturaDTO GetFacturaByID(int id)
        {
            var result = _unidadDeTrabajo.FacturaDAL.Get(id);
            return Convertir(result);
        }
    }
}
