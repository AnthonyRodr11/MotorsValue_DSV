
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Create;
using MotorsApi.BD.CRUD.Read;
using MotorsApi.BD.CRUD.Update;
using MotorsApi.Models;

namespace MotorsApi.Controllers
{
    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class AlquilerController : ControllerBase
    {

        [HttpGet]
        [Route("tarifas")]
        public List<Tarifas_Alquiler> ObtenerTarifas()
        {
            return new Ver_Flotas().ObtenerTarifas();
        }

        [HttpPost]
        [Route("nueva/Tarifa")]
        public IActionResult registrarTarifa([FromBody]Tarifas_Alquiler tarifa)
        {
            if (tarifa == null)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "La tarifa enviada es nula.",
                    Code = 400
                });
            }

            CrearTipoTarifa alquiler = new CrearTipoTarifa();
            var guardado = alquiler.crearnuevotipo(tarifa);

            if (guardado > 0)
            {
                return Ok(new
                {
                    titulo = "Éxito al guardar",
                    Mensaje = "Los datos se han guardado correctamente.",
                    Code = 200
                });
            }
            else
            {
                return StatusCode(500, new
                {
                    titulo = "Error al guardar",
                    Mensaje = "El tipo de tarifa no pudo guardarse.",
                    Code = 500
                });
            }
        }

        [HttpPatch]
        [Route("editar/Tarifa/{id}")]
        public IActionResult actualizarTarifa(int id, [FromBody] TarifaRequest tarifas)
        {
            if(tarifas == null)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "El precio no puede ser nulo.",
                    Code = 400
                });
            }
            Alquiler_Auto nuevoAlquiler = new Alquiler_Auto();

            var actualizado = nuevoAlquiler.EditarTarifa(id, tarifas);
            if (actualizado > 0)
            {
                return Ok(
                    new
                    {
                        titulo = "tarifa actualizada",
                        Mensaje = "El precio se ha actualizado correctamente",
                        Code = "200"
                    }
                );
            }
            else
            {
                return StatusCode(500, new
                {
                    titulo = "Error al guardar",
                    Mensaje = "La tarifa no se pudo actualizar",
                    Code = 500
                });
            }
        }

        [HttpGet]
        [Route ("seguros")]
        public List<SeguroRequest> GetSeguros()
        {
            return new SeguroRead().ObtenerListaSeguros();
        }

    }
}
