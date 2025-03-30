using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class UsuarioRolHelper : IUsuarioRolHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public UsuarioRolHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        private UsuarioRolViewModel Convertir(UsuarioRolAPI usuarioRol)
        {
            return new UsuarioRolViewModel()
            {
                Id = usuarioRol.Id,
                UsuarioId = usuarioRol.UsuarioId,
                RolId = usuarioRol.RolId
            };
        }

        public void Add(UsuarioRolViewModel usuarioRol)
        {
            _serviceRepository.PostResponse("api/UsuarioRol", usuarioRol);
        }

        public void Delete(int id)
        {
            _serviceRepository.DeleteResponse("api/UsuarioRol/" + id);
        }

        public List<UsuarioRolViewModel> Get()
        {
            var response = _serviceRepository.GetResponse("api/UsuarioRol");
            var usuarioRoles = JsonConvert.DeserializeObject<List<UsuarioRolAPI>>(response.Content.ReadAsStringAsync().Result);
            return usuarioRoles.Select(Convertir).ToList();
        }

        public UsuarioRolViewModel GetByID(int id)
        {
            var response = _serviceRepository.GetResponse("api/UsuarioRol/" + id);
            var usuarioRol = JsonConvert.DeserializeObject<UsuarioRolAPI>(response.Content.ReadAsStringAsync().Result);
            return Convertir(usuarioRol);
        }

        public void Update(UsuarioRolViewModel usuarioRol)
        {
            _serviceRepository.PutResponse("api/UsuarioRol", usuarioRol);
        }
    }

}
