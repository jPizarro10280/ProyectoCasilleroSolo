using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrealertumController : ControllerBase
    {
        IPrealertumService _prealertumService;

        public PrealertumController(IPrealertumService prealertumService)
        {
            _prealertumService = prealertumService;
        }

        // GET: api/<PrealertumController>
        [HttpGet]
        public IEnumerable<PrealertumDTO> Get()
        {
            return _prealertumService.GetPrealertums();
        }

        // GET api/<PrealertumController>/5
        [HttpGet("{id}")]
        public PrealertumDTO Get(int id)
        {
            return _prealertumService.GetPrealertumByID(id);
        }

        // POST api/<PrealertumController>
        [HttpPost]
        public void Post([FromBody] PrealertumDTO prealertum)
        {
            _prealertumService.AddPrealertum(prealertum);
        }

        // PUT api/<PrealertumController>/5
        [HttpPut]
        public void Put([FromBody] PrealertumDTO prealertum)
        {
            _prealertumService.UpdatePrealertum(prealertum);
        }

        // DELETE api/<PrealertumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _prealertumService.DeletePrealertum(id);
        }
    }

}
