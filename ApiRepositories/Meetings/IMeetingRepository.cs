using System;
using ApiModel.Meetings;
using ApiRepositories.General;

namespace ApiRepositories.Meetings
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
    }
}
