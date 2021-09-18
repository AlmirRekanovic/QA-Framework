﻿using NUnit.Framework;
using QA_Framework.Pages;
using QA_Framework.Pages.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Tests.Home
{
    [Parallelizable(ParallelScope.All)]
    public class VerifyThatPopularCategoryHasSevenSections : TestBase
    {

        UserModel user = new UserModel()
        {            
            Email = "nesto@getnada.com",
            Password = "Password"

        };

        [Test]
        public void VerifyThatPopularCategoryHasSevenSectionsTest() 
        {
            HomePage homePage = basePage.GoToHomePage();
            LoginPage loginPage = homePage.ClickOnSignIn();
            MyAccountPage accountPage = loginPage.LogIn(user);
            accountPage.GoToHomePage();
            homePage.VerifyNumberOfSections("Popular");           
        }
        
    }
}
