using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Domain
{
    public class Security
    {
        public static string ToSHA512(string input)
        {
            using SHA512 sha512Hash = SHA512.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
            return BitConverter.ToString(hashBytes).Replace("-", String.Empty);
        }
    }
}
