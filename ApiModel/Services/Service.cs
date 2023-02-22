using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.Services
{
    public class Service
    {
        [Key]
        public int id { get; set; }
        public string serviceName { get; set; }
        public string serviceDescription { get; set; }
        public decimal servicePrice { get; set; }
        public decimal serviceEstimatedTime { get; set; }
    }
}
