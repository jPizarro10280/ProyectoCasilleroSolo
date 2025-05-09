﻿using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class DetalleFacturaHelper : IDetalleFacturaHelper
    {
        IServiceRepository _serviceRepository;

        DetalleFacturaViewModel Convertir(DetalleFacturaAPI detalleFactura)
        {
            return new DetalleFacturaViewModel()
            {
                Id = detalleFactura.Id,
                FacturaId = detalleFactura.FacturaId,
                Concepto = detalleFactura.Concepto,
                Cantidad = detalleFactura.Cantidad,
                PrecioUnitario = detalleFactura.PrecioUnitario,
                Subtotal = detalleFactura.Subtotal
            };
        }

        DetalleFacturaAPI Convertir(DetalleFacturaViewModel detalleFactura)
        {
            return new DetalleFacturaAPI()
            {
                Id = detalleFactura.Id,
                FacturaId = detalleFactura.FacturaId,
                Concepto = detalleFactura.Concepto,
                Cantidad = detalleFactura.Cantidad,
                PrecioUnitario = detalleFactura.PrecioUnitario,
                Subtotal = detalleFactura.Subtotal
            };
        }

        public DetalleFacturaHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public DetalleFacturaViewModel Add(DetalleFacturaViewModel detalleFactura)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/DetalleFactura", detalleFactura);
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return detalleFactura;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/DetalleFactura/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public DetalleFacturaViewModel GetByID(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/DetalleFactura/" + id.ToString());
            DetalleFacturaAPI detalleFactura = new DetalleFacturaAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                detalleFactura = JsonConvert.DeserializeObject<DetalleFacturaAPI>(content);
            }
            DetalleFacturaViewModel resultado = Convertir(detalleFactura);
            return resultado;
        }

        public List<DetalleFacturaViewModel> Get()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/DetalleFactura");
            List<DetalleFacturaAPI> detalleFacturas = new List<DetalleFacturaAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                detalleFacturas = JsonConvert.DeserializeObject<List<DetalleFacturaAPI>>(content);
            }
            List<DetalleFacturaViewModel> lista = new List<DetalleFacturaViewModel>();
            foreach (var item in detalleFacturas)
            {
                lista.Add(Convertir(item));
            }
            return lista;
        }

        public DetalleFacturaViewModel Update(DetalleFacturaViewModel detalleFactura)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/DetalleFactura", Convertir(detalleFactura));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
            return detalleFactura;
        }
    }
}
