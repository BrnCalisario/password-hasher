# Password Hash Service for C#
Really basic service for a safe way to store passwords in your favorite sequential storage database.


## Install 

> .NET CLI
> `dotnet add package password-hasher --version 1.0.0`

## How to use - WebAPI
Password Hasher is structured as a service that is used with dependency injection



 ### Program.cs
```
	//Imports
    using  Security.PasswordHasher;
	
	...
	//While setting your builder configuration
	
	//Define the salt provider that will be used by the Password Hasher
	builder.Services.AddTransient<ISaltProvider, BasicSaltProvider>();
	
	//Define the hash implementation that attends to your project 
	builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
	...
```
###  GetHashAndSalt()

> GetHashAndSalt asks for a string password and returns a tuple  with
> both hash and salt

```
//Imports 
...
using  Security.PasswordHasher;
...

// USE EXAMPLE
byte[] hashPassword;
string salt;
( hashPassword, salt)  = pshInstance.GetHashAndSalt(password);

/* PS: "pshInstance" is a password hasher instance and need's to be 
	asked as a service by dependency injection on the paramaters of your method
	
	Example:
	[...]
	public ActionResult Register(
		[FromServices] IPasswordHasher pshInstance
	)
	[...]
*/
```
