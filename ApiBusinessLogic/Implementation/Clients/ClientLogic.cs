using System;
using System.Collections.Generic;
using ApiBusinessLogic.Interfaces.Clients;
using ApiModel.Clients;
using ApiModel.Response.General;
using ApiUnitOfWork.General;
using System.Text.Json;
using RestSharp;
using ApiBusinessLogic.Interfaces.General;

namespace ApiBusinessLogic.Implementation.Clients
{
    public class ClientLogic : IClientLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private IExceptionCustomizedLogic _logicExceptionCustomizedLogic;
        private string _option;

        public ClientLogic(IUnitOfWork unitOfWork, IExceptionCustomizedLogic exceptionCustomizedLogic)
        {
            _unitOfWork = unitOfWork;
            _logicExceptionCustomizedLogic = exceptionCustomizedLogic;
            _option = "Client";
        }

        public IEnumerable<Client> GetClient()
        {
            try
            {
                return _unitOfWork.IClient.GetList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Client ConsultDocument(string clientDocumentNumber)
        {
            try
            {
                Client response = new Client();

                //get the information returned by the api
                var client = new RestClient("https://api.apis.net.pe/v1/dni?numero=" + clientDocumentNumber);
                var request = new RestRequest();

                request.Method = Method.Get;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", "Bearer apis-token-3781");
                //request.AddParameter("application/json", strJSONContent, ParameterType.RequestBody);

                var apiReponse = client.Execute(request);

                var statusResponse = apiReponse.StatusDescription;

                if(statusResponse == "Not Found")
                {
                    throw new Exception("NotFoundDocument");
                }

                else
                {
                    var clientByDocumentNumber = _unitOfWork.IClient.LookClient(clientDocumentNumber);
                    if (clientByDocumentNumber is null)
                    {
                        var JsonApiResponse = JsonSerializer.Deserialize<ResponseApiDNI>(apiReponse.Content);

                        response.clientDocumentNumber = JsonApiResponse.numeroDocumento;
                        response.clientName = JsonApiResponse.nombres;
                        response.clientLastname = JsonApiResponse.apellidoPaterno + ' ' + JsonApiResponse.apellidoMaterno;
                    }
                    else
                    {
                        throw new Exception("CustomerExists");
                    }

                    
                }
                return response;
            }
            catch(Exception e)
            {
                throw _logicExceptionCustomizedLogic.Decision(_option, e);
            }
        }

        public Client CreateClient(Client dto)
        {
            try
            {
                Client response = new Client();
                //buscamos si existe el cliente
                var clientByDocumentNumber = _unitOfWork.IClient.LookClient(dto.clientDocumentNumber);
                if (clientByDocumentNumber is null)
                {
                    response = dto;
                    response.id = _unitOfWork.IClient.Insert(dto);
                }
                else
                {
                    throw new Exception("CustomerExists");
                }
                
                return response;
            }
            catch(Exception e)
            {
                throw _logicExceptionCustomizedLogic.Decision(_option, e);
            }
        }

        public Client UpdateClient(Client dto)
        {
            try
            {
                Client response = new Client();
                var updateResponse = _unitOfWork.IClient.Update(dto);
                if(updateResponse)
                {
                    response = dto;
                }
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
