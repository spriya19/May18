using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Collections.Specialized.BitVector32;

public class Program
{
    public static IWebElement? Checkbox { get; private set; }

    private static void Main(string[] args)
    {
        // open chrome browser
        IWebDriver driver = new ChromeDriver();
        // lanuch trunup portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
        driver.Manage().Window.Maximize();
        // identify username textbox enter valid username
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");
        // Identify password textbox enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");
        // click longin button
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        // check user has logged in successfully
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if(helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("user has logged in succesfully");
        }
        else
        {
            Console.WriteLine("user has not logged");       
        }
    }
}