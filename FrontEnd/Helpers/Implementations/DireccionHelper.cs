using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class DireccionHelper : IDireccionHelper
    {
        IServiceRepository _serviceRepository;

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

        DireccionAPI Convertir(DireccionViewModel direccion)
        {
            return new DireccionAPI()
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

        public DireccionHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public DireccionViewModel Add(DireccionViewModel direccion)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/Direccion", direccion);
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return direccion;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Direccion/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public DireccionViewModel GetByID(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Direccion/" + id.ToString());
            DireccionAPI direccion = new DireccionAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                direccion = JsonConvert.DeserializeObject<DireccionAPI>(content);
            }
            DireccionViewModel resultado = Convertir(direccion);
            return resultado;
        }

        public List<DireccionViewModel> Get()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Direccion");
            List<DireccionAPI> direcciones = new List<DireccionAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                direcciones = JsonConvert.DeserializeObject<List<DireccionAPI>>(content);
            }
            List<DireccionViewModel> lista = new List<DireccionViewModel>();
            foreach (var item in direcciones)
            {
                lista.Add(Convertir(item));
            }
            return lista;
        }

        public DireccionViewModel Update(DireccionViewModel direccion)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/Direccion", Convertir(direccion));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
            return direccion;
        }
    }

}
