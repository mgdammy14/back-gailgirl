using System;
using ApiModel.Clients;
using ApiRepositories.General;

namespace ApiRepositories.Clients
{
    public interface IClientRepository : IRepository<Client>
    {
        public Client LookClient(string documentNumber);
    }
}
