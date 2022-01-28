namespace BDD_Demo;

public class NavigationService
{
    public bool IsOnLoginPage { get; private set; } = true;

    public bool IsOnInternalPage { get; private set; }

    public void GoToInternalPage()
    {
        IsOnLoginPage = false;
        IsOnInternalPage = true;
    }

    public void GoToLoginPage()
    {
        IsOnLoginPage = true;
        IsOnInternalPage = false;
    }
}
