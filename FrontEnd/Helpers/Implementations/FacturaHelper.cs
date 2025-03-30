using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class FacturaHelper : IFacturaHelper
    {
        IServiceRepository _serviceRepository;

        FacturaViewModel Convertir(FacturaAPI factura)
        {
            return new FacturaViewModel()
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

        FacturaAPI Convertir(FacturaViewModel factura)
        {
            return new FacturaAPI()
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

        public FacturaHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public FacturaViewModel Add(FacturaViewModel factura)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/Factura", factura);
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return factura;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Factura/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public FacturaViewModel GetByID(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Factura/" + id.ToString());
            FacturaAPI factura = new FacturaAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                factura = JsonConvert.DeserializeObject<FacturaAPI>(content);
            }
            FacturaViewModel resultado = Convertir(factura);
            return resultado;
        }

        public List<FacturaViewModel> Get()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Factura");
            List<FacturaAPI> facturas = new List<FacturaAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                facturas = JsonConvert.DeserializeObject<List<FacturaAPI>>(content);
            }
            List<FacturaViewModel> lista = new List<FacturaViewModel>();
            foreach (var item in facturas)
            {
                lista.Add(Convertir(item));
            }
            return lista;
        }

        public FacturaViewModel Update(FacturaViewModel factura)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/Factura", Convertir(factura));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
            return factura;
        }
    }
}
