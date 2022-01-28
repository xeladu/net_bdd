namespace BDD_Demo;

public class MyApp
{
    public LoginService LoginService { get; }

    public NavigationService NavigationService { get; }

    public MyApp()
    {
        LoginService = new LoginService();
        NavigationService = new NavigationService();
    }
}
