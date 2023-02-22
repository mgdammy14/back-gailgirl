using System;
using ApiDataAccess.General;
using ApiModel.Services;
using ApiRepositories.Services;

namespace ApiDataAccess.Services
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
