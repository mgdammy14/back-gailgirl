using System;
using System.Collections.Generic;
using ApiModel.Services;

namespace ApiBusinessLogic.Interfaces.Services
{
    public interface IServiceLogic
    {
        public IEnumerable<Service> GetServices();
        public int CreateService(Service dto);
        public bool UpdateService(Service dto);
        public bool DeleteService(int idService);
    }
}
