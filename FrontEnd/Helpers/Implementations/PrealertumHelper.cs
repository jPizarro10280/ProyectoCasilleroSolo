using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class PrealertumHelper : IPrealertumHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public PrealertumHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        private PrealertumViewModel Convertir(PrealertumAPI prealertum)
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

        public void Add(PrealertumViewModel prealertum)
        {
            _serviceRepository.PostResponse("api/Prealertum", prealertum);
        }

        public void Delete(int id)
        {
            _serviceRepository.DeleteResponse("api/Prealertum/" + id);
        }

        public List<PrealertumViewModel> Get()
        {
            var response = _serviceRepository.GetResponse("api/Prealertum");
            var prealertas = JsonConvert.DeserializeObject<List<PrealertumAPI>>(response.Content.ReadAsStringAsync().Result);
            return prealertas.Select(Convertir).ToList();
        }

        public PrealertumViewModel GetByID(int id)
        {
            var response = _serviceRepository.GetResponse("api/Prealertum/" + id);
            var prealertum = JsonConvert.DeserializeObject<PrealertumAPI>(response.Content.ReadAsStringAsync().Result);
            return Convertir(prealertum);
        }

        public void Update(PrealertumViewModel prealertum)
        {
            _serviceRepository.PutResponse("api/Prealertum", prealertum);
        }
    }

}
