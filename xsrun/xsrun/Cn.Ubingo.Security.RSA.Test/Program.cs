using Cn.Ubingo.Security.RSA.Core;
using Cn.Ubingo.Security.RSA.Data;
using Cn.Ubingo.Security.RSA.Key;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cn.Ubingo.Security.RSA.Test
{
    /// <summary>
    /// 陈服建(fochen,j@ubingo.cn)
    /// 2015-01-23
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //生成公私钥对
            KeyPair keyPair = KeyGenerator.GenerateKeyPair();

            //转换成不同的格式
            KeyPair asnKeyPair = keyPair.ToASNKeyPair();
            KeyPair xmlKeyPair = asnKeyPair.ToXMLKeyPair();
            KeyPair pemKeyPair = xmlKeyPair.ToPEMKeyPair();
            
            //获取公私钥
            string privateKey = xmlKeyPair.PrivateKey;
            string publicKey = xmlKeyPair.PublicKey;

            //加解密

            //XML
            KeyWorker privateWorker = new KeyWorker(privateKey, KeyFormat.XML);
            KeyWorker publicWorker = new KeyWorker(publicKey, KeyFormat.XML);
            
            Console.WriteLine(privateWorker.Decrypt(publicWorker.Encrypt("你好！世界")));
            Console.WriteLine(publicWorker.Decrypt(privateWorker.Encrypt("你好！中国")));

            //ASN
            privateWorker = new KeyWorker(asnKeyPair.PrivateKey, KeyFormat.ASN);
            publicWorker = new KeyWorker(asnKeyPair.PublicKey, KeyFormat.ASN);

            Console.WriteLine(privateWorker.Decrypt(publicWorker.Encrypt("你好！世界")));
            Console.WriteLine(publicWorker.Decrypt(privateWorker.Encrypt("你好！中国")));

            //PEM
            privateWorker = new KeyWorker(pemKeyPair.PrivateKey, KeyFormat.PEM);
            publicWorker = new KeyWorker(pemKeyPair.PublicKey, KeyFormat.PEM);

            Console.WriteLine(privateWorker.Decrypt(publicWorker.Encrypt("你好！世界")));
            Console.WriteLine(publicWorker.Decrypt(privateWorker.Encrypt("你好！中国")));
        }
    }
}
