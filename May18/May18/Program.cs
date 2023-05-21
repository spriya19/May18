using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data;

public class Program 
{
    private static void Main(string[] args)
    {
        // open chrome browser
        IWebDriver driver = new ChromeDriver();

    // lanuch trunup portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
        driver.Manage().Window.Maximize();
        Thread.Sleep(1000);

        // identify username textbox enter valid username
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");

        // Identify password textbox enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");
        Thread.Sleep(1000);
        // check user has checked successfully
        IWebElement remembermeLable = driver.FindElement(By.Id("RememberMe"));
        remembermeLable.Click();
        // click longin button
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        // check user has logged in successfully
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("user has logged in succesfully");
        }
        else
        {
            Console.WriteLine("user has not logged");
        }
        // navigate to time and mateial page
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationTab.Click();
        IWebElement tmoptionTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        tmoptionTab.Click();
        // click create new button
        IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createnewButton.Click();
        // select Time from dropdown List
        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodeDropdown.Click();
        Thread.Sleep(1000);
        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();

        // input code
        IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
        codeTextbox.SendKeys("3ESP");
        // input description
        IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
        descriptionTextbox.SendKeys("3ES");
        // input price per unit
        IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTextbox.SendKeys("666");

        Thread.Sleep(2000);
        // click on save button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Console.WriteLine("Record saved successfully...");

        // check latest Record created successfully
        // navige to last page
        Thread.Sleep(3000);
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButton.Click();
        Thread.Sleep(4000);

        //check if the record is present in the table
        IWebElement newcode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (newcode.Text == "3ESP")
        {
            Console.WriteLine("Time record has created succesfully");
        }
        else
        {
            Console.WriteLine("Time record has not been created successfully");
        }

        // click Edit the last Record
        IWebElement lastRecordButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        lastRecordButton.Click();

        IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
        editCodeTextbox.Clear();
        editCodeTextbox.SendKeys("3ESPEDIT");
        Thread.Sleep(2000);

        // click on save button
        IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
        editSaveButton.Click();
        Console.WriteLine("Editing a record is done");


        // Click last Page Button (after editing)
        Thread.Sleep(3000);

        IWebElement afterEditGoToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        afterEditGoToLastPageButton.Click();

        //check if the  edit record is present in the table
        IWebElement editCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (editCode.Text == "3ESPEDIT")
        {
            Console.WriteLine("Time edit record has created and verified succesfully");
        }
        else
        {
            Console.WriteLine("Time edit record has not been created successfully");

        }

        // ======================= Create Material Record ======================= 

        IWebElement createnewButton4Material = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createnewButton4Material.Click();

        // select dropdown List
        IWebElement typeCodeDropdown4Material = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodeDropdown4Material.Click();

        // select Material from dropdown List
        Thread.Sleep(1000);
        IWebElement materialOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
        materialOption.Click();
        
        // input code
        IWebElement mcodeTextbox = driver.FindElement(By.Id("Code"));
        mcodeTextbox.SendKeys("ESPE");
        // input description
        IWebElement mdescriptionTextbox = driver.FindElement(By.Id("Description"));
        mdescriptionTextbox.SendKeys("ESPE");
        // input price per unit
        IWebElement mpriceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        mpriceTextbox.SendKeys("2479");
        Thread.Sleep(2000);
        // click on save button
        IWebElement msaveButton = driver.FindElement(By.Id("SaveButton"));
        msaveButton.Click();
        // check material record saved
        Console.WriteLine("Material record saved...");

        Thread.Sleep(3000);
        IWebElement GoToLastPageButtonAfterAddMaterial = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        GoToLastPageButtonAfterAddMaterial.Click();

        //check if the Material record is present in the table
        IWebElement newMaterialcode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (newMaterialcode.Text == "ESPE")
        {
            Console.WriteLine("Material record has created and verified succesfully");
        }
        else
        {
            Console.WriteLine("Material record has not been created successfully");
        }
        
        // click Edit the last material Record
        IWebElement lastmaterialRecordButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        lastmaterialRecordButton.Click();

        IWebElement editmCodeTextbox = driver.FindElement(By.Id("Code"));
        editmCodeTextbox.Clear();
        editmCodeTextbox.SendKeys("ESPEEDIT");
        Thread.Sleep(2000);

        // click on save button
        IWebElement editmSaveButton = driver.FindElement(By.Id("SaveButton"));
        editmSaveButton.Click();
        Console.WriteLine("Editing a record is done");


        // Click last Page Button (after editing)
        Thread.Sleep(3000);

        IWebElement afterEditmaterialGoToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        afterEditmaterialGoToLastPageButton.Click();

        //check if the  edit record is present in the table
        IWebElement editmCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (editmCode.Text == "ESPEEDIT")
        {
            Console.WriteLine("Material edit record has created and verified succesfully");
        }
        else
        {
            Console.WriteLine("Material edit record has not been created successfully");

        }
        // click delete last record
        Thread.Sleep(3000);
        IWebElement deleteRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        deleteRecord.Click();

        Thread.Sleep(3000);
        // To Click OK in altert window
        driver.SwitchTo().Alert().Accept();
        // To Click Cancel in alert window, if you dont want to delete
        //driver.SwitchTo().Alert().Dismiss();
        Console.WriteLine("Last record from the table has been deleted successfully.");
    }
}