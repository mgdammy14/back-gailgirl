using System;
namespace ApiBusinessLogic.Interfaces.General
{
    public interface IExceptionCustomizedLogic
    {
        public Exception Decision(string option, Exception e);
    }
}
