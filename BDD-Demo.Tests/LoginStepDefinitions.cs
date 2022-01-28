using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TechTalk.SpecFlow;

namespace BDD_Demo.Tests;

[Binding]
public class LoginStepDefinitions
{
    private readonly MyApp _app = new MyApp();
    private Exception? _exception;

    [Given(@"the user has opened the login page")]
    public void GivenTheUserHasOpenedTheLoginPage()
    {
        _app.NavigationService.GoToLoginPage();
    }

    [When(@"the user enters invalid login credentials")]
    public void WhenTheUserEntersInvalidLoginCredentials()
    {
        _app.LoginService.EnterCredentials("nope", "nope");
    }

    [When(@"the user clicks on the login button")]
    public void WhenTheUserClicksOnTheLoginButton()
    {
        try
        {
            _app.LoginService.Login();
            _app.NavigationService.GoToInternalPage();
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [Then(@"an error message is shown")]
    public void ThenAnErrorMessageIsShown()
    {
        Assert.IsNotNull(_exception);
    }

    [Then(@"the user stays on the login page")]
    public void ThenTheUserStaysOnTheLoginPage()
    {
        Assert.IsTrue(_app.NavigationService.IsOnLoginPage);
    }

    [When(@"the user enters valid login credentials")]
    public void WhenTheUserEntersValidLoginCredentials()
    {
        _app.LoginService.EnterCredentials("admin", "pass");
    }

    [Then(@"the user is redirected to an internal page")]
    public void ThenTheUserIsRedirectedToAnInternalPage()
    {
        Assert.IsTrue(_app.NavigationService.IsOnInternalPage);
    }
}
