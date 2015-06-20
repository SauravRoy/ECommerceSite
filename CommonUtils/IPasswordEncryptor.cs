using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils
{
    interface IPasswordEncryptor
    {
        byte[] Encrypt(string password);
        string Dycrypt(byte[] password);

    }
}
