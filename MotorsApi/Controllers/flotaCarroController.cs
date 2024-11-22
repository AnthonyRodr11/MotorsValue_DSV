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
    public class flotaCarroController : ControllerBase
    {
        [HttpPost]
        [Route("save")]
        public object registrarAuto(Flota_Carro autos)
        {

            Flota_Auto regAuto = new Flota_Auto();

            var guardado = regAuto.registraAutoflota(autos);

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

        [HttpPatch]
        [Route("update/state")]
        public object ActualizarEstado(Update_State carrito) //Este sirve para mover un auto de Subasta hacia Ventas o Alquiler
        {
            Alquiler_Auto alquiler = new Alquiler_Auto();

            var guardado = alquiler.ActualizarEstado(carrito);

            if (guardado > 0)
                return new
                {
                    titulo = "Exito al Guardar",
                    mensaje = "Los datos se han guardado Correctamente",
                    code = 200
                };
            return new
            {
                titulo = "Error al Guardar",
                mensaje = "No se encontraron tus datos :c",
                code = 400
            };

        }

        [HttpPost]
        [Route("create/subasta")]
        public object registrarSubastaCarro(AgregarSubasta carrito)//Este sirve para crear un carro en subasta.
        {
            Subasta_Flota subastita = new Subasta_Flota();

            var guardado = subastita.registrarSubastaCarro(carrito);

            if (guardado > 0)
                return new
                {
                    titulo = "Exito al Guardar",
                    mensaje = "Los datos se han guardado Correctamente",
                    code = 200
                };
            return new
            {
                titulo = "Error al Guardar",
                mensaje = "No se encontraron tus datos :c",
                code = 400
            };
        }


        //Metodo para obtener la lista de carroceria para venta, alquiler, subasta {mandas el estado}
        [HttpGet]
        [Route("verCarroceria/{estado}")]
        public IActionResult obtenerCarrocerias(string estado)
        {
            Ver_Flotas flotas = new Ver_Flotas();
            var carrocerias = flotas.listaCarroceria(estado);

            if (carrocerias == null || carrocerias.Count == 0)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron carrocerías para el estado especificado.",
                    code = 404
                });
            }
            return Ok(carrocerias);
        }





        [HttpGet]
        [Route("ofertaActual/{cod_subasta}")]
        public IActionResult obtenerActualOferta(int cod_subasta)
        {
            Ver_Flotas ver_Flotas = new Ver_Flotas();
            var oferta = ver_Flotas.obtenerOfertaActual(cod_subasta);


            if (oferta == null )
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron el valor de la oferta.",
                    code = 404
                });
            }

            return Ok(oferta);
        }
    }


}
