using System;

public readonly struct AuthResult
{
    public readonly bool Success;
    public readonly string Message;
    public readonly Account Account;

    public AuthResult(bool success, string message, Account account = null)
    {
        Success = success;
        Message = message;
        Account = account;
    }
}