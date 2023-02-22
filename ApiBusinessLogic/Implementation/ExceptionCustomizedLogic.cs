using System;
using System.Collections.Generic;
using ApiBusinessLogic.Interfaces.General;
using ApiModel.General;
using Serilog;

namespace ApiBusinessLogic.Implementation
{
    public class ExceptionCustomizedLogic: IExceptionCustomizedLogic
    {
        public DictionaryErrors _dictionaryErrors = new DictionaryErrors();
        string _default = "¡Lo sentimos! Hubo un problema";

        public ExceptionCustomizedLogic()
        {
        }

        public Exception Decision(string option, Exception e)
        {
            Log.Error("ERROR: Type {exception}, message {message}, cause {cause}", e.GetType(), e.Message, e.StackTrace);
            //_exception.SendBadRequest(e);

            if (!(e is CustomizeException))
            {
                switch (option)
                {
                    case "Client":
                        return Client(e.Message);
                    default:
                        return Default();
                }
            }
            else
            {
                throw e;
            }
        }

        public Exception Client(string e)
        {
            foreach (KeyValuePair<string, string> error in _dictionaryErrors.Client)
            {
                if (e.Contains(error.Key))
                {
                    throw new CustomizeException(error.Value);
                }
            }
            throw new CustomizeException(_default);
        }

        public Exception Default()
        {
            throw new CustomizeException(_default);
        }
    }
}
