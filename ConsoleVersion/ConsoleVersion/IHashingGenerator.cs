using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    interface IHashingGenerator
    {
        string Name { get; }
        byte[] HashInput(string inputString, byte[] key);
        bool CheckAuthenticity(string inputString, byte[] hash, byte[] key);
    }
}
