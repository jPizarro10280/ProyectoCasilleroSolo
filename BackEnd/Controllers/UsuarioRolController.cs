using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRolController : ControllerBase
    {
        IUsuarioRolService _usuarioRolService;

        public UsuarioRolController(IUsuarioRolService usuarioRolService)
        {
            _usuarioRolService = usuarioRolService;
        }

        // GET: api/<UsuarioRolController>
        [HttpGet]
        public IEnumerable<UsuarioRolDTO> Get()
        {
            return _usuarioRolService.GetUsuarioRoles();
        }

        // GET api/<UsuarioRolController>/5
        [HttpGet("{id}")]
        public UsuarioRolDTO Get(int id)
        {
            return _usuarioRolService.GetUsuarioRolByID(id);
        }

        // POST api/<UsuarioRolController>
        [HttpPost]
        public void Post([FromBody] UsuarioRolDTO usuarioRol)
        {
            _usuarioRolService.AddUsuarioRol(usuarioRol);
        }

        // PUT api/<UsuarioRolController>/5
        [HttpPut]
        public void Put([FromBody] UsuarioRolDTO usuarioRol)
        {
            _usuarioRolService.UpdateUsuarioRol(usuarioRol);
        }

        // DELETE api/<UsuarioRolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _usuarioRolService.DeleteUsuarioRol(id);
        }
    }

}
