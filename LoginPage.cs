using System;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Class1
{
	IWebDriver driver;

	public LoginPage(IWebDriver browser)
	{
		driver = browser;
	}
	public IWebElement txtEmail => driver.FindElement(by.Id("email"));
	public IWebElement txtPassword => driver.FindElement(B)

}

