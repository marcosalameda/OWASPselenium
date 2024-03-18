using System;
using quidgest.uitests.core;
using OpenQA.Selenium;
using quidgest.uitests.controls;

namespace quidgest.uitests.pages;

public class AppPage: PageObject {
	public AppPage(IWebDriver driver) : base(driver) {
		string url = Configuration.Instance.BaseUrl;
		//string url = "http://localhost:59464/";
		driver.Navigate().GoToUrl(url);
	}

	public IMenuControl Menu => new HorizontalMenuControl(driver);

}
