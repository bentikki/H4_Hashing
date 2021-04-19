using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    class HmacHashingMD5 : HashingGenerator, IHashingGenerator
    {
        private string name = "MD5";
        public string Name { get { return this.name; } }

        public override byte[] HashInput(string inputString, byte[] key)
        {
            byte[] inputByteArray = this.StringToByteArray(inputString);

            using (var hmac = new HMACMD5(key))
            {
                return hmac.ComputeHash(inputByteArray);
            }
        }
    }
}
