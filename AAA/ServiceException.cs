using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA
{
    public class ServiceException : Exception
    {
        public ServiceException(string msg, Exception ex) : base(msg, ex)
        {
        }
    }
}
