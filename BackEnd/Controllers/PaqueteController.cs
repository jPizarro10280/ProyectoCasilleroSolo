using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteController : ControllerBase
    {
        IPaqueteService _paqueteService;

        public PaqueteController(IPaqueteService paqueteService)
        {
            _paqueteService = paqueteService;
        }

        // GET: api/<PaqueteController>
        [HttpGet]
        public IEnumerable<PaqueteDTO> Get()
        {
            return _paqueteService.GetPaquetes();
        }

        // GET api/<PaqueteController>/5
        [HttpGet("{id}")]
        public PaqueteDTO Get(int id)
        {
            return _paqueteService.GetPaqueteByID(id);
        }

        // POST api/<PaqueteController>
        [HttpPost]
        public void Post([FromBody] PaqueteDTO paquete)
        {
            _paqueteService.AddPaquete(paquete);
        }

        // PUT api/<PaqueteController>/5
        [HttpPut]
        public void Put([FromBody] PaqueteDTO paquete)
        {
            _paqueteService.UpdatePaquete(paquete);
        }

        // DELETE api/<PaqueteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _paqueteService.DeletePaquete(id);
        }
    }

}
