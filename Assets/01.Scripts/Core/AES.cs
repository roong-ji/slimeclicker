using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public static class AES
{
    private const int IVSize = 16;
    
    public static string Encrypt(string plainText, string password)
    {
        var key = GetHashedKey(password);
        var textBytes = Encoding.UTF8.GetBytes(plainText);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.GenerateIV();
        var iv = aes.IV;

        using var encryptor = aes.CreateEncryptor();
        var encryptedBytes = encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);

        var combinedBytes = new byte[iv.Length + encryptedBytes.Length];
        Buffer.BlockCopy(iv, 0, combinedBytes, 0, iv.Length);
        Buffer.BlockCopy(encryptedBytes, 0, combinedBytes, iv.Length, encryptedBytes.Length);

        return Convert.ToBase64String(combinedBytes);
    }

    public static string Decrypt(string cipherText, string password)
    {
        var key = GetHashedKey(password);
        var combinedBytes = Convert.FromBase64String(cipherText);

        using var aes = Aes.Create();
        aes.Key = key;

        var iv = new byte[IVSize];
        var encryptedBytes = new byte[combinedBytes.Length - IVSize];
        Buffer.BlockCopy(combinedBytes, 0, iv, 0, IVSize);
        Buffer.BlockCopy(combinedBytes, IVSize, encryptedBytes, 0, encryptedBytes.Length);

        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor();
        var decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

        return Encoding.UTF8.GetString(decryptedBytes);
    }
    
    public static void Encrypt(Stream outStream, string text, byte[] key)
    {
        var textBytes = Encoding.UTF8.GetBytes(text);
        
        using var aes = Aes.Create();
        aes.Key = key;
        aes.GenerateIV();

        outStream.Write(aes.IV, 0, aes.IV.Length);

        using var encryptor = aes.CreateEncryptor();
        using var cryptoStream = new CryptoStream(outStream, encryptor, CryptoStreamMode.Write);
    
        cryptoStream.Write(textBytes, 0, textBytes.Length);
        cryptoStream.FlushFinalBlock();
    }
    
    public static string Decrypt(Stream inStream, byte[] key)
    {
        using var aes = Aes.Create();
        aes.Key = key;

        var iv = new byte[IVSize];
        inStream.Read(iv, 0, IVSize);
        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor();
        using var cryptoStream = new CryptoStream(inStream, decryptor, CryptoStreamMode.Read);
        
        using var reader = new StreamReader(cryptoStream, Encoding.UTF8);
        return reader.ReadToEnd();
    }

    public static byte[] GetHashedKey(string input)
    {
        using var sha256 = SHA256.Create();
        
        var inputBytes = Encoding.UTF8.GetBytes(input); 
        return sha256.ComputeHash(inputBytes);
    }
}
