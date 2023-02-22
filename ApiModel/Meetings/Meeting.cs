using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.Meetings
{
    public class Meeting
    {
        [Key]
        public int idMeeting { get; set; }
        public int idClient { get; set; }
        public DateTime meetingDate { get; set; }
        public string collaborator { get; set; }
        public decimal totalPay { get; set; }
        public int idPaymentMethod { get; set; }
        public int idMeetingStatus { get; set; }
    }
}
