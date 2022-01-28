namespace BDD_Demo;

public class LoginService
{
    private string? _user;
    private string? _pwd;

    public bool IsLoggedIn { get; private set; }

    public void EnterCredentials(string? user, string? pwd)
    {
        _user = user;
        _pwd = pwd;
    }

    public void Login()
    {
        if (_user != "admin" || _pwd != "pass")
            throw new InvalidOperationException("Invalid credentials");

        IsLoggedIn = true;
    }
}
