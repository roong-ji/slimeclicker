using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class Account
{
    public string Email;
    public string Password;

    private static readonly Regex EmailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );
    
    public Account(string email, string password)
    {
        if (string.IsNullOrEmpty(email)) throw new ArgumentException($"이메일은 비어있을 수 없습니다.");
        if (!EmailRegex.IsMatch(email)) throw new ArgumentException($"올바르지 않은 이메일 형식입니다.");
        if (string.IsNullOrEmpty(password)) throw new ArgumentException($"비밀번호는 비어있을 수 없습니다.");
        if (password.Length is < 6 or > 15) throw new ArgumentException($"비밀번호는 6~15자 사이여야 합니다.");
        
        Email = email;
        Password = password;
    }
}
