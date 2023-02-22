using System;
using System.Collections.Generic;
using ApiModel.Clients;

namespace ApiBusinessLogic.Interfaces.Clients
{
    public interface IClientLogic
    {
        public IEnumerable<Client> GetClient();
        public Client CreateClient(Client dto);
        public Client UpdateClient(Client dto);
        public Client ConsultDocument(string clientDocumentNumber);
    }
}
