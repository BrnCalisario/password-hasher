namespace Security.PasswordHasher;
public interface IPasswordHasher
{
    byte[] Hash(string password);
    byte[] Hash(string password, string salt);
    bool Validate(string password, string salt, byte[] realPassword);
}