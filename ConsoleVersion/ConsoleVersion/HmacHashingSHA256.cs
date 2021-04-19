using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    class HmacHashingSHA256 : HashingGenerator, IHashingGenerator
    {
        private string name = "SHA256";
        public string Name { get { return this.name; } }

        public override byte[] HashInput(string inputString, byte[] key)
        {
            byte[] inputByteArray = this.StringToByteArray(inputString);

            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(inputByteArray);
            }
        }

        
    }
}
