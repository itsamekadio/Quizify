// Generated by Selenium IDE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Xunit;
public class SuiteTests : IDisposable {
  public IWebDriver driver {get; private set;}
  public IDictionary<String, Object> vars {get; private set;}
  public IJavaScriptExecutor js {get; private set;}
  public SuiteTests()
  {
    driver = new FirefoxDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<String, Object>();
  }
  public void Dispose()
  {
    driver.Quit();
  }
  [Fact]
  public void Successsignin() {
    driver.Navigate().GoToUrl("https://localhost:7272/");
    driver.Manage().Window.Size = new System.Drawing.Size(550, 692);
    driver.FindElement(By.CssSelector(".big-button")).Click();
    driver.FindElement(By.Id("email")).Click();
    driver.FindElement(By.Id("email")).Click();
    {
      var element = driver.FindElement(By.Id("email"));
      Actions builder = new Actions(driver);
      builder.DoubleClick(element).Perform();
    }
    driver.FindElement(By.Id("email")).SendKeys("elkad@vbnhjmk.com");
    driver.FindElement(By.Id("pass")).Click();
    driver.FindElement(By.Id("pass")).Click();
    {
      var element = driver.FindElement(By.Id("pass"));
      Actions builder = new Actions(driver);
      builder.DoubleClick(element).Perform();
    }
    driver.FindElement(By.Id("pass")).SendKeys("456123");
    driver.FindElement(By.CssSelector("button:nth-child(18)")).Click();
    driver.FindElement(By.CssSelector("form:nth-child(2) > button")).Click();
    driver.FindElement(By.CssSelector(".profile-info")).Click();
    driver.FindElement(By.CssSelector(".profile-header")).Click();
    driver.FindElement(By.CssSelector("tbody")).Click();
  }
}