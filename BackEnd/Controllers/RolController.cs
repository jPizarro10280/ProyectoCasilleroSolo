using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        // GET: api/<RolController>
        [HttpGet]
        public IEnumerable<RolDTO> Get()
        {
            return _rolService.GetRoles();
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public RolDTO Get(int id)
        {
            return _rolService.GetRolByID(id);
        }

        // POST api/<RolController>
        [HttpPost]
        public void Post([FromBody] RolDTO rol)
        {
            _rolService.AddRol(rol);
        }

        // PUT api/<RolController>/5
        [HttpPut]
        public void Put([FromBody] RolDTO rol)
        {
            _rolService.UpdateRol(rol);
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _rolService.DeleteRol(id);
        }
    }

}
