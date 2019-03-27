using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prjCuentasxcobrar.Models;
using prjCuentasxcobrar.Services;

namespace prjCuentasxcobrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
   
    public class EstadoController : ControllerBase
    {
        public IEstadoService _IEstadoService;

        public EstadoController(IEstadoService EstadoService)
        {
            _IEstadoService = EstadoService;
        }

        #region Metodo GET
        /// <summary>
        /// Metodo GET Estado
        /// Router ("api/Estado") HttpMethod: GET
        /// </summary>
        /// <returns>
        /// Retorna una lista de estados
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
                        Data = _IEstadoService.GetAll()
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
        /// Metodo POST Para crear un estado
        /// router ("api/Estado") HttpMethod: POST
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>
        /// Retorna un objeto creado de tipo estado
        /// </returns>

        [HttpPost]
        public IActionResult Create([FromBody] Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _IEstadoService.Create(estado);
                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = estado
                    }); 
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Message = $"No se pudo crear el estado >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo PUT

        /// <summary>
        /// Metodo PUT Para actualizar un Estado
        /// router ("api/Estado") HttpMethod: PUT
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>
        /// Retorna un objeto actualizado de tipo Estado
        /// </returns>

        [HttpPut]
        public IActionResult Update([FromBody] Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if(estado.Id == 0)
                {
                    return BadRequest(
                        new Response
                        {
                            IsSuccess = false,
                            Message = "El Id del estado es requerido"
                        });
                }

                _IEstadoService.Update(estado);
                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = estado
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = true,
                        Message = $"No se pudo actualizar el estado >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo DELETE

        /// <summary>
        /// Metodo DELETE Estado
        /// Elimina un Estado por su Id
        /// router ("api/Estado") HttpMethod: DELETE
        /// </summary>
        /// <param name="Id">
        /// Tipo de dato: INT
        /// </param>
        /// <returns>
        /// Retorna un tipo true si se elimino correctamente
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
                            Message = "El Id del estado es requerido"
                        });
                }

                return Ok(
                    new Response
                    {
                        IsSuccess = true, 
                        Data = _IEstadoService.Delete(Id)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Data = $"No se pudo eliminar el estado >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo GET({param})

        /// <summary>
        /// Metodo GET({Id}) Estado
        /// Busca un Estado por su Id
        /// Router ("api/Estado/{Id}") HttpMethod: GET
        /// </summary>
        /// <param name="Id">
        /// Tipo de dato: INT
        /// </param>
        /// <returns>
        /// Retorna un estado por su Id
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
                            IsSuccess = true,
                            Message = "El Id del estado es requerido"
                        });
                }

                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = _IEstadoService.GetById(Id)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Message = $"No se pudo listar el estado >> {ex.Message}"
                    });
            }
        }

        #endregion
    }
}
