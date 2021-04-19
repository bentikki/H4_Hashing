using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    class HashingMD5 : HashingGenerator, IHashingGenerator
    {
        private string name = "MD5";
        public string Name { get { return this.name; } }

        public override byte[] HashInput(string inputString, byte[] key)
        {
            byte[] inputByteArray = this.StringToByteArray(inputString);

            using (var hashingService = MD5.Create())
            {
                return hashingService.ComputeHash(inputByteArray);
            }
        }
    }
}
