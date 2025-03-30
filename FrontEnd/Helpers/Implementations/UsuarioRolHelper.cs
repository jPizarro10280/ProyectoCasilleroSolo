using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class UsuarioRolHelper : IUsuarioRolHelper
    {
        IServiceRepository _serviceRepository;

        UsuarioRolViewModel Convertir(UsuarioRolAPI usuarioRol)
        {
            return new UsuarioRolViewModel()
            {
                Id = usuarioRol.Id,
                UsuarioId = usuarioRol.UsuarioId,
                RolId = usuarioRol.RolId
            };
        }

        UsuarioRolAPI Convertir(UsuarioRolViewModel usuarioRol)
        {
            return new UsuarioRolAPI()
            {
                Id = usuarioRol.Id,
                UsuarioId = usuarioRol.UsuarioId,
                RolId = usuarioRol.RolId
            };
        }

        public UsuarioRolHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public UsuarioRolViewModel Add(UsuarioRolViewModel usuarioRol)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/UsuarioRol", usuarioRol);
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return usuarioRol;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/UsuarioRol/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public UsuarioRolViewModel GetByID(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/UsuarioRol/" + id.ToString());
            UsuarioRolAPI usuarioRol = new UsuarioRolAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                usuarioRol = JsonConvert.DeserializeObject<UsuarioRolAPI>(content);
            }
            UsuarioRolViewModel resultado = Convertir(usuarioRol);
            return resultado;
        }

        public List<UsuarioRolViewModel> Get()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/UsuarioRol");
            List<UsuarioRolAPI> usuarioRoles = new List<UsuarioRolAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                usuarioRoles = JsonConvert.DeserializeObject<List<UsuarioRolAPI>>(content);
            }
            List<UsuarioRolViewModel> lista = new List<UsuarioRolViewModel>();
            foreach (var item in usuarioRoles)
            {
                lista.Add(Convertir(item));
            }
            return lista;
        }

        public UsuarioRolViewModel Update(UsuarioRolViewModel usuarioRol)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/UsuarioRol", Convertir(usuarioRol));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
            return usuarioRol;
        }
    }

}
