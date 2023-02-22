using Dapper.Contrib.Extensions;

namespace ApiModel.Clients
{
    public class Client
    {
        [Key]
        public int id { get; set; }
        public string clientDocumentNumber { get; set; }
        public string clientName { get; set; }
        public string clientLastname { get; set; }
        public string clientAddress { get; set; }
        public string clientPhone { get; set; }
    }
}
