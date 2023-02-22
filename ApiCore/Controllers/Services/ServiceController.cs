using System;
using ApiBusinessLogic.Interfaces.Services;
using ApiModel.Response.General;
using ApiModel.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers.Services
{
    [Route("api/service")]
    public class ServiceController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private IServiceLogic _logic;
        public ServiceController(IServiceLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.GetServices());
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost]
        public IActionResult CreateService([FromBody] Service dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.CreateService(dto));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPut]
        public IActionResult UpdateService([FromBody] Service dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.UpdateService(dto));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("{idService:int}")]
        public IActionResult DeleteService(int idService)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.DeleteService(idService));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }
    }
}
