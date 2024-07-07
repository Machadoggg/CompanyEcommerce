using System;
using Company.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Logging;

namespace Company.Ecommerce.Transversal.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        public void LogInformation(string message, params object[] args)
        { 
        }

        public void LogWarning(string message, params object[] args)
        {
        }

        public void LogError(string message, params object[] args)
        {
        }
    }
}
