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

        public byte[] HashInput(string inputString, byte[] key)
        {
            byte[] inputByteArray = this.StringToByteArray(inputString);

            using (var hmac = new HMACSHA512(key))
            {
                return hmac.ComputeHash(inputByteArray);
            }
        }

        public bool CheckAuthenticity(string inputString, byte[] hash, byte[] key)
        {
            return this.CompareByteArrays(this.HashInput(inputString, key), hash, hash.Length);
        }
    }
}
