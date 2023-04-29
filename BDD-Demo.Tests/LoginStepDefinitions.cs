using System;
using System.Linq;

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

    [When(@"the users enters the following credentials")]
    public void WhenTheUsersEntersTheFollowingCredentials(Table table)
    {
        table.Rows.First().TryGetValue("User", out var firstUser);      // contains abc
        table.Rows.First().TryGetValue("Password", out var firstPwd);   // contains 123
        table.Rows.Last().TryGetValue("User", out var lastUser);        // contains admin
        table.Rows.Last().TryGetValue("Password", out var lastPwd);     // contains testtest
    }

    [When(@"the user enters the password (.*)")]
    public void WhenTheUserEntersThePassword(string pass)
    {
    }

    [When(@"the user enters the user (.*)")]
    public void WhenTheUserEntersTheUser(string user)
    {
    }
}
