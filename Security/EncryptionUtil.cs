﻿namespace WebAppDBMVC01.Security
{
    public class EncryptionUtil
    {
        public static string Encrypt(string plainText)
        {
           var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(plainText);
            return encryptedPassword;
        }

        public static bool isValidPassword(string plainText, string cipherText) 
        {
            return BCrypt.Net.BCrypt.Verify(plainText, cipherText);
        }
    }
}
