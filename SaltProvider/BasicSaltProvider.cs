namespace Security.PasswordHasher;

using System;
using System.Linq;
using System.Collections.Generic;

public class BasicSaltProvider : ISaltProvider
{
    public readonly byte[] lengthOptions = new byte[2] { 12, 18 };

    public string ProvideSalt()
    {
        Random rnd = new Random();
        
        int length = lengthOptions[rnd.Next(0, lengthOptions.Length)];

        byte[] saltBytes = new byte[length];
        rnd.NextBytes(saltBytes);
        
        var saltBase64 = Convert.ToBase64String(saltBytes);
        if(saltBase64.Contains("="))
        {
            System.Console.WriteLine("safado" + length + " " +  saltBase64 );
        }
        return saltBase64;
    }
}