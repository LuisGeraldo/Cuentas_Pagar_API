using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prjCuentasxcobrar.Models;
using prjCuentasxcobrar.Services;
using System;

namespace prjCuentasxcobrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentoPorPagarController : ControllerBase
    {
        public IDocumentoPorPagarService _IDocuentoPorPagarService;

        public DocumentoPorPagarController(IDocumentoPorPagarService IDocumentoPorPagarService)
        {
            _IDocuentoPorPagarService = IDocumentoPorPagarService;
        }

        #region Metodo GET

        /// <summary>
        /// Metodo GET para obtener todos los Documentos por pagar
        /// Router ("api/DocumentoPorPagar") HttpMethod: GET
        /// </summary>
        /// <returns>
        /// Retorna una lista de Documentos por pagar
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
                        Data = _IDocuentoPorPagarService.GetAll()
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
        /// Metodo POST Para crear Documentos por pagar
        /// Router ("api/DocumentoPorPagar") HttpMethod: POST
        /// </summary>
        /// <param name="Model"></param>
        /// <returns>
        /// Retorna un objeto creado de tipo Documento por pagar
        /// </returns>

        [HttpPost]
        public IActionResult Create([FromBody] DocumentoPorPagar Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _IDocuentoPorPagarService.Create(Model);
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
                        Message = $"No se pudo crear el documento por pagar >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo PUT

        /// <summary>
        /// Metodo POST Para actualizar Documentos por pagar
        /// Router ("api/DocumentoPorPagar") HttpMethod: PUT
        /// </summary>
        /// <param name="Model"></param>
        /// <returns>
        /// Retorna un objeto actualizado de tipo Documento por pagar
        /// </returns>

        [HttpPut]
        public IActionResult Update([FromBody] DocumentoPorPagar Model)
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
                            Message = "El Id del documento por pagar es requerido"
                        });
                }

               _IDocuentoPorPagarService.Update(Model);
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
                        Message = $"No se pudo actualizar ell documento por pagar >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo DELETE

        /// <summary>
        /// Metodo DELETE para borrar Documentos por pagar
        /// Elimina un Documento por pagar mediante su Id
        /// router ("api/DocumentoPorPagar") HttpMethod: DELETE
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
                            Message = "El Id del documento por pagar es requerido"
                        });
                }

                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = _IDocuentoPorPagarService.Delete(Id)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Message = $"No se pudo eliminar el documento por pagar >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo GET({param})

        /// <summary>
        /// Metodo GET({Id}) Documento Por Pagar
        /// Busca un Documento Por Pagar mediante su Id
        /// Router ("api/DocumentoPorPagar/{Id}") HttpMethod: GET
        /// </summary>
        /// <param name="Id">
        /// Tipo de dato: INT
        /// </param>
        /// <returns>
        /// Retorna un Documento por pagar mediante su Id
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
                            Message = "El Id documento por pagar es requerido"
                        });
                }

                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = _IDocuentoPorPagarService.GetById(Id)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = true,
                        Message = $"No se pudo buscar el documento por pagar >> {ex.Message}"
                    });
            }
        }

        #endregion
    }
}
