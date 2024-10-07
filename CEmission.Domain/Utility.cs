using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Domain {
    public class Utility {
        public static string Encriptar(string texto) {
            using (var sha256 = SHA256.Create()) {
                var bytes = Encoding.UTF8.GetBytes(texto);
                var hash = sha256.ComputeHash(bytes);
                var sb = new StringBuilder();
                foreach (byte b in hash) {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static string GenerateRandomPassword() {
            Random Random = new Random();
            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";
            string specials = ".!?*";
            var password = new char[8];

            for (var i = 0; i < 6; i++) {
                password[i] = letters[Random.Next(letters.Length)];
            }
            password[6] = digits[Random.Next(digits.Length)];
            password[7] = specials[Random.Next(specials.Length)];
            password = password.OrderBy(x => Random.Next()).ToArray();
            return new string(password);
        }
    }
}
