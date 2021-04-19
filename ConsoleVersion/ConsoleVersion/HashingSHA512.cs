using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    class HashingSHA512 : HashingGenerator, IHashingGenerator
    {
        private string name = "SHA512";
        public string Name { get { return this.name; } }

        public override byte[] HashInput(string inputString, byte[] key)
        {
            byte[] inputByteArray = this.StringToByteArray(inputString);

            using (var hmac = new HMACSHA512(key))
            {
                return hmac.ComputeHash(inputByteArray);
            }
        }

    }
}
