using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class UsuarioRolService : IUsuarioRolService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public UsuarioRolService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        UsuarioRol Convertir(UsuarioRolDTO usuarioRol)
        {
            return new UsuarioRol()
            {
                Id = usuarioRol.Id,
                UsuarioId = usuarioRol.UsuarioId,
                RolId = usuarioRol.RolId
            };
        }

        UsuarioRolDTO Convertir(UsuarioRol usuarioRol)
        {
            return new UsuarioRolDTO()
            {
                Id = usuarioRol.Id,
                UsuarioId = usuarioRol.UsuarioId,
                RolId = usuarioRol.RolId
            };
        }

        public UsuarioRolDTO AddUsuarioRol(UsuarioRolDTO usuarioRol)
        {
            try
            {
                var usuarioRolEntity = Convertir(usuarioRol);
                _unidadDeTrabajo.UsuarioRolDAL.Add(usuarioRolEntity);
                _unidadDeTrabajo.Complete();
                return usuarioRol;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteUsuarioRol(int id)
        {
            var usuarioRol = new UsuarioRol { Id = id };
            _unidadDeTrabajo.UsuarioRolDAL.Remove(usuarioRol);
            _unidadDeTrabajo.Complete();
        }

        public List<UsuarioRolDTO> GetUsuarioRoles()
        {
            var result = _unidadDeTrabajo.UsuarioRolDAL.GetAll();
            List<UsuarioRolDTO> usuarioRoles = new List<UsuarioRolDTO>();
            foreach (var item in result)
            {
                usuarioRoles.Add(Convertir(item));
            }
            return usuarioRoles;
        }

        public UsuarioRolDTO UpdateUsuarioRol(UsuarioRolDTO usuarioRol)
        {
            try
            {
                var usuarioRolEntity = Convertir(usuarioRol);
                _unidadDeTrabajo.UsuarioRolDAL.Update(usuarioRolEntity);
                _unidadDeTrabajo.Complete();
                return usuarioRol;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuarioRolDTO GetUsuarioRolByID(int id)
        {
            var result = _unidadDeTrabajo.UsuarioRolDAL.Get(id);
            return Convertir(result);
        }
    }
}
