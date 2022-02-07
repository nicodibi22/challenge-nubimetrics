using challenge_nubimetrics_models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace challenge_nubimetrics_services.Utils
{
    public class PasswordHasher : IPasswordHasher<UsuarioEntity>
    {
        public string HashPassword(UsuarioEntity user, string password)
        {
            using (SHA256 mySHA256 = SHA256Managed.Create())
            {
                byte[] hash = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder hashSB = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    hashSB.Append(hash[i].ToString("x2"));
                }
                return hashSB.ToString();
            }
        }

        public PasswordVerificationResult VerifyHashedPassword(UsuarioEntity user, string hashedPassword, string providedPassword)
        {
            if (hashedPassword == HashPassword(user, providedPassword))
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }
}
