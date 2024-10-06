using Microsoft.OpenApi.Any;

namespace user_schema;

public class User_Schema
{
    public string Name { get; set; }

    public string Password { get; set; }

    public User_Schema(string name, string password)
    {
        Name = name;
        Password = password;
    }

 
}
