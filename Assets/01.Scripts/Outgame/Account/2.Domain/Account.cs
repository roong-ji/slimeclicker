using System;
using UnityEngine;

public class Account
{
    public string Email;
    public string Password;
    
    public Account(string email, string password)
    {
        var emailSpec = new AccountEmailSpecification();
        if (!emailSpec.IsSatisfiedBy(email))
        {
            throw new ArgumentException(emailSpec.ErrorMessage);
        }

        if (string.IsNullOrEmpty(password)) throw new ArgumentException($"비밀번호를 입력해주세요.");
        CheckPassword(password);
        
        Email = email;
        Password = password;
    }
    
    private void CheckPassword(string password)
    {
        if (!Reg.IsAllowedChars(password))
        {
            throw new ArgumentException("패스워드는 영어/숫자/특수문자만 가능합니다.");
        }

        if (!Reg.IsAllowedLength(password))
        {
            throw new ArgumentException($"패스워드는 {Reg.MinLength}자리 이상 {Reg.MaxLength}자리 이하여야 합니다.");
        }

        if (!Reg.HasSpecialChar(password))
        {
            throw new ArgumentException("패스워드는 특수문자를 하나 이상 포함해야 합니다.");
        }

        if (!Reg.HasUpperAndLower(password))
        {
            throw new ArgumentException("패스워드는 대소문자를 각 하나 이상 포함해야 합니다.");
        }
    }
}
