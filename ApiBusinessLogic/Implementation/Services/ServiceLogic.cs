using System;
using System.Collections.Generic;
using ApiBusinessLogic.Interfaces.Services;
using ApiModel.Services;
using ApiUnitOfWork.General;

namespace ApiBusinessLogic.Implementation.Services
{
    public class ServiceLogic : IServiceLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Service> GetServices()
        {
            try
            {
                return _unitOfWork.IService.GetList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int CreateService(Service dto)
        {
            try
            {
                return _unitOfWork.IService.Insert(dto);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool UpdateService(Service dto)
        {
            try
            {
                return _unitOfWork.IService.Update(dto);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool DeleteService(int idService)
        {
            try
            {
                Service dto = new Service();
                dto.id = idService;
                return _unitOfWork.IService.Delete(dto);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
