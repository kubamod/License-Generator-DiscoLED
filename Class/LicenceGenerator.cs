using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace DiscoLedCracker.Class
{
    public class LicenceGenerator
    {
        public byte[] SaveToBytes(LicenseData licenseData)
        {
            DeriveBytes deriveBytes = (DeriveBytes)new PasswordDeriveBytes(Password._password, new byte[13]
            {
                (byte) 73,
                (byte) 118,
                (byte) 97,
                (byte) 110,
                (byte) 32,
                (byte) 77,
                (byte) 101,
                (byte) 100,
                (byte) 118,
                (byte) 101,
                (byte) 100,
                (byte) 101,
                (byte) 118
            });
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = deriveBytes.GetBytes(32);
            rijndael.IV = deriveBytes.GetBytes(16);
            using (MemoryStream memoryStream1 = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream1, rijndael.CreateEncryptor(),
                    CryptoStreamMode.Write))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter((Stream)cryptoStream))
                    {
                        using (MemoryStream memoryStream2 = new MemoryStream())
                        {
                            new XmlSerializer(typeof(LicenseData)).Serialize((Stream)memoryStream2,
                                (object)licenseData);
                            byte[] buffer1 = memoryStream2.GetBuffer();
                            byte[] hash = SHA256.Create().ComputeHash(buffer1);
                            binaryWriter.Write(buffer1.Length + hash.Length);
                            binaryWriter.Write(buffer1);
                            binaryWriter.Write(hash);
                            binaryWriter.Flush();
                            cryptoStream.FlushFinalBlock();
                            memoryStream1.Position = 0L;
                            byte[] buffer2 = new byte[memoryStream1.Length];
                            memoryStream1.Read(buffer2, 0, buffer2.Length);
                            return buffer2;
                        }
                    }
                }
            }
        }

    }
}
