using UnityEngine;
using System.IO;
using System;

public static class FileIO
{
    private static readonly string s_securityKey = "SecretKeyForSave";
    private static readonly byte[] s_hashedKey;

    static FileIO()
    {
        s_hashedKey = AES.GetHashedKey(s_securityKey);
    }

    public static void Save<T>(T data, string filePath)
    {
        string json = JsonUtility.ToJson(data);

        using var fileStream = new FileStream(filePath, FileMode.Create);
        AES.Encrypt(fileStream, json, s_hashedKey);
    }

    public static bool Load<T>(T data, string filePath)
    {
        if (!File.Exists(filePath)) return false;

        using var fileStream = new FileStream(filePath, FileMode.Open);
        var json = string.Empty;

        try
        {
            json = AES.Decrypt(fileStream, s_hashedKey);
        }
        catch (Exception exception)
        {
            return false;
        }

        JsonUtility.FromJsonOverwrite(json, data);

        return true;
    }
}
