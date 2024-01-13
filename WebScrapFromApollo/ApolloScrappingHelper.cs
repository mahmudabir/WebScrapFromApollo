using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapFromApollo
{
    public class ApolloScrappingHelper : IScrappingHelper
    {

        public void StartScrapping()
        {
            var baseUrl = "https://app.apollo.io/#";

            string loginUrl = $"{baseUrl}/login";
            string peopleUrl = $"{baseUrl}/people";

            using IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(loginUrl);

            Thread.Sleep(5000);

            IWebElement emailField = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div/div[2]/div/div[2]/div/form/div[5]/div/div/input"));
            IWebElement passwordField = driver.FindElement(By.XPath("//*[@id=\"current-password\"]"));
            IWebElement keepLoggedinField = driver.FindElement(By.XPath("//*[@id=\"provider-mounter\"]/div/div[2]/div[1]/div/div[2]/div/div[2]/div/form/div[8]/div/div/div/label/div/i"));
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"provider-mounter\"]/div/div[2]/div[1]/div/div[2]/div/div[2]/div/form/div[7]/button"));

            emailField.SendKeys("summa@b2bleadshouse.com");
            passwordField.SendKeys("Carel56/*a5f8ef");
            //keepLoggedinField.Click();
            loginButton.Click();

            Thread.Sleep(5000);


            driver.Navigate().GoToUrl(peopleUrl);


            //driver.Quit();
        }
    }
}
