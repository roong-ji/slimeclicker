using System;
using UnityEngine;

public class AccountManager : Singleton<AccountManager>
{
    private const string SecurityKey = "SecretKeyForSave";

    private Account _account;
    public bool IsLogin => _account != null;
    public string Email => _account.Email ?? string.Empty;
    
    public bool TryLogin(string email, string password)
    {
        Account account;
        try
        {
            account = new Account(email, password);
        }
        catch (Exception ex)
        {
            return false;
        }
        
        var emailHash = Hash.GetHash(email);
        if (!PlayerPrefs.HasKey(emailHash))
        {
            return false;
        }
        
        var passwordHash = PlayerPrefs.GetString(emailHash);
        string passwordDecrypted;

        try
        {
            passwordDecrypted = AES.Decrypt(passwordHash, SecurityKey);
        }
        catch (Exception ex)
        {
            //_messageTextUI.text = "데이터 오류: 로그인 정보를 확인할 수 없습니다.";
            return false;
        }

        var inputPassword = Hash.GetHash(account.Password);
        if (inputPassword != passwordDecrypted)
        {
            //_messageTextUI.text = "패스워드를 확인해주세요";
            return false;
        }
        
        _account = account;
        return true;
    }

    public bool TryRegister(string email, string password)
    {
        var emailHash = Hash.GetHash(email);
        if (PlayerPrefs.HasKey(emailHash))
        {
            //_messageTextUI.text = "중복된 아이디입니다.";
            return false;
        }
        
        try
        {
            var account = new Account(email, password);
        }
        catch (Exception ex)
        {
            return false;
        }
 
        var passwordHash = Hash.GetHash(password);
        var encryptedPassword = AES.Encrypt(passwordHash, SecurityKey);
        PlayerPrefs.SetString(emailHash, encryptedPassword);
        return true;
    }

    public void Logout()
    {
        
    }
}