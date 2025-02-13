using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeadsAndData.Utility;

public class CommonClass
{
    private const string _encryptionKey = "75430KGFRRRASDFGHYTERBBD00988###RRRRWTRGFSGF44BD9BBAF73549BFA3B2F79CEE672";  //we can change the code conversion key as per our requirement   

    public static string Encrypt(string encryptString)
    {

        byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);

        using (Aes encryptor = Aes.Create())

        {

            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_encryptionKey, new byte[] {

            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76

        });

            encryptor.Key = pdb.GetBytes(32);

            encryptor.IV = pdb.GetBytes(16);

            using (MemoryStream ms = new MemoryStream())

            {

                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))

                {

                    cs.Write(clearBytes, 0, clearBytes.Length);

                    cs.Close();

                }

                encryptString = Convert.ToBase64String(ms.ToArray());

            }

        }

        return encryptString;

    }

    public static string Decrypt(string cipherText)
    {
        cipherText = cipherText.Replace(" ", "+");

        byte[] cipherBytes = Convert.FromBase64String(cipherText);



        using (Aes encryptor = Aes.Create())

        {

            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_encryptionKey, new byte[] {

            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76

        });

            encryptor.Key = pdb.GetBytes(32);

            encryptor.IV = pdb.GetBytes(16);

            using (MemoryStream ms = new MemoryStream())

            {

                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))

                {

                    cs.Write(cipherBytes, 0, cipherBytes.Length);

                    cs.Close();

                }

                cipherText = Encoding.Unicode.GetString(ms.ToArray());

            }

        }

        return cipherText;

    }


    //public static TimeZoneInfo ARABIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("Arab Standard Time");

    public static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

    public static DateTime GlobalDateTime()
    {
        DateTime IndianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        return IndianTime;
    }

    public static DateTime GlobalDate()
    {
        DateTime IndianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        return IndianTime.Date;

    }
    public static TimeSpan GlobalTimeOnly()
    {

        DateTime IndianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        TimeSpan timee = IndianTime.TimeOfDay;
        return timee;

    }


   
    


    public static string DecryptForResetPassword(string cipherText)
    {
        if (cipherText == null)
        {
            throw new ArgumentNullException(nameof(cipherText), "cipherText cannot be null");
        }

        // Replace spaces with '+'
        cipherText = cipherText.Replace(" ", "+");

        // Convert base64 encoded string to byte array
        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using (Aes encryptor = Aes.Create())
        {
            // Create an instance of Rfc2898DeriveBytes with the given encryption key and salt
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_encryptionKey, new byte[] {
                0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
            });

            // Set the key and IV
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }

                // Convert decrypted byte array to string
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }

        return cipherText;
    }
}
