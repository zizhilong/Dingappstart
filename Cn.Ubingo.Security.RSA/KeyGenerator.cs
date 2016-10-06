using Cn.Ubingo.Security.Interop;
using Cn.Ubingo.Security.RSA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cn.Ubingo.Security.RSA.Key
{
    /// <summary>
    /// 陈服建(fochen,j@ubingo.cn)
    /// 2015-01-23
    /// </summary>
    public class KeyGenerator
    {
        /// <summary>
        /// for java
        /// </summary>
        /// <returns></returns>
        static public KeyPair GenerateKeyPair(KeyFormat format = KeyFormat.XML)
        {
            KeyPair keyPair = new KeyPair(format);

            return keyPair;
        }
    }
}
