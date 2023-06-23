using System;
using System.Text;
using System.Security.Cryptography;

namespace Security.PasswordHasher;

public class PasswordHasher : IPasswordHasher
{
    private ISaltProvider saltProvider;

    public PasswordHasher(ISaltProvider saltProvider)
    {
        this.saltProvider = saltProvider;
    }

    ///<summary>
    // Process the password into a hash that is the original password
    // concatenaned with an salt provided by 
    // the SaltProvider, the function returns a tuple both hash and the salt, that is used for validation
    ///</summary>
    public (byte[], string) GetHashAndSalt(string password)
    {
        string salt = saltProvider.ProvideSalt();
        
        byte[] finalHash = hash(password, salt);
    
        return (finalHash, salt);
    }

    private byte[] hash(string password, string salt)
    {
        using var sha = SHA256.Create();
        
        var salty = password + salt;

        var bytes = Encoding.UTF8.GetBytes(salty);
        
        var hashBytes = sha.ComputeHash(bytes);

        return hashBytes;
    }

    public bool Validate(string password, string salt, byte[] realPassword)
    {
        var hashed = this.hash(password, salt);
        return hashed == realPassword;    
    }
}