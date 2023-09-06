namespace CleanUserManagement.Domain;

public class User
{

    //What is a Domain in Clean Architecture design?
    //Things that could exist in any similar application
    //Does not depend on any other project
    public Guid id { get; } = new Guid();
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Notes { get; set; }

}

