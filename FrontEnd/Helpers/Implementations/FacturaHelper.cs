using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class FacturaHelper : IFacturaHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public FacturaHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        private FacturaViewModel Convertir(FacturaAPI factura)
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

        public void Add(FacturaViewModel factura)
        {
            _serviceRepository.PostResponse("api/Factura", factura);
        }

        public void Delete(int id)
        {
            _serviceRepository.DeleteResponse("api/Factura/" + id);
        }

        public List<FacturaViewModel> Get()
        {
            var response = _serviceRepository.GetResponse("api/Factura");
            var facturas = JsonConvert.DeserializeObject<List<FacturaAPI>>(response.Content.ReadAsStringAsync().Result);
            return facturas.Select(Convertir).ToList();
        }

        public FacturaViewModel GetByID(int id)
        {
            var response = _serviceRepository.GetResponse("api/Factura/" + id);
            var factura = JsonConvert.DeserializeObject<FacturaAPI>(response.Content.ReadAsStringAsync().Result);
            return Convertir(factura);
        }

        public void Update(FacturaViewModel factura)
        {
            _serviceRepository.PutResponse("api/Factura", factura);
        }
    }
}
