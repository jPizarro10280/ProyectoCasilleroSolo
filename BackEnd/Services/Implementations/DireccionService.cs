using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class DireccionService : IDireccionService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public DireccionService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Direccion Convertir(DireccionDTO direccion)
        {
            return new Direccion()
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

        DireccionDTO Convertir(Direccion direccion)
        {
            return new DireccionDTO()
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

        public DireccionDTO AddDireccion(DireccionDTO direccion)
        {
            try
            {
                var direccionEntity = Convertir(direccion);
                _unidadDeTrabajo.DireccionDAL.Add(direccionEntity);
                _unidadDeTrabajo.Complete();
                return direccion;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteDireccion(int id)
        {
            var direccion = new Direccion { Id = id };
            _unidadDeTrabajo.DireccionDAL.Remove(direccion);
            _unidadDeTrabajo.Complete();
        }

        public List<DireccionDTO> GetDirecciones()
        {
            var result = _unidadDeTrabajo.DireccionDAL.GetAll();
            List<DireccionDTO> direcciones = new List<DireccionDTO>();
            foreach (var item in result)
            {
                direcciones.Add(Convertir(item));
            }
            return direcciones;
        }

        public DireccionDTO UpdateDireccion(DireccionDTO direccion)
        {
            try
            {
                var direccionEntity = Convertir(direccion);
                _unidadDeTrabajo.DireccionDAL.Update(direccionEntity);
                _unidadDeTrabajo.Complete();
                return direccion;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DireccionDTO GetDireccionByID(int id)
        {
            var result = _unidadDeTrabajo.DireccionDAL.Get(id);
            return Convertir(result);
        }
    }
}
