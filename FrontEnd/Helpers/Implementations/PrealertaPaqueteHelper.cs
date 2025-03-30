using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class PrealertaPaqueteHelper : IPrealertaPaqueteHelper
    {
        IServiceRepository _serviceRepository;

        PrealertaPaqueteViewModel Convertir(PrealertaPaqueteAPI prealertaPaquete)
        {
            return new PrealertaPaqueteViewModel()
            {
                Id = prealertaPaquete.Id,
                PrealertaId = prealertaPaquete.PrealertaId,
                PaqueteId = prealertaPaquete.PaqueteId
            };
        }

        PrealertaPaqueteAPI Convertir(PrealertaPaqueteViewModel prealertaPaquete)
        {
            return new PrealertaPaqueteAPI()
            {
                Id = prealertaPaquete.Id,
                PrealertaId = prealertaPaquete.PrealertaId,
                PaqueteId = prealertaPaquete.PaqueteId
            };
        }

        public PrealertaPaqueteHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public PrealertaPaqueteViewModel Add(PrealertaPaqueteViewModel prealertaPaquete)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/PrealertaPaquete", prealertaPaquete);
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return prealertaPaquete;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/PrealertaPaquete/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public PrealertaPaqueteViewModel GetByID(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/PrealertaPaquete/" + id.ToString());
            PrealertaPaqueteAPI prealertaPaquete = new PrealertaPaqueteAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                prealertaPaquete = JsonConvert.DeserializeObject<PrealertaPaqueteAPI>(content);
            }
            PrealertaPaqueteViewModel resultado = Convertir(prealertaPaquete);
            return resultado;
        }

        public List<PrealertaPaqueteViewModel> Get()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/PrealertaPaquete");
            List<PrealertaPaqueteAPI> prealertaPaquetes = new List<PrealertaPaqueteAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                prealertaPaquetes = JsonConvert.DeserializeObject<List<PrealertaPaqueteAPI>>(content);
            }
            List<PrealertaPaqueteViewModel> lista = new List<PrealertaPaqueteViewModel>();
            foreach (var item in prealertaPaquetes)
            {
                lista.Add(Convertir(item));
            }
            return lista;
        }

        public PrealertaPaqueteViewModel Update(PrealertaPaqueteViewModel prealertaPaquete)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/PrealertaPaquete", Convertir(prealertaPaquete));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
            return prealertaPaquete;
        }
    }
}
