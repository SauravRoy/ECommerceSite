using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils
{
    public interface IMail
    {

        void SendMail(string Email,string password);
        void Notify(string Email);

    }
}
