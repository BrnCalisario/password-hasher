namespace Security.PasswordHasher;
public interface ISaltProvider
{
    string ProvideSalt();
}