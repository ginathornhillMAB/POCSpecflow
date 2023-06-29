using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace CalculatorSelenium.Specs.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        //Page Object for Calculator
        private readonly CalculatorPageObject _calculatorPageObject;

        public CalculatorStepDefinitions(BrowserDriver browserDriver)
        {
            _calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
        }

        [Given("I login")]
        public void GivenILogin()
        {
            //open page and login
            _calculatorPageObject.EnterLoginPageAndLogin();
        }


        [When("I navigate to sales and marketing")]
        public void NavigateToSalesAndMarketing()
        {
            //delegate to Page Object
            _calculatorPageObject.ClickSalesAndMarketing();
        }

        [When("I create a contact")]
        public void CreateAContact()
        {
            //delegate to Page Object
            _calculatorPageObject.CreateContact();

        }

        [Then("Validate that the client is created")]
        public void ValidateClientCreation()
        {
            //delegate to Page Object
            _calculatorPageObject.ValidateClientCreation();

        }

        [When(@"I navigate to reports and settings")]
        public void NavigateToReportingandSettings()
        {
            //delegate to Page Object
            _calculatorPageObject.ClickReportAndSettings();
        }

        [When("I find the project profitability report")]
        public void ProjectProfitabilityReport()
        {
            //delegate to Page Object
            _calculatorPageObject.FindAndOpenProjectProfitabilityReport();

        }

        [Then("Run the report and verify some of the results were returned")]
        public void RunReportandValidate()
        {
            //delegate to Page Object
            _calculatorPageObject.RunReportAndValidateRun();

        }

        [When("I select the first three items in the table")]
        public void FindTheFirstThreeItems()
        {
            //delegate to Page Object
            _calculatorPageObject.FirstThreeItems();

        }

        [Then("I can delete these items")]
        public void DeleteTheItems()
        {
            //delegate to Page Object
            _calculatorPageObject.DeleteTheItemsFromReport();

        }
    }

}
