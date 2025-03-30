using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PaqueteService : IPaqueteService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public PaqueteService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Paquete Convertir(PaqueteDTO paquete)
        {
            return new Paquete()
            {   
                Id=paquete.Id,
                UsuarioId = paquete.UsuarioId,
                FechaCreacion = paquete.FechaCreacion,
                Estado = paquete.Estado,
                MontoTotal = paquete.MontoTotal
            };
        }
        PaqueteDTO Convertir(Paquete paquete)
        {
            return new PaqueteDTO()
            {
                Id = paquete.Id,
                UsuarioId = paquete.UsuarioId,
                FechaCreacion = paquete.FechaCreacion,
                Estado = paquete.Estado,
                MontoTotal = paquete.MontoTotal
            };
        }

        public void AddPaquete(PaqueteDTO paquete)
        {
            var paqueteEntity = Convertir(paquete);            
            _unidadDeTrabajo.PaqueteDAL.Add(paqueteEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeletePaquete(int id)
        {
            var paquete = new Paquete { Id = id };
            _unidadDeTrabajo.PaqueteDAL.Remove(paquete);
        }

        public List<PaqueteDTO> GetPaquetes()
        {
            var result = _unidadDeTrabajo.PaqueteDAL.GetAll();
            List<PaqueteDTO> paquetes = new List<PaqueteDTO>();
            foreach (var item in result)
            {
                paquetes.Add(Convertir(item));
            }
            return paquetes;
        }

        public void UpdatePaquete(PaqueteDTO paquete)
        {
            var paqueteEntity = Convertir(paquete);
            _unidadDeTrabajo.PaqueteDAL.Update(paqueteEntity);
            _unidadDeTrabajo.Complete();
        }

        public PaqueteDTO GetPaqueteByID(int id)
        {
            var result = _unidadDeTrabajo.PaqueteDAL.Get(id);
            return Convertir(result);
        }
    }
}
