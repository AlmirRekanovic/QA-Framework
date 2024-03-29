﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Framework.Pages;
using QA_Framework.Pages.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Tests
{
    public class TestBase
    {
        public IWebDriver driver;
        public HomePage basePage;

        [SetUp]
        public void Setup() 
        {
            driver = new DriverManager("chrome").CreateDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com");
            basePage = new HomePage(driver);

        }

        [TearDown]

        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
