using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Exceptions
{
    public class InActiveUserException:Exception
    {
        public InActiveUserException(string message) : base(message)
        {
        }
    }
}
