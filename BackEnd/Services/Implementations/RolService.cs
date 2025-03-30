using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class RolService : IRolService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public RolService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Rol Convertir(RolDTO rol)
        {
            return new Rol()
            {
                Id=rol.Id,
                Nombre = rol.Nombre
            };
        }
        RolDTO Convertir(Rol rol)
        {
            return new RolDTO()
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            };
        }

        public void AddRol(RolDTO rol)
        {
            var rolEntity = Convertir(rol);            
            _unidadDeTrabajo.RolDAL.Add(rolEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeleteRol(int id)
        {
            var rol = new Rol { Id = id };
            _unidadDeTrabajo.RolDAL.Remove(rol);
        }

        public List<RolDTO> GetRoles()
        {
            var result = _unidadDeTrabajo.RolDAL.GetAll();
            List<RolDTO> roles = new List<RolDTO>();
            foreach (var item in result)
            {
                roles.Add(Convertir(item));
            }
            return roles;
        }

        public void UpdateRol(RolDTO rol)
        {
            var rolEntity = Convertir(rol);
            _unidadDeTrabajo.RolDAL.Update(rolEntity);
            _unidadDeTrabajo.Complete();
        }

        public RolDTO GetRolByID(int id)
        {
            var result = _unidadDeTrabajo.RolDAL.Get(id);
            return Convertir(result);
        }
    }

}
