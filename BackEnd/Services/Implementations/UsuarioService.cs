using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public UsuarioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Usuario Convertir(UsuarioDTO usuario)
        {
            return new Usuario()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Contrasena = usuario.Contrasena,
                Telefono = usuario.Telefono
            };
        }

        UsuarioDTO Convertir(Usuario usuario)
        {
            return new UsuarioDTO()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Contrasena = usuario.Contrasena,
                Telefono = usuario.Telefono
            };
        }

        public UsuarioDTO AddUsuario(UsuarioDTO usuario)
        {
            try
            {
                var usuarioEntity = Convertir(usuario);
                _unidadDeTrabajo.UsuarioDAL.Add(usuarioEntity);
                _unidadDeTrabajo.Complete();
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteUsuario(int id)
        {
            var usuario = new Usuario { Id = id };
            _unidadDeTrabajo.UsuarioDAL.Remove(usuario);
            _unidadDeTrabajo.Complete();
        }

        public List<UsuarioDTO> GetUsuarios()
        {
            var result = _unidadDeTrabajo.UsuarioDAL.GetAll();
            List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
            foreach (var item in result)
            {
                usuarios.Add(Convertir(item));
            }
            return usuarios;
        }

        public UsuarioDTO UpdateUsuario(UsuarioDTO usuario)
        {
            try
            {
                var usuarioEntity = Convertir(usuario);
                _unidadDeTrabajo.UsuarioDAL.Update(usuarioEntity);
                _unidadDeTrabajo.Complete();
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuarioDTO GetUsuarioByID(int id)
        {
            var result = _unidadDeTrabajo.UsuarioDAL.Get(id);
            return Convertir(result);
        }
    }
}
