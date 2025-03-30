using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrealertaPaqueteController : ControllerBase
    {
        IPrealertaPaqueteService _prealertaPaqueteService;

        public PrealertaPaqueteController(IPrealertaPaqueteService prealertaPaqueteService)
        {
            _prealertaPaqueteService = prealertaPaqueteService;
        }

        // GET: api/<PrealertaPaqueteController>
        [HttpGet]
        public IEnumerable<PrealertaPaqueteDTO> Get()
        {
            return _prealertaPaqueteService.GetPrealertaPaquetes();
        }

        // GET api/<PrealertaPaqueteController>/5
        [HttpGet("{id}")]
        public PrealertaPaqueteDTO Get(int id)
        {
            return _prealertaPaqueteService.GetPrealertaPaqueteByID(id);
        }

        // POST api/<PrealertaPaqueteController>
        [HttpPost]
        public void Post([FromBody] PrealertaPaqueteDTO prealertaPaquete)
        {
            _prealertaPaqueteService.AddPrealertaPaquete(prealertaPaquete);
        }

        // PUT api/<PrealertaPaqueteController>/5
        [HttpPut]
        public void Put([FromBody] PrealertaPaqueteDTO prealertaPaquete)
        {
            _prealertaPaqueteService.UpdatePrealertaPaquete(prealertaPaquete);
        }

        // DELETE api/<PrealertaPaqueteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _prealertaPaqueteService.DeletePrealertaPaquete(id);
        }
    }

}
