using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PrealertaPaqueteService : IPrealertaPaqueteService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public PrealertaPaqueteService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        PrealertaPaquete Convertir(PrealertaPaqueteDTO prealertaPaquete)
        {
            return new PrealertaPaquete()
            {
                Id=prealertaPaquete.Id,
                PrealertaId = prealertaPaquete.PrealertaId,
                PaqueteId = prealertaPaquete.PaqueteId
            };
        }
        PrealertaPaqueteDTO Convertir(PrealertaPaquete prealertaPaquete)
        {
            return new PrealertaPaqueteDTO()
            {
                Id = prealertaPaquete.Id,
                PrealertaId = prealertaPaquete.PrealertaId,
                PaqueteId = prealertaPaquete.PaqueteId
            };
        }

        public void AddPrealertaPaquete(PrealertaPaqueteDTO prealertaPaquete)
        {
            var prealertaPaqueteEntity = Convertir(prealertaPaquete);            
            _unidadDeTrabajo.PrealertaPaqueteDAL.Add(prealertaPaqueteEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeletePrealertaPaquete(int id)
        {
            var prealertaPaquete = new PrealertaPaquete { Id = id };
            _unidadDeTrabajo.PrealertaPaqueteDAL.Remove(prealertaPaquete);
        }

        public List<PrealertaPaqueteDTO> GetPrealertaPaquetes()
        {
            var result = _unidadDeTrabajo.PrealertaPaqueteDAL.GetAll();
            List<PrealertaPaqueteDTO> prealertaPaquetes = new List<PrealertaPaqueteDTO>();
            foreach (var item in result)
            {
                prealertaPaquetes.Add(Convertir(item));
            }
            return prealertaPaquetes;
        }

        public void UpdatePrealertaPaquete(PrealertaPaqueteDTO prealertaPaquete)
        {
            var prealertaPaqueteEntity = Convertir(prealertaPaquete);
            _unidadDeTrabajo.PrealertaPaqueteDAL.Update(prealertaPaqueteEntity);
            _unidadDeTrabajo.Complete();
        }

        public PrealertaPaqueteDTO GetPrealertaPaqueteByID(int id)
        {
            var result = _unidadDeTrabajo.PrealertaPaqueteDAL.Get(id);
            return Convertir(result);
        }
    }
}
