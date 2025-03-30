using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        IDireccionService _direccionService;

        public DireccionController(IDireccionService direccionService)
        {
            _direccionService = direccionService;
        }

        // GET: api/<DireccionController>
        [HttpGet]
        public IEnumerable<DireccionDTO> Get()
        {
            return _direccionService.GetDirecciones();
        }

        // GET api/<DireccionController>/5
        [HttpGet("{id}")]
        public DireccionDTO Get(int id)
        {
            return _direccionService.GetDireccionByID(id);
        }

        // POST api/<DireccionController>
        [HttpPost]
        public void Post([FromBody] DireccionDTO direccion)
        {
            _direccionService.AddDireccion(direccion);
        }

        // PUT api/<DireccionController>/5
        [HttpPut]
        public void Put([FromBody] DireccionDTO direccion)
        {
            _direccionService.UpdateDireccion(direccion);
        }

        // DELETE api/<DireccionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _direccionService.DeleteDireccion(id);
        }
    }

}
