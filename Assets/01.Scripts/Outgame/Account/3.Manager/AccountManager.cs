using System;
using UnityEngine;

public class AccountManager : Singleton<AccountManager>
{
    private const string SecurityKey = "SecretKeyForSave";

    private Account _account;
    public bool IsLogin => _account != null;
    public string Email => _account.Email ?? string.Empty;
    
    public AuthResult TryLogin(string email, string password)
    {
        Account account;
        try
        {
            account = new Account(email, password);
        }
        catch (Exception ex)
        {
            return new AuthResult
            (
                success: false,
                message: ex.Message
            );
        }
        
        var emailHash = Hash.GetHash(email);
        if (!PlayerPrefs.HasKey(emailHash))
        {
            return new AuthResult
            (
                success: false,
                message: "아이디가 존재하지 않습니다."
            );
        }
        
        var passwordHash = PlayerPrefs.GetString(emailHash);
        string passwordDecrypted;

        try
        {
            passwordDecrypted = AES.Decrypt(passwordHash, SecurityKey);
        }
        catch
        {
             return new AuthResult
             (
                 success: false,
                 message: "데이터 오류: 로그인 정보를 확인할 수 없습니다."
             );
        }

        var inputPassword = Hash.GetHash(account.Password);
        if (inputPassword != passwordDecrypted)
        {
            return new AuthResult
            (
                success: false,
                message: "패스워드가 일치하지 않습니다."
            );
        }
        
        _account = account;
        return new AuthResult
        (
            success: true,
            message: "* 로그인 성공",
            account: _account
        );
    }

    public AuthResult TryRegister(string email, string password)
    {
        var emailHash = Hash.GetHash(email);
        if (PlayerPrefs.HasKey(emailHash))
        {
            return new AuthResult
            (
                success: false,
                message: "이미 존재하는 아이디입니다."
            );
        }
        
        try
        {
            var account = new Account(email, password);
        }
        catch (Exception ex)
        {
            return new AuthResult
            (
                success: false,
                message: ex.Message
            );
        }
 
        var passwordHash = Hash.GetHash(password);
        var encryptedPassword = AES.Encrypt(passwordHash, SecurityKey);
        PlayerPrefs.SetString(emailHash, encryptedPassword);
        return new AuthResult
        (
            success: true,
            message: "* 아이디가 생성되었습니다."
        );
    }

    public void Logout()
    {
        
    }
}