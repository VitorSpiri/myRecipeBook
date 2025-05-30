﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

    namespace MyRecipeBook.Application.Criptography
    {
        public class PasswordEncripter
        {
            public string Encrypt(string password)
            {
                var chaveAdicionar = "ABC";

                var newPassword = $"{password}{chaveAdicionar}";

                var bytes = Encoding.UTF8.GetBytes(newPassword);
                var hashBytes = SHA512.HashData(bytes);

                return StringBytes(hashBytes);
            }

            public static string StringBytes(byte[] bytes)
            {
                var sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    var hex = b.ToString("x2");
                    sb.Append(b);
                }

                return sb.ToString();
            }

        }
    }
