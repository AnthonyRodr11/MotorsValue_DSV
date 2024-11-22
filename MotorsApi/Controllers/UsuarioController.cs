using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsApi.BD.CRUD.Create;
using MotorsApi.BD.CRUD.Delete;
using MotorsApi.BD.CRUD.Read;
using MotorsApi.BD.CRUD.Update;
using MotorsApi.Models;

namespace MotorsApi.Controllers
{
    [Route("MotorsApi/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route ("user/new")]
        public IActionResult RegistrarUsuario([FromBody] RegistroUsuario personita)
        {
            if(personita == null)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "La tarifa enviada es nula.",
                    Code = 400
                });
            }

            Registrando_Usuario registro = new Registrando_Usuario();
            var guardar = registro.CreandoRegistro(personita);
            

            if (guardar > 0)
            {
                return Ok( new
                {
                    titulo = "Datos Verificados :3",
                    Mensaje = "Todo bien banda",
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

        [HttpDelete]
        [Route ("user/delete/{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            if(id == 0)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "La tarifa enviada es nula.",
                    Code = 400
                });
            }

            EliminarRol borradorcito = new EliminarRol();

            if (borradorcito.RolEliminar(id)>0)
            {
                return Ok(new
                {
                    titulo = "Datos Verificados :3",
                    Mensaje = "Todo bien banda",
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
        [Route ("user/update/{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] ActualizarUsuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "La tarifa enviada es nula.",
                    Code = 400
                });
            }

            Editar_Usuario itadori = new Editar_Usuario(); //JJK Referencia
            var guarda = itadori.EditarUsuario(id, usuario);

            if (guarda > 0)
            {
                return Ok(new
                {
                    titulo = "Datos Verificados :3",
                    Mensaje = "Todo bien banda",
                    Code = 200
                });
            }
            else
            {
                return StatusCode(500, new
                {
                    titulo = "Error al Editar",
                    Mensaje = "no se pudo guardar.",
                    Code = 500
                });
            }
        }

        [HttpGet]
        [Route ("user/login/{correo}/{contraseña}")]
        public IActionResult LogearUsuario(string correo, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(correo) && string.IsNullOrWhiteSpace(contraseña))
            {
                return BadRequest(new
                {
                    titulo = "Datos inválidos",
                    Mensaje = "La tarifa enviada es nula.",
                    Code = 400
                });
            }

            Loggearse lojin = new Loggearse();
            var cuera = lojin.VerificarLogin(correo, contraseña);

            if (cuera)
            {
                return Ok(new
                {
                    titulo = "Datos Verificados :3",
                    Mensaje = "Todo bien banda",
                    Code = 200
                });
            }
            else
            {
                return StatusCode(500, new
                {
                    titulo = "Error al Editar",
                    Mensaje = "no se pudo guardar.",
                    Code = 500
                });
            }
        }

        //Metodo para obtener el nombre, apellido,correo, telefono 
        [HttpGet]
        [Route("userInfo/{id}")]
        public IActionResult mostrarInfo(int id)
        {
            Loggearse cliente = new Loggearse();
            var usuario = cliente.obtenerUsuario(id);

            if (usuario == null || usuario.Count == -1)
            {
                return NotFound(new
                {
                    titulo = "Sin resultados",
                    mensaje = "No se encontraron los datos del usuario",
                    code = 404
                });
            }
            return Ok(usuario);

        }

    }
}
