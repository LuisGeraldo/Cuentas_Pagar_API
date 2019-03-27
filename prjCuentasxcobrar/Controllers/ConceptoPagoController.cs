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
    public class ConceptoPagoController : ControllerBase
    {
        public IConceptoPagoService _IConceptoPagoService;
        public ConceptoPagoController(IConceptoPagoService IConceptoPagoService)
        {
            _IConceptoPagoService = IConceptoPagoService;
        }

        #region Metodo GET

        /// <summary>
        /// Metodo GET Para obtener los Conceptos de pago
        /// Router ("api/ConceptoPago") HttpMethod: GET
        /// </summary>
        /// <returns>
        /// Retorna una lista de Conceptos de pago
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
                        Data = _IConceptoPagoService.GetAll()
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response{
                            IsSuccess = false,
                            Message = $"No se pudo generar el listado >> {ex.Message}"
                        });
            }
        }

        #endregion

        #region Metodo POST

        /// <summary>
        /// Metodo POST Para crear un Concepto de pago
        /// router ("api/ConceptoPago") HttpMethod: POST
        /// </summary>
        /// <param name="ConceptoPago"></param>
        /// <returns>
        /// Retorna un objeto creado de tipo Concepto de pago
        /// </returns>

        [HttpPost]
        public IActionResult Create([FromBody] ConceptoPago ConceptoPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _IConceptoPagoService.Create(ConceptoPago);

                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = ConceptoPago
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Message = $"No se pudo crear el concepto de pago >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo PUT

        /// <summary>
        /// Metodo PUT Para actualizar un Concepto de pago
        /// router ("api/ConceptoPago") HttpMethod: PUT
        /// </summary>
        /// <param name="ConceptoPago"></param>
        /// <returns>
        /// Retorna un objeto actualizado de tipo Concepto de pago
        /// </returns>

        [HttpPut]
        public IActionResult Update([FromBody] ConceptoPago ConceptoPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (ConceptoPago.Id == 0)
                {
                    return BadRequest(
                        new Response
                        {
                            IsSuccess = false,
                            Message = "El Id del concepto de pago es requerido"
                        });
                }

                _IConceptoPagoService.Update(ConceptoPago);
                return Ok(
                    new Response
                    {
                        IsSuccess = true, 
                        Data = ConceptoPago
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Message = $"No se pudo actualizar el concepto de pago >> {ex.Message}"
                    });
            }
        }

        #endregion
        
        #region Metodo DELETE

        /// <summary>
        /// Metodo DELETE Para borrar un Conceptos de pago
        /// Elimina un concepto de pago por su Id
        /// router ("api/ConceptoPago") HttpMethod: DELETE
        /// </summary>
        /// <param name="Id">
        /// Tipo de dato: INT
        /// </param>
        /// <returns>
        /// Retorna verdadero (true) si se elimino el concepto de pago correctamente
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
                            Message = "El Id del concepto de pago es requerido"
                        });
                }

                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = _IConceptoPagoService.Delete(Id)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false,
                        Message = $"No se pudo eliminar el concepto de pago >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo GET({param})

        /// <summary>
        /// Metodo GET({Id}) Conceptos de pago
        /// Busca un concepto de pago por su Id
        /// Router ("api/ConceptoPago/{Id}") HttpMethod: GET
        /// </summary>
        /// <param name="Id">
        /// Tipo de dato: INT
        /// </param>
        /// <returns>
        /// Retorna un concepto de pago por su Id
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
                            Message = "El Id del concepto de pago es requerido"
                        });
                }

                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = _IConceptoPagoService.GetById(Id)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = true,
                        Message = $"Ocurrio un error en el servicio >> {ex.Message}"
                    });
            }
        }

        #endregion
    }
}
