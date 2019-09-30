using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace SpotMe_.Models
{
    public class Encrypt
    {
        public static string CreateMD5(string password)
        {
            MD5 md5hash = MD5.Create();
            string encrypted = GetMd5Hash(md5hash, password);
            string word = "";
            for(int i = 0; i < 30; i ++) // Max length of password
            {
                word += encrypted[i];
            }
            password = word;
            return password;
        }

        //From https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netframework-4.8
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static string CreateHash(string name) ///////// For hashing ids????
        {
            MD5 md5hash = MD5.Create();
            string encrypted = GetHash(md5hash, name);
            string word = "";
            for (int i = 0; i < 30; i++) // Max length of password
            {
                word += encrypted[i];
            }
            name = word;
            return name;
        }

        //From https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netframework-4.8
        static string GetHash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
