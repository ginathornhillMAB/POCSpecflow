using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CalculatorSelenium.Specs.PageObjects
{
    /// <summary>
    /// Calculator Page Object
    /// </summary>
    public class CalculatorPageObject
    {
        //The URL of the page to be opened in the browser
        private const string DemoURL = " https://demo.1crmcloud.com ";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 15;

        public CalculatorPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        //Finding elements by ID
        private IWebElement UserNameInput => _webDriver.FindElement(By.XPath("//input[@id='login_user']"));
        private IWebElement PasswordInput => _webDriver.FindElement(By.Id("login_pass"));
        private IWebElement LoginButton => _webDriver.FindElement(By.Id("login_button"));
        private IWebElement SalesAndMarketingButton => _webDriver.FindElement(By.Id("grouptab-1"));
        private IWebElement CreateContactTabButton => _webDriver.FindElement(By.XPath("//a[contains(text(),'Contacts')]"));
        private IWebElement CreateContactButton => _webDriver.FindElement(By.XPath("//body/div[@id='outer-body']/div[@id='main-body']/div[@id='left-sidebar']/div[2]/a[1]"));
        private IWebElement FirstNameInput => _webDriver.FindElement(By.Id("DetailFormfirst_name-input")); 
        private IWebElement LastNameInput => _webDriver.FindElement(By.Id("DetailFormlast_name-input"));
        private IWebElement RoleInput => _webDriver.FindElement(By.Id("DetailFormbusiness_role-input"));
        private IWebElement Category => _webDriver.FindElement(By.Id("DetailFormcategories-input"));
        private IWebElement SaveButton => _webDriver.FindElement(By.Id("DetailForm_save2"));
        private IWebElement SearchBar => _webDriver.FindElement(By.Id("filter_text"));
        private IWebElement ReportAndSettings => _webDriver.FindElement(By.Id("grouptab-5")); 
        private IWebElement ProjectProfitabilityReport => _webDriver.FindElement(By.XPath("//a[contains(text(),'Project Profitability')]"));
        private IWebElement RunReport => _webDriver.FindElement(By.XPath("/html/body/div[7]/div/div[3]/div/div[1]/div[1]/form/div[3]/div/div[1]/div[2]/button"));
        private IWebElement ReturnToReport => _webDriver.FindElement(By.XPath("/html/body/div[7]/div/div[3]/div/div/div[1]/form/div[3]/div/div[1]/div/button"));
        private IWebElement LastRunReport => _webDriver.FindElement(By.XPath("/html/body/div[7]/div/div[3]/div/div[2]/div[1]/div/div[3]/table/tbody/tr[1]/td[2]/span/a"));
        private IWebElement ReportActions => _webDriver.FindElement(By.XPath("/html[1]/body[1]/div[7]/div[1]/div[3]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/button[1]/div[1]/span[1]"));
        private IWebElement ItemOne => _webDriver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/input[1]"));
        private IWebElement ItemTwo => _webDriver.FindElement(By.XPath("//tbody/tr[2]/td[1]/div[1]/input[1]"));
        private IWebElement ItemThree => _webDriver.FindElement(By.XPath("//tbody/tr[3]/td[1]/div[1]/input[1]"));
        private IWebElement Delete => _webDriver.FindElement(By.XPath("//div[contains(text(),'Delete')]"));
        public void EnterLoginPageAndLogin()
        {
            //Enter Username
            UserNameInput.SendKeys("admin");
            //Enter Password
            PasswordInput.SendKeys("admin");
            //Click Login button
            LoginButton.Click();
        }

        public void ClickSalesAndMarketing()
        {
            Thread.Sleep(2000);
            //Click the sales and marketing tab
            SalesAndMarketingButton.Click();
        }
        public void CreateContact()
        {
            Thread.Sleep(2000);
            //Click on create contact
            CreateContactTabButton.Click();
            Thread.Sleep(5000);
            //Click on create contact
            CreateContactButton.Click();
            Thread.Sleep(2000);
            FirstNameInput.SendKeys("Jimothy");
            LastNameInput.SendKeys("Jones");
            RoleInput.SendKeys("CEO");
            Category.Click();
            Category.SendKeys("Customer");
            Category.SendKeys("Supplier");
            SaveButton.Click();
        }

        public void ValidateClientCreation()
        {
            Thread.Sleep(2000);
            SalesAndMarketingButton.Click();
            Thread.Sleep(2000);
            CreateContactTabButton.Click();
            //Click on search bar
            Thread.Sleep(2000);
            SearchBar.Click();
            SearchBar.SendKeys("Jimothy Jones");
            SearchBar.SendKeys(Keys.Return);
            Thread.Sleep(1000);

        }

        public void ClickReportAndSettings()
        {
            Thread.Sleep(2000);
            ReportAndSettings.Click();


        }

        public void FindAndOpenProjectProfitabilityReport()
        {

            Thread.Sleep(2000);
            SearchBar.Click();
            Thread.Sleep(2000);
            SearchBar.SendKeys("Project Profitability");
            SearchBar.SendKeys(Keys.Return); Thread.Sleep(2000);
            ProjectProfitabilityReport.Click();
            Thread.Sleep(5000);
  
        }

        public void RunReportAndValidateRun()
        {
            RunReport.Click();
            Thread.Sleep(5000);
            ReturnToReport.Click();
            Thread.Sleep(5000);
            LastRunReport.Click();
        }

        public void FirstThreeItems()
        {
            Thread.Sleep(1000);
            ItemOne.Click();
            Thread.Sleep(1000);
            ItemTwo.Click();
            Thread.Sleep(1000);
            ItemThree.Click();
        }

        public void DeleteTheItemsFromReport()
        {
            ReportActions.Click();
            Thread.Sleep(5000);
            Delete.Click();
            this._webDriver.SwitchTo().Alert().Accept();
        }

        public void EnsureCalculatorIsOpenAndReset()
        {
            //Open the calculator page in the browser if not opened yet
            //Open the calculator page in the browser if not opened yet
            if (_webDriver.Url != DemoURL)
            {
                _webDriver.Url = DemoURL;
            }
            //Otherwise reset the calculator by clicking the reset button
            else
            {
                _webDriver.Quit();
               
            }
        }

        /// <summary>
        /// Helper method to wait until the expected result is available on the UI
        /// </summary>
        /// <typeparam name="T">The type of result to retrieve</typeparam>
        /// <param name="getResult">The function to poll the result from the UI</param>
        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>
        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });

        }
    }
}