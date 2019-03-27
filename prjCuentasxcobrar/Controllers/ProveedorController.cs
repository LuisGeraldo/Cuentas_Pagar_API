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
    public class ProveedorController : ControllerBase
    {
        public IProveedorService _IProveedorService;
        public ProveedorController(IProveedorService IProveedorService)
        {
            _IProveedorService = IProveedorService;
        }

        #region  Metodo GET

        /// <summary>
        /// Metodo GET Proveedor
        /// Router ("api/Proveedor") HttpMethod: GET
        /// </summary>
        /// <returns>
        /// Retorna una lista de Proveedores
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
                        Data = _IProveedorService.GetAll()
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
        /// Metodo GET Proveedor
        /// Router ("api/Proveedor") HttpMethod: GET
        /// </summary>
        /// <param name="Model"></param>
        /// <returns>
        /// Retorna un objeto creado de tipo proveedor
        /// </returns>

        [HttpPost]
        public IActionResult Create([FromBody] Proveedor Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _IProveedorService.Create(Model);
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
                        Message = $"No se pudo crear el proveedor >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo PUT

        /// <summary>
        /// Metodo PUT Para actualizar un Proveedor
        /// router ("api/Proveedor") HttpMethod: PUT
        /// </summary>
        /// <param name="Model"></param>
        /// <returns>
        /// Retorna un objeto actualizado de tipo Proveedor
        /// </returns>


        [HttpPut]
        public IActionResult Update([FromBody] Proveedor Model)
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
                            Message = "El Id del proveedor es requerido"
                        });
                }

                _IProveedorService.Update(Model);
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
                        Message = $"No se pudo actualizar al proveedor >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo DELETE

        /// <summary>
        /// Metodo DELETE Proveedor
        /// Elimina un Proveedor por su Id
        /// router ("api/Proveedor") HttpMethod: DELETE
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
                            Message = "El Id del proveedor es requerido"
                        });
                }

                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = _IProveedorService.Delete(Id)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Response
                    {
                        IsSuccess = false, 
                        Message = $"No se pudo eliminar el proveedor >> {ex.Message}"
                    });
            }
        }

        #endregion

        #region Metodo GET({param})

        /// <summary>
        /// Metodo GET({Id}) Proveedor
        /// Busca un Proveedor por su Id
        /// Router ("api/Proveedor/{Id}") HttpMethod: GET
        /// </summary>
        /// <param name="Id">
        /// Tipo de dato: INT
        /// </param>
        /// <returns>
        /// Retorna un estado por su Id
        /// </returns>

        [HttpGet("{Id}")]
        public IActionResult GetProveedorById(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    return BadRequest(
                        new Response
                        {
                            IsSuccess = false,
                            Message = "El Id del proveedor es requerido"
                        });
                }

                return Ok(
                    new Response
                    {
                        IsSuccess = true,
                        Data = _IProveedorService.GetById(Id)
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
