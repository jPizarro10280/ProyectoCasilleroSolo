using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PrealertumService : IPrealertumService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public PrealertumService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Prealertum Convertir(PrealertumDTO prealertum)
        {
            return new Prealertum()
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

        PrealertumDTO Convertir(Prealertum prealertum)
        {
            return new PrealertumDTO()
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

        public PrealertumDTO AddPrealertum(PrealertumDTO prealertum)
        {
            try
            {
                var prealertumEntity = Convertir(prealertum);
                _unidadDeTrabajo.PrealertumDAL.Add(prealertumEntity);
                _unidadDeTrabajo.Complete();
                return prealertum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletePrealertum(int id)
        {
            var prealertum = new Prealertum { Id = id };
            _unidadDeTrabajo.PrealertumDAL.Remove(prealertum);
            _unidadDeTrabajo.Complete();
        }

        public List<PrealertumDTO> GetPrealertums()
        {
            var result = _unidadDeTrabajo.PrealertumDAL.GetAll();
            List<PrealertumDTO> prealertums = new List<PrealertumDTO>();
            foreach (var item in result)
            {
                prealertums.Add(Convertir(item));
            }
            return prealertums;
        }

        public PrealertumDTO UpdatePrealertum(PrealertumDTO prealertum)
        {
            try
            {
                var prealertumEntity = Convertir(prealertum);
                _unidadDeTrabajo.PrealertumDAL.Update(prealertumEntity);
                _unidadDeTrabajo.Complete();
                return prealertum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PrealertumDTO GetPrealertumByID(int id)
        {
            var result = _unidadDeTrabajo.PrealertumDAL.Get(id);
            if (result == null)
            {
                return null; // O lanza una excepción, dependiendo de tus necesidades
            }
            return Convertir(result);
        }
    }

}
