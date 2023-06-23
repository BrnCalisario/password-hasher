namespace Security.PasswordHasher;
public interface IPasswordHasher
{
    (byte[] hashPassword, string salt) GetHashAndSalt(string password);
    bool Validate(string password, string salt, byte[] realPassword);
}