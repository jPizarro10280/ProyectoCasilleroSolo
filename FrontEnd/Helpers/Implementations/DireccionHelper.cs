using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class DireccionHelper : IDireccionHelper
    {
        IServiceRepository _serviceRepository;

        public DireccionHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        DireccionViewModel Convertir(DireccionAPI direccion)
        {
            return new DireccionViewModel()
            {
                Id = direccion.Id,
                UsuarioId = direccion.UsuarioId,
                Linea1 = direccion.Linea1,
                Linea2 = direccion.Linea2,
                Ciudad = direccion.Ciudad,
                Estado = direccion.Estado,
                CodigoPostal = direccion.CodigoPostal,
                Pais = direccion.Pais
            };
        }

        public void Add(DireccionViewModel direccion)
        {
            _serviceRepository.PostResponse("api/Direccion", direccion);
        }

        public void Delete(int id)
        {
            _serviceRepository.DeleteResponse("api/Direccion/" + id);
        }

        public List<DireccionViewModel> Get()
        {
            var response = _serviceRepository.GetResponse("api/Direccion");
            var direcciones = JsonConvert.DeserializeObject<List<DireccionAPI>>(response.Content.ReadAsStringAsync().Result);
            return direcciones.Select(Convertir).ToList();
        }

        public DireccionViewModel GetByID(int id)
        {
            var response = _serviceRepository.GetResponse("api/Direccion/" + id);
            var direccion = JsonConvert.DeserializeObject<DireccionAPI>(response.Content.ReadAsStringAsync().Result);
            return Convertir(direccion);
        }

        public void Update(DireccionViewModel direccion)
        {
            _serviceRepository.PutResponse("api/Direccion", direccion);
        }
    }

}
