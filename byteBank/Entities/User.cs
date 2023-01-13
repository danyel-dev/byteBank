
public class User
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string CPF { get; set; }
    public string BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; private set; }
    public string PasswordConfirm { get; private set; }

    public User(string name, string username, string cpf, string birthDate, string email, string password, string passwordConfirm)
    {
        Name = name;
        Username = username;
        CPF = cpf;
        BirthDate = birthDate;
        Email = email;
        Password = password;
        PasswordConfirm = passwordConfirm;
    }
}
