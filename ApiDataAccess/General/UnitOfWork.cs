using System;
using ApiDataAccess.Clients;
using ApiDataAccess.Services;
using ApiRepositories.Clients;
using ApiRepositories.Meetings;
using ApiRepositories.Services;
using ApiUnitOfWork.General;

namespace ApiDataAccess.General
{
    public class UnitOfWork: IUnitOfWork
    {
        public IClientRepository IClient { get; set; }
        public IServiceRepository IService { get; set; }
        //public IMeetingRepository IMeeting { get; set; }

        public UnitOfWork(string connectionString)
        {
            IClient = new ClientRepository(connectionString);
            IService = new ServiceRepository(connectionString);
            //IMeeting = new MeetingRepository(connectionString);
        }
    }
}
