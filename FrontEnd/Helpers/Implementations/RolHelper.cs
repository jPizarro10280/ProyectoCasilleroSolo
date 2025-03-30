using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class RolHelper : IRolHelper
    {
        IServiceRepository _serviceRepository;

        RolViewModel Convertir(RolAPI rol)
        {
            return new RolViewModel()
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            };
        }

        RolAPI Convertir(RolViewModel rol)
        {
            return new RolAPI()
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            };
        }

        public RolHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public RolViewModel Add(RolViewModel rol)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/Rol", rol);
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return rol;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Rol/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public RolViewModel GetByID(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Rol/" + id.ToString());
            RolAPI rol = new RolAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                rol = JsonConvert.DeserializeObject<RolAPI>(content);
            }
            RolViewModel resultado = Convertir(rol);
            return resultado;
        }

        public List<RolViewModel> Get()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Rol");
            List<RolAPI> roles = new List<RolAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                roles = JsonConvert.DeserializeObject<List<RolAPI>>(content);
            }
            List<RolViewModel> lista = new List<RolViewModel>();
            foreach (var item in roles)
            {
                lista.Add(Convertir(item));
            }
            return lista;
        }

        public RolViewModel Update(RolViewModel rol)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/Rol", Convertir(rol));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
            return rol;
        }
    }

}
