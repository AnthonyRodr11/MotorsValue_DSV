using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsApi.Models;
using MotorsApi.BD.CRUD.Update;
using MotorsApi.BD.CRUD.Read;

namespace MotorsApi.Controllers
{

    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class ventaFlotaController : ControllerBase
    {

        [HttpPost]
        [Route("venta")] 
        public object VenderAuto(Flota_Venta venta) //Este método agrega a la tabla Flota_Venta, el carro pasa a venderse
        {
            Venta_Flota ventaAuto = new Venta_Flota();

            var guardado = ventaAuto.registrarVenta(venta);

            if (guardado > 0)
                return new
                {
                    titulo = "Exito al guardar",
                    Mensaje = "Los datos se han guardado correctamente",
                    Code = 200
                };
            return new
            {
                titulo = "Error al guardar",
                Mensaje = "Los datos explotaron",
                Code = 400
            };

        }


        [HttpGet]
        [Route("listaFlota/{estado}")]
        public IActionResult listaAutos(string estado)
        {
            Ver_Flotas autos = new Ver_Flotas();
            var listaautos = autos.ObtenerAutos(estado);

            if ( listaautos == null || listaautos.Count == 0)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron carrocerías para el estado especificado.",
                    code = 404
                });
            }

            return Ok(listaautos);
        }

        [HttpPost]
        [Route ("vendido/{id}")]
        public IActionResult CarroVendido(int id, Ventas vendido)
        {
            if (vendido == null || id == null)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "Datos o id nulos",
                    Code = 400
                });
            }

            Venta_Flota agregar = new Venta_Flota();
            bool dispo = false;

            var guardado = agregar.VenderCarro(id, vendido); //Para saber si se ingresaron los datos
            var cambiado = agregar.CambiarDisponibilidad(vendido.id_vehiculo, dispo); //para saber si se cambió la disponibilidad

            if (guardado > 0 || cambiado > 0)
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
                    Mensaje = "El carro no se pudo vender.",
                    Code = 500
                });
            }
        }

    }
}
