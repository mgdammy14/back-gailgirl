using System;
using ApiRepositories.Clients;
using ApiRepositories.Meetings;
using ApiRepositories.Services;

namespace ApiUnitOfWork.General
{
    public interface IUnitOfWork
    {
        public IClientRepository IClient { get; set; }
        public IServiceRepository IService { get; set; }
        //public IMeetingRepository IMeeting { get; set; }
        //public IMeetingDetailRepository IMeetingDetail { get; set; }
        //public IMeetingStatusRepository IMeetingStatus { get; set; }
    }
}
