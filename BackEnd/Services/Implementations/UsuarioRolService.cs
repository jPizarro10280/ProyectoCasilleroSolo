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
                RolId = usuarioRol.RolId,
                UsuarioId = usuarioRol.UsuarioId
            };
        }
        UsuarioRolDTO Convertir(UsuarioRol usuarioRol)
        {
            return new UsuarioRolDTO()
            {
                Id = usuarioRol.Id,
                RolId = usuarioRol.RolId,
                UsuarioId = usuarioRol.UsuarioId
            };
        }

        public void AddUsuarioRol(UsuarioRolDTO usuarioRol)
        {
            var usuarioRolEntity = Convertir(usuarioRol);       
            _unidadDeTrabajo.UsuarioRolDAL.Add(usuarioRolEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeleteUsuarioRol(int id)
        {
            var usuarioRol = new UsuarioRol { Id = id };
            _unidadDeTrabajo.UsuarioRolDAL.Remove(usuarioRol);
        }

        public List<UsuarioRolDTO> GetUsuarioRoles()
        {
            var result = _unidadDeTrabajo.UsuarioRolDAL.GetAll();
            List<UsuarioRolDTO> usuariosRol = new List<UsuarioRolDTO>();
            foreach (var item in result)
            {
                usuariosRol.Add(Convertir(item));
            }
            return usuariosRol;
        }


        public void UpdateUsuarioRol(UsuarioRolDTO usuarioRol)
        {
            var usuarioRolEntity = Convertir(usuarioRol);
            _unidadDeTrabajo.UsuarioRolDAL.Update(usuarioRolEntity);
            _unidadDeTrabajo.Complete();
        }

        public UsuarioRolDTO GetUsuarioRolByID(int id)
        {
            var result = _unidadDeTrabajo.UsuarioRolDAL.Get(id);
            return Convertir(result);
        }
    }
}
