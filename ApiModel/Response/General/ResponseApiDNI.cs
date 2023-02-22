using System;
namespace ApiModel.Response.General
{
    public class ResponseApiDNI
    {
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string nombres { get; set; }
    }
}
