using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturaController : ControllerBase
    {
        IDetalleFacturaService _detalleFacturaService;

        public DetalleFacturaController(IDetalleFacturaService detalleFacturaService)
        {
            _detalleFacturaService = detalleFacturaService;
        }

        // GET: api/<DetalleFacturaController>
        [HttpGet]
        public IEnumerable<DetalleFacturaDTO> Get()
        {
            return _detalleFacturaService.GetDetalleFacturas();
        }

        // GET api/<DetalleFacturaController>/5
        [HttpGet("{id}")]
        public DetalleFacturaDTO Get(int id)
        {
            return _detalleFacturaService.GetDetalleFacturaByID(id);
        }

        // POST api/<DetalleFacturaController>
        [HttpPost]
        public void Post([FromBody] DetalleFacturaDTO detalleFactura)
        {
            _detalleFacturaService.AddDetalleFactura(detalleFactura);
        }

        // PUT api/<DetalleFacturaController>/5
        [HttpPut]
        public void Put([FromBody] DetalleFacturaDTO detalleFactura)
        {
            _detalleFacturaService.UpdateDetalleFactura(detalleFactura);
        }

        // DELETE api/<DetalleFacturaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _detalleFacturaService.DeleteDetalleFactura(id);
        }
    }

}
