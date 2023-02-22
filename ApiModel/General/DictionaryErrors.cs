using System;
using System.Collections.Generic;

namespace ApiModel.General
{
    public class DictionaryErrors
    {
        public Dictionary<String, string> Client = new Dictionary<string, string>
        {
            {"unAuthorized", "El usuario o la clave ingresada es incorrecta" },
            {"CustomerExists", "El cliente ya existe en el sistema" },
            {"NotFoundDocument", "El numero de documento no tiene datos" }
        };
    }
}
