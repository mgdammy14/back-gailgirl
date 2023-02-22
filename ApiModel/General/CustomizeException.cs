using System;
namespace ApiModel.General
{
    public class CustomizeException:Exception
    {
        public CustomizeException(string message) : base(message)
        {
        }
    }
}
