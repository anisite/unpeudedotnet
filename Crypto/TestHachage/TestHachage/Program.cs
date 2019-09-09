using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace TestHachage
{
    class Program
    {
        static void Main(string[] args)
        {
            var listeNAS = new[] { "123123123", "123123123", "123456789", "987654321" };

            var listeSalt = new[] {
                "9ea06ad1e0b98873ad9187da93fa4256",
                "0aa224cdd95bc746c240044af429eb4e",
                "62b9e822e8001e92e7869fac9accd7b0",
                "b45b19e3f9b44fbea4b7b7d38dc1ec3e",
                "86cb72ddc049b04ce6cb7d58c7be9a37",
                "12400ed6b95e573d01e376c3b60434ef",
                "17f4d2bc43aeee4a37091704224de2a0",
                "cfec6f37a2e4f6679531e7b44735af07",
                "ba3b69eb11b156927faede6c6f5b6d1d",
                "6b6231242838b2110aa82ed4876c3486",
                "3d3abeb0fcb16bf7b868248715a17630",
                "59507d0b7c969c5cb742e00c749e5ad1",
                "3c669aa29f58aa37d239f5519fd7517c",
                "7266e2166f3eabf9c8deb24ee1d4ede2",
                "d6963586d80581e11a6591d73aab2969",
                "da4c7da1ab5b6f8a08ab0ae0596006ee"
            };

            foreach (var i in listeNAS)
            {
                //Convertir le nas en hex
                var nas = Int32.Parse(i);
                var hex = nas.ToString("X2");

                var pos = Int32.Parse(hex[0].ToString(), System.Globalization.NumberStyles.HexNumber);
                //Choisir un des 16 salt
                var salt = Encoding.UTF8.GetBytes(listeSalt[pos - 1]);

                var result = KeyDerivation.Pbkdf2(hex, salt, KeyDerivationPrf.HMACSHA256, 10001, 60);

                Console.WriteLine(Convert.ToBase64String(result));
            }

            Console.ReadLine();
        }
    }
}
