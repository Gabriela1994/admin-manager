using AccessData.Generico;
using AccessData.Models;
using Microsoft.AspNetCore.Mvc;


namespace api_admin_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamaraController : ControllerBase
    {

        private readonly RepositorioCamara _camaraService;

        public CamaraController(RepositorioCamara camaraService)
        {
            _camaraService = camaraService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Camara>> ObtenerTodas()
        {
            return Ok(_camaraService.ObtenerTodas());
        }

        [HttpGet("{id}")]
        public ActionResult<Camara> ObtenerPorId(int id)
        {
            var camara = _camaraService.ObtenerPorId(id);
            if (camara == null) return NotFound();
            return Ok(camara);
        }

        [HttpPost]
        public ActionResult Agregar([FromBody] Camara camara)
        {
            _camaraService.Agregar(camara);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = camara.Id }, camara);
        }

        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, [FromBody] Camara camara)
        {
            if (id != camara.Id) return BadRequest();
            _camaraService.Actualizar(camara);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            _camaraService.Eliminar(id);
            return NoContent();
        }
    }
}