using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils
{
    public interface ILogger
    {

        void LogMessage(System.Exception exception);
        
    }
}
