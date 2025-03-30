using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public IEnumerable<FacturaDTO> Get()
        {
            return _facturaService.GetFacturas();
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public FacturaDTO Get(int id)
        {
            return _facturaService.GetFacturaByID(id);
        }

        // POST api/<FacturaController>
        [HttpPost]
        public void Post([FromBody] FacturaDTO factura)
        {
            _facturaService.AddFactura(factura);
        }

        // PUT api/<FacturaController>/5
        [HttpPut]
        public void Put([FromBody] FacturaDTO factura)
        {
            _facturaService.UpdateFactura(factura);
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _facturaService.DeleteFactura(id);
        }
    }

}
