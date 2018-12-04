using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Xunit;

namespace FunApp.Web.Tests
{
    public class SeleniumTests : IClassFixture<SeleniumServerFactory<Startup>>
    {
        private readonly SeleniumServerFactory<Startup> server;
        private readonly IWebDriver browser;

        public SeleniumTests(SeleniumServerFactory<Startup> server)
        {
            this.server = server;
            server.CreateClient();
            var opts = new ChromeOptions();
            opts.AddArgument("--headless"); //Optional, comment this out if you want to SEE the browser window
            opts.AddArgument("no-sandbox");
            this.browser = new RemoteWebDriver(opts);
        }

        [Fact]
        public void IndexPageShouldContains20Joke()
        {
            this.browser.Navigate().GoToUrl(this.server.RootUri);
            Assert.Equal(20, this.browser.FindElements(By.CssSelector("div.clearfix")).Count);
        }
    }
}
