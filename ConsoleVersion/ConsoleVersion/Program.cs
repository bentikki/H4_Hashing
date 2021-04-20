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
            IBenchmarkTimer timer = new BenchmarkStopWatch();
            string menuSelection = string.Empty;
            Console.WriteLine("Current key: " + Convert.ToBase64String(generatedKey));

            do
            {
                Console.Write("Input to hash: ");
                string plaintTextInput = Console.ReadLine();

                Console.WriteLine("Use HMAC?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                menuSelection = Console.ReadLine();
                bool useHMAC = true;

                if (menuSelection == "2")
                    useHMAC = false;

                Console.WriteLine("Hashing menu:");
                Console.WriteLine("1. MD5");
                Console.WriteLine("2. SHA256");
                Console.WriteLine("3. SHA512");

                IHashingGenerator hasher = null;
                byte[] encryptedValue = null;
                menuSelection = Console.ReadLine();

                if (useHMAC)
                {
                    switch (menuSelection)
                    {
                        case "1":
                            hasher = new HmacHashingMD5();
                            break;
                        case "2":
                            hasher = new HmacHashingSHA256();
                            break;
                        case "3":
                            hasher = new HmacHashingSHA512();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (menuSelection)
                    {
                        case "1":
                            hasher = new HashingMD5();
                            break;
                        case "2":
                            hasher = new HashingSHA256();
                            break;
                        case "3":
                            hasher = new HashingSHA512();
                            break;
                        default:
                            break;
                    }
                }


                timer.Start();
                encryptedValue = hasher.HashInput(plaintTextInput, generatedKey);
                timer.Stop();
                Console.Write($"{hasher.Name} MAC: ");
                Console.Write(Convert.ToBase64String(encryptedValue));
                Console.WriteLine();
                Console.Write($"Benchmark: " + timer.TimingResult());

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press any key to compare:");
                Console.ReadKey();
                Console.WriteLine("Original Value   : " + Convert.ToBase64String(encryptedValue));
                Console.WriteLine("Compare Value    : " + Convert.ToBase64String(hasher.HashInput(plaintTextInput, generatedKey)));
                Console.WriteLine("Compare correct  : " + hasher.CheckAuthenticity(plaintTextInput, encryptedValue, generatedKey).ToString());

                Console.WriteLine();
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            } while (true);

            
        }
    }
}
