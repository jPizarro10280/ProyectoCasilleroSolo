﻿using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public DetalleFacturaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        DetalleFactura Convertir(DetalleFacturaDTO detalleFactura)
        {
            return new DetalleFactura()
            {   
                Id=detalleFactura.Id,
                FacturaId = detalleFactura.FacturaId,
                Concepto = detalleFactura.Concepto,
                Cantidad = detalleFactura.Cantidad,
                PrecioUnitario = detalleFactura.PrecioUnitario,
                Subtotal = detalleFactura.Subtotal
            };
        }

        DetalleFacturaDTO Convertir(DetalleFactura detalleFactura)
        {
            return new DetalleFacturaDTO()
            {
                Id = detalleFactura.Id,
                FacturaId = detalleFactura.FacturaId,
                Concepto = detalleFactura.Concepto,
                Cantidad = detalleFactura.Cantidad,
                PrecioUnitario = detalleFactura.PrecioUnitario,
                Subtotal = detalleFactura.Subtotal
            };
        }

        public DetalleFacturaDTO AddDetalleFactura(DetalleFacturaDTO detalleFactura)
        {
            try { 
                var detalleFacturaEntity = Convertir(detalleFactura);
                _unidadDeTrabajo.DetalleFacturaDAL.Add(detalleFacturaEntity);
                _unidadDeTrabajo.Complete();
            return detalleFactura;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void DeleteDetalleFactura(int id)
        {
            var detalleFactura = new DetalleFactura { Id = id };
            _unidadDeTrabajo.DetalleFacturaDAL.Remove(detalleFactura);
            _unidadDeTrabajo.Complete();
        }

        public List<DetalleFacturaDTO> GetDetalleFacturas()
        {
            var result = _unidadDeTrabajo.DetalleFacturaDAL.GetAll();
            List<DetalleFacturaDTO> detalleFacturas = new List<DetalleFacturaDTO>();
            foreach(var item in result)
            {
                detalleFacturas.Add(Convertir(item));
            }
            return detalleFacturas;
        }

        public DetalleFacturaDTO UpdateDetalleFactura(DetalleFacturaDTO detalleFactura)
        {
            try
            {
                var detalleFacturaEntity = Convertir(detalleFactura);
                _unidadDeTrabajo.DetalleFacturaDAL.Update(detalleFacturaEntity);
                _unidadDeTrabajo.Complete();
                return detalleFactura;
            }catch (Exception)
            {
                throw;
            }
        }

        public DetalleFacturaDTO GetDetalleFacturaByID(int id)
        {
            var result = _unidadDeTrabajo.DetalleFacturaDAL.Get(id);
            return Convertir(result);
        }
    }
}
