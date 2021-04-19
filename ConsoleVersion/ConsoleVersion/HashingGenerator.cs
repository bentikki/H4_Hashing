using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    class HashingGenerator
    {
        protected byte[] StringToByteArray(string s)
        {
            byte[] inputByteArray = Encoding.ASCII.GetBytes(s);
            return inputByteArray;
        }
        protected bool CompareByteArrays(byte[] arrayOne, byte[] arrayTwo, int arrayLen)
        {
            try
            {
                for (int i = 0; i < arrayLen; i++)
                {
                    if (arrayOne[i] != arrayTwo[i])
                        throw new Exception("Not_Compareable");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
