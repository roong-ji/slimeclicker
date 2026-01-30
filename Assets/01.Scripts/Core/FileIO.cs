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
        
#if UNITY_EDITOR
        Debug.Log($"<color=yellow>[암호화됨]</color> {json}");
        Debug.Log($"<color=green>[데이터 저장 성공]</color> {filePath}");
#endif
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
#if UNITY_EDITOR
            Debug.Log($"<color=red>[데이터 로드 실패]</color> {exception.Message}");
#endif
            return false;
        }

        JsonUtility.FromJsonOverwrite(json, data);
        
#if UNITY_EDITOR
        Debug.Log("<color=cyan>[데이터 로드 성공]</color>");
#endif

        return true;
    }
}
