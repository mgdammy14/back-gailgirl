using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.Meetings
{
    public class MeetingStatus
    {
        [Key]
        public int idMeetingStatus { get; set; }
        public string statusName { get; set; }
        public string statusDescription { get; set; }
    }
}
