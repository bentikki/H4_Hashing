using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVersion
{
    // Abstract super class. Contains supporting funtions for HashingGenerators.
    abstract class HashingGenerator
    {

        protected byte[] StringToByteArray(string s)
        {
            byte[] inputByteArray = Encoding.ASCII.GetBytes(s);
            return inputByteArray;
        }

        /// <summary>
        /// Compare hashed byte arrays, to make sure no changes has been made. 
        /// Takes 3 parameters.
        /// </summary>
        /// <param name="arrayOne">Takes first byte array to compare</param>
        /// <param name="arrayTwo">Takes second byte array to compare</param>
        /// <returns></returns>
        /// 

        protected bool CompareByteArrays(byte[] arrayOne, byte[] arrayTwo)
        {
            try
            {
                if (arrayOne.Length != arrayTwo.Length)
                    throw new Exception("Not_Compareable_Lenght");
                
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    if (arrayOne[i] != arrayTwo[i])
                        throw new Exception("Not_Compareable_content");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Abstract. Hashes input based on child object function.
        /// </summary>
        /// <param name="inputString">String to be hashed.</param>
        /// <param name="key">Hashing key</param>
        /// <returns></returns>
        public abstract byte[] HashInput(string inputString, byte[] key);

        /// <summary>
        /// Checks authenticity of hash, by comparing input string to allready known hash.
        /// Takes key as argument.
        /// </summary>
        /// <param name="inputString">Plain text string to compare</param>
        /// <param name="hash">Allready hashed value.</param>
        /// <param name="key">Key to be used when hashing.</param>
        /// <returns></returns>
        public bool CheckAuthenticity(string inputString, byte[] hash, byte[] key)
        {
            return this.CompareByteArrays(this.HashInput(inputString, key), hash);
        }
    }
}
