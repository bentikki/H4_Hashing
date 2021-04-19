using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            int keySize = 32;
            var generatedKey = KeyGenerator.GenerateKey(keySize);
            Console.WriteLine("Current key: " + Convert.ToBase64String(generatedKey));

            Console.Write("Input to hash: ");
            string plaintTextInput = Console.ReadLine();

            Console.WriteLine("Hashing menu:");
            Console.WriteLine("1. MD5");
            Console.WriteLine("2. SHA512");

            IHashingGenerator hasher = null;
            byte[] encryptedValue = null;
            string menuSelection = Console.ReadLine();

            switch (menuSelection)
            {
                case "1":
                    hasher = new HashingMD5();
                    break;
                case "2":
                    hasher = new HashingSHA512();
                    break;
                default:
                    break;
            }

            encryptedValue = hasher.HashInput(plaintTextInput, generatedKey);
            Console.Write($"{hasher.Name} MAC: ");
            Console.Write(Convert.ToBase64String(encryptedValue));
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Press any key to compare:");
            Console.WriteLine("Original Value   : " + Convert.ToBase64String(encryptedValue));
            Console.WriteLine("Compare Value    : " + Convert.ToBase64String(hasher.HashInput(plaintTextInput, generatedKey)));
            Console.WriteLine("Compare correct  : " + hasher.CheckAuthenticity(plaintTextInput, encryptedValue, generatedKey).ToString()); 

            Console.WriteLine();
            Console.WriteLine("Press any key to Exit....");
            Console.ReadKey();
        }
    }
}
