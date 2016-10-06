using Hna.Cooperation.EKing.EIP.Security.CSInteropKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Hna.Cooperation.EKing.EIP.Security.RSA
{
    public class Key
    {
        private RSAParameters _key;
        private string _asn;
        internal Key(RSAParameters key)
        {
            this._key = key;
        }

        public string ToASNKey()
        {
            if (_asn == null)
            {
                AsnKeyBuilder.AsnMessage asn = AsnKeyBuilder.PrivateKeyToPKCS8(this._key);
                _asn = Convert.ToBase64String(asn.GetBytes());
            }

            return _asn;
        }

        public string ToXMLKey()
        {

        }
    }
}
