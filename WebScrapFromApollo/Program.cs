using HtmlAgilityPack;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using PuppeteerSharp;

using System.Xml.Linq;

namespace WebScrapFromApollo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //ApolloScrappingHelper apolloScrappingHelper = new ApolloScrappingHelper();
            //apolloScrappingHelper.StartScrapping();


            #region PuppeteerSharp

            var baseUrl = "https://app.apollo.io/#";

            string loginUrl = $"{baseUrl}/login";
            string peopleUrl = $"{baseUrl}/people";

            // download the browser executable
            await new BrowserFetcher().DownloadAsync();

            // browser execution configs
            var launchOptions = new LaunchOptions
            {
                Headless = false, // = false for testing
                Args = new[] { "--start-maximized" },
                DefaultViewport = null,
            };

            // open a new page in the controlled browser
            using (var browser = await Puppeteer.LaunchAsync(launchOptions))
            using (var page = await browser.NewPageAsync())
            {

                // visit the target page
                await page.GoToAsync(loginUrl, WaitUntilNavigation.Networkidle2);

                //Thread.Sleep(5000);

                var emailField = await page.XPathAsync("/html/body/div[2]/div/div[2]/div[1]/div/div[2]/div/div[2]/div/form/div[5]/div/div/input");
                await emailField.FirstOrDefault().TypeAsync("summa@b2bleadshouse.com");

                var passwordField = await page.XPathAsync("//*[@id=\"current-password\"]");
                await passwordField.FirstOrDefault().TypeAsync("Carel56/*a5f8ef");

                var keepLoggedinField = await page.XPathAsync("//*[@id=\"provider-mounter\"]/div/div[2]/div[1]/div/div[2]/div/div[2]/div/form/div[8]/div/div/div/label/div/i");
                var loginButton = await page.XPathAsync("//*[@id=\"provider-mounter\"]/div/div[2]/div[1]/div/div[2]/div/div[2]/div/form/div[7]/button");

                //await loginButton.FirstOrDefault().ClickAsync();


                await page.GoToAsync(peopleUrl, WaitUntilNavigation.Networkidle2);


                Thread.Sleep(10000);


                // retrieve the HTML source code and log it
                var html = await page.GetContentAsync();
                Console.WriteLine(html);

                await browser.CloseAsync();
            }


            #endregion


        }
    }
}
