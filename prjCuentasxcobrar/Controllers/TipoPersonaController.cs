using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prjCuentasxcobrar.Models;
using prjCuentasxcobrar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjCuentasxcobrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoPersonaController : ControllerBase
    {
        public ITipoPersonaService _ITipoPersonaService;
        public TipoPersonaController(ITipoPersonaService ITipoPersonaService)
        {
            _ITipoPersonaService = ITipoPersonaService;
        }

        #region Metodo GET
        /// <summary>
        /// Metodo GET Tipo de persona
        /// Router ("api/TipoPersona") HttpMethod: GET
        /// </summary>
        /// <returns>
        /// Retorna una lista de tipo de persona
        /// </returns>

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = _ITipoPersonaService.GetAll()
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Message = $"No se pudo generar el listado >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo POST

        /// <summary>
        /// Metodo GET Tipo de persona
        /// Router ("api/TipoPersona") HttpMethod: GET
        /// </summary>
        /// <param name="Model"></param>
        /// <returns>
        /// Retorna un objeto creado de tipo (TipoPersona)
        /// </returns>

        [HttpPost]
        public IActionResult Create([FromBody] TipoPersona Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _ITipoPersonaService.Create(Model);
                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = Model
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Message = $"No se pudo generar el Tipo de Persona >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo PUT

        /// <summary>
        /// Metodo PUT Proveedor
        /// Router ("api/Proveedor") HttpMethod: PUT
        /// </summary>
        /// <param name="Model"></param>
        /// <returns>
        /// Retorna un objeto creado de tipo (TipoPersona)
        /// </returns>

        [HttpPut]
        public IActionResult Update([FromBody] TipoPersona Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (Model.Id == 0)
                {
                    return BadRequest(
                        new Response
                        {
                            IsSuccess = false,
                            Message = "El Id del tipo persona es requerido"
                        });
                }

                _ITipoPersonaService.Update(Model);
                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = Model
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Message = $"No se pudo actualizar el tipo de persona >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo DELETE

        /// <summary>
        /// Metodo DELETE TipoPersona
        /// Elimina un Tipo de Persona por su Id
        /// router ("api/TipoPersona") HttpMethod: DELETE
        /// </summary>
        /// <param name="Id">
        /// Tipo de dato: INT
        /// </param>
        /// <returns>
        /// Retorna el true si se elimino el tipo de persona Correctamente
        /// </returns>

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    return BadRequest(
                        new Response
                        {
                            IsSuccess = false,
                            Message = "El Id del tipo persona es requerido"
                        });
                }

                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = _ITipoPersonaService.Delete(Id)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Message = $"No se pudo eliminar el tipo de persona >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo GET({param})

        /// <summary>
        /// Metodo GET({Id}) TipoPersona
        /// Busca un TipoPersona por su Id
        /// Router ("api/TipoPersona/{Id}") HttpMethod: GET
        /// </summary>
        /// <param name="Id">
        /// Tipo de dato: INT
        /// </param>
        /// <returns>
        /// Retorna un TipoPersona por su Id
        /// </returns>

        [HttpGet("{Id}")]
        public IActionResult GetEstadoById(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    return BadRequest(
                        new Response
                        {
                            IsSuccess = false,
                            Message = "El Id del tipo persona es requerido"
                        });
                }

                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = _ITipoPersonaService.GetById(Id)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Message = $"No se pudo listar el proveedor >> {ex.Message}"
                    });
            }
        }

        #endregion
    }
}
