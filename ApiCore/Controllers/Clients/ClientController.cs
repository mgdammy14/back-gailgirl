using System;
using ApiBusinessLogic.Interfaces.Clients;
using ApiModel.Clients;
using ApiModel.Response.General;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers.Clients
{
    [Route("api/client")]
    public class ClientController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private IClientLogic _logic;
        public ClientController(IClientLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.GetClient());
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("consultDocument/{clientDocumentNumber}")]
        public IActionResult ConsultDocument(string clientDocumentNumber)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.ConsultDocument(clientDocumentNumber));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] Client dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.CreateClient(dto));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPut]
        public IActionResult UpdateClient([FromBody] Client dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.UpdateClient(dto));
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
