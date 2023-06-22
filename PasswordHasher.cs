using System;
using System.Text;
using System.Security.Cryptography;

namespace Security.PasswordHasher;

public class SaltyPasswordHasher : IPasswordHasher
{
    private ISaltProvider saltProvider;

    public SaltyPasswordHasher(ISaltProvider saltProvider)
    {
        this.saltProvider = saltProvider;
    }

    public byte[] Hash(string password)
    {
        using var sha = SHA256.Create();

        string salty = password + saltProvider.ProvideSalt();
        var bytes = Encoding.UTF8.GetBytes(salty);
        var hashBytes = sha.ComputeHash(bytes);

        return hashBytes;
    }

    public byte[] Hash(string password, string salt)
    {
        using var sha = SHA256.Create();
        var salty = password + salt;

        var bytes = Encoding.UTF8.GetBytes(salty);
        var hashBytes = sha.ComputeHash(bytes);

        return hashBytes;
    }

    public bool Validate(string password, string salt, byte[] realPassword)
    {
        var hashed = this.Hash(password, salt);
        return hashed == realPassword;    
    }
}