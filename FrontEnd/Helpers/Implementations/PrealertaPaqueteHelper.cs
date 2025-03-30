using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class PrealertaPaqueteHelper : IPrealertaPaqueteHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public PrealertaPaqueteHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        private PrealertaPaqueteViewModel Convertir(PrealertaPaqueteAPI prealertaPaquete)
        {
            return new PrealertaPaqueteViewModel()
            {
                Id = prealertaPaquete.Id,
                PrealertaId = prealertaPaquete.PrealertaId,
                PaqueteId = prealertaPaquete.PaqueteId
            };
        }

        public void Add(PrealertaPaqueteViewModel prealertaPaquete)
        {
            _serviceRepository.PostResponse("api/PrealertaPaquete", prealertaPaquete);
        }

        public void Delete(int id)
        {
            _serviceRepository.DeleteResponse("api/PrealertaPaquete/" + id);
        }

        public List<PrealertaPaqueteViewModel> Get()
        {
            var response = _serviceRepository.GetResponse("api/PrealertaPaquete");
            var prealertaPaquetes = JsonConvert.DeserializeObject<List<PrealertaPaqueteAPI>>(response.Content.ReadAsStringAsync().Result);
            return prealertaPaquetes.Select(Convertir).ToList();
        }

        public PrealertaPaqueteViewModel GetByID(int id)
        {
            var response = _serviceRepository.GetResponse("api/PrealertaPaquete/" + id);
            var prealertaPaquete = JsonConvert.DeserializeObject<PrealertaPaqueteAPI>(response.Content.ReadAsStringAsync().Result);
            return Convertir(prealertaPaquete);
        }

        public void Update(PrealertaPaqueteViewModel prealertaPaquete)
        {
            _serviceRepository.PutResponse("api/PrealertaPaquete", prealertaPaquete);
        }
    }
}
