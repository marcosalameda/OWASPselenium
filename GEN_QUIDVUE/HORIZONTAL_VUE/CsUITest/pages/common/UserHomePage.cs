namespace quidgest.uitests.pages;

public class UserHomePage : PageObject
{
    IWebElement userAvatar => driver.FindElement(By.CssSelector("button.UserAvatar"));

    public UserHomePage(IWebDriver driver) : base(driver)
    {
        wait.Until(c => userAvatar != null);
    }

    public void ChangePassword()
    {
    }
    public void ChangePassword(string oldPassword, int newPassword)
    {
        // Implementación vacía: solo para que compile
    }
    public void ChangePassword(string oldPassword, string newPassword)
    {
        // Implementación vacía: solo para que compile
    }

}