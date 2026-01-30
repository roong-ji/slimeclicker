using System;
using System.Text.RegularExpressions;

public class AccountEmailSpecification
{
    private static readonly Regex EmailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    private string _errorMessage;
    public string ErrorMessage => _errorMessage;
    
    public bool IsSatisfiedBy(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            _errorMessage = "이메일을 입력해주세요.";
            return false;
        }

        if (!EmailRegex.IsMatch(email))
        {
            _errorMessage= "올바르지 않은 이메일 형식입니다.";
            return false;
        }
        
        return true;
    }
}