using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class PaqueteHelper : IPaqueteHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public PaqueteHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        private PaqueteViewModel Convertir(PaqueteAPI paquete)
        {
            return new PaqueteViewModel()
            {
                Id = paquete.Id,
                UsuarioId = paquete.UsuarioId,
                FechaCreacion = paquete.FechaCreacion,
                Estado = paquete.Estado,
                MontoTotal = paquete.MontoTotal
            };
        }

        public void Add(PaqueteViewModel paquete)
        {
            _serviceRepository.PostResponse("api/Paquete", paquete);
        }

        public void Delete(int id)
        {
            _serviceRepository.DeleteResponse("api/Paquete/" + id);
        }

        public List<PaqueteViewModel> Get()
        {
            var response = _serviceRepository.GetResponse("api/Paquete");
            var paquetes = JsonConvert.DeserializeObject<List<PaqueteAPI>>(response.Content.ReadAsStringAsync().Result);
            return paquetes.Select(Convertir).ToList();
        }

        public PaqueteViewModel GetByID(int id)
        {
            var response = _serviceRepository.GetResponse("api/Paquete/" + id);
            var paquete = JsonConvert.DeserializeObject<PaqueteAPI>(response.Content.ReadAsStringAsync().Result);
            return Convertir(paquete);
        }

        public void Update(PaqueteViewModel paquete)
        {
            _serviceRepository.PutResponse("api/Paquete", paquete);
        }
    }

}
