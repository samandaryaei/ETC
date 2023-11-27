﻿using System.Security.Cryptography;
using System.Text;

namespace ETC.PoliceInquery.DTOs.Request
{
    public class BaseRequestDto
    {
        [NonSerialized]
        private readonly byte[] _salt = new byte[32]; //TODO مقدار را باید از پلیس گرفت
        public virtual string SignData { get; set; }
        protected string GenSign(string param)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] paramBytes = Encoding.UTF8.GetBytes(param);
                byte[] saltedParamBytes = new byte[paramBytes.Length + _salt.Length];

                Buffer.BlockCopy(_salt, 0, saltedParamBytes, 0, _salt.Length);
                Buffer.BlockCopy(paramBytes, 0, saltedParamBytes, _salt.Length, paramBytes.Length);

                byte[] hashBytes = sha512.ComputeHash(saltedParamBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Convert each byte to its hexadecimal representation
                }

                return sb.ToString();
            }
        }
    }
}




//نمونه کد ناجی در مستندات
//string GenSign(String param)
//{
//    MessageDigest md = MessageDigest.GetInstance("SHA-512");
//    byte[] salt = { x, x, x, x, x, x, x, x, x, x, x, x, x, x, x, x};
//    md.update(salt);
//    byte[] dg = md.digest(param.getBytes());
//    StringBuilder sb = new StringBuilder();
//    for (int i = 0; i < dg.length; i++)
//    {
//        sb.append(Integer.toString((dg[i] & 0xff) + 0x100, 16).substring(1));
//    }
//    return sb.toString();
//}
