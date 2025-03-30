using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class PaqueteHelper : IPaqueteHelper
    {
        IServiceRepository _serviceRepository;

        PaqueteViewModel Convertir(PaqueteAPI paquete)
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

        PaqueteAPI Convertir(PaqueteViewModel paquete)
        {
            return new PaqueteAPI()
            {
                Id = paquete.Id,
                UsuarioId = paquete.UsuarioId,
                FechaCreacion = paquete.FechaCreacion,
                Estado = paquete.Estado,
                MontoTotal = paquete.MontoTotal
            };
        }

        public PaqueteHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public PaqueteViewModel Add(PaqueteViewModel paquete)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/Paquete", paquete);
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return paquete;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Paquete/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public PaqueteViewModel GetByID(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Paquete/" + id.ToString());
            PaqueteAPI paquete = new PaqueteAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                paquete = JsonConvert.DeserializeObject<PaqueteAPI>(content);
            }
            PaqueteViewModel resultado = Convertir(paquete);
            return resultado;
        }

        public List<PaqueteViewModel> Get()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Paquete");
            List<PaqueteAPI> paquetes = new List<PaqueteAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                paquetes = JsonConvert.DeserializeObject<List<PaqueteAPI>>(content);
            }
            List<PaqueteViewModel> lista = new List<PaqueteViewModel>();
            foreach (var item in paquetes)
            {
                lista.Add(Convertir(item));
            }
            return lista;
        }

        public PaqueteViewModel Update(PaqueteViewModel paquete)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/Paquete", Convertir(paquete));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
            return paquete;
        }
    }

}
