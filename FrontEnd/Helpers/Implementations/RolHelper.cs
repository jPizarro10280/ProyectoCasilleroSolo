using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class RolHelper : IRolHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public RolHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        private RolViewModel Convertir(RolAPI rol)
        {
            return new RolViewModel()
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            };
        }

        public void Add(RolViewModel rol)
        {
            _serviceRepository.PostResponse("api/Rol", rol);
        }

        public void Delete(int id)
        {
            _serviceRepository.DeleteResponse("api/Rol/" + id);
        }

        public List<RolViewModel> Get()
        {
            var response = _serviceRepository.GetResponse("api/Rol");
            var roles = JsonConvert.DeserializeObject<List<RolAPI>>(response.Content.ReadAsStringAsync().Result);
            return roles.Select(Convertir).ToList();
        }

        public RolViewModel GetByID(int id)
        {
            var response = _serviceRepository.GetResponse("api/Rol/" + id);
            var rol = JsonConvert.DeserializeObject<RolAPI>(response.Content.ReadAsStringAsync().Result);
            return Convertir(rol);
        }

        public void Update(RolViewModel rol)
        {
            _serviceRepository.PutResponse("api/Rol", rol);
        }
    }

}
