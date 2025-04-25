using System.Security.Cryptography;
using UniversityHousingSystem.Service.Abstractions.Helpers;

namespace UniversityHousingSystem.Service.implementation.Helpers
{
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";
        private const string SpecialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";

        private static readonly string AllChars = Uppercase + Lowercase + Digits + SpecialChars;


        public string Generate(int length = 12)
        {
            if (length < 4)
                throw new ArgumentException("Password length must be at least 4 to meet complexity requirements.");

            var password = new char[length];

            // Ensure each required character type is included
            password[0] = GetRandomChar(Uppercase);
            password[1] = GetRandomChar(Lowercase);
            password[2] = GetRandomChar(Digits);
            password[3] = GetRandomChar(SpecialChars);

            // Fill the rest with random characters from all allowed characters
            for (int i = 4; i < length; i++)
            {
                password[i] = GetRandomChar(AllChars);
            }

            // Shuffle to avoid predictable positions
            return Shuffle(password);
        }

        private static char GetRandomChar(string charSet)
        {
            byte[] buffer = new byte[4];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
                uint num = BitConverter.ToUInt32(buffer, 0);
                return charSet[(int)(num % (uint)charSet.Length)];
            }
        }

        private static string Shuffle(char[] array)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                for (int i = array.Length - 1; i > 0; i--)
                {
                    byte[] buffer = new byte[4];
                    rng.GetBytes(buffer);
                    int j = (int)(BitConverter.ToUInt32(buffer, 0) % (uint)(i + 1));
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
            return new string(array);
        }
    }
}
