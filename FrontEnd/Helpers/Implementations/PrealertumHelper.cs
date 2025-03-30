using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class PrealertumHelper : IPrealertumHelper
    {
        IServiceRepository _serviceRepository;

        PrealertumViewModel Convertir(PrealertumAPI prealertum)
        {
            return new PrealertumViewModel()
            {
                Id = prealertum.Id,
                UsuarioId = prealertum.UsuarioId,
                NumeroSeguimiento = prealertum.NumeroSeguimiento,
                Descripcion = prealertum.Descripcion,
                Peso = prealertum.Peso,
                Estado = prealertum.Estado,
                FechaCreacion = prealertum.FechaCreacion,
                FechaActualizacion = prealertum.FechaActualizacion
            };
        }

        PrealertumAPI Convertir(PrealertumViewModel prealertum)
        {
            return new PrealertumAPI()
            {
                Id = prealertum.Id,
                UsuarioId = prealertum.UsuarioId,
                NumeroSeguimiento = prealertum.NumeroSeguimiento,
                Descripcion = prealertum.Descripcion,
                Peso = prealertum.Peso,
                Estado = prealertum.Estado,
                FechaCreacion = prealertum.FechaCreacion,
                FechaActualizacion = prealertum.FechaActualizacion
            };
        }

        public PrealertumHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public PrealertumViewModel Add(PrealertumViewModel prealertum)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/Prealertum", prealertum);
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return prealertum;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Prealertum/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public PrealertumViewModel GetByID(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Prealertum/" + id.ToString());
            PrealertumAPI prealertum = new PrealertumAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                prealertum = JsonConvert.DeserializeObject<PrealertumAPI>(content);
            }
            PrealertumViewModel resultado = Convertir(prealertum);
            return resultado;
        }

        public List<PrealertumViewModel> Get()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Prealertum");
            List<PrealertumAPI> prealertums = new List<PrealertumAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                prealertums = JsonConvert.DeserializeObject<List<PrealertumAPI>>(content);
            }
            List<PrealertumViewModel> lista = new List<PrealertumViewModel>();
            foreach (var item in prealertums)
            {
                lista.Add(Convertir(item));
            }
            return lista;
        }

        public PrealertumViewModel Update(PrealertumViewModel prealertum)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/Prealertum", Convertir(prealertum));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
            return prealertum;
        }
    }

}
