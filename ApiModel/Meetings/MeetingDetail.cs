using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.Meetings
{
    public class MeetingDetail
    {
        [Key]
        public int idMeetingDetail { get; set; }
        public int idMeeting { get; set; }
        public int idService { get; set; }
    }
}
