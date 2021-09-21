using NUnit.Framework;
using QA_Framework.Pages.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Tests.Registration
{
    [Parallelizable(ParallelScope.All)]
    public class VerifyThatUserIsAbleToRegister : TestBase
    {
        UserModel user = new UserModel()
        {
            Address = "Adresa",
            Gender = "Mrs",
            FirstName = "First Name",
            LastName = "Last Name",
            AddressFirstName = "AFN",
            AddressLastName = "ALN",
            City = "City",
            State = "Arizona",
            Country = "United States",
            Password = "Password",
            PostCode = "00000",
            MobilePhone = "123123123",
            Alias = "nesto",
            Email = RandomString(6)+"@getnada.com"
        };

        [Test]
        public void VerifyThatUserIsAbleToRegisterTest() 
        {
            HomePage homePage = basePage.GoToHomePage();
            LoginPage loginPage = homePage.ClickOnSignIn();
            loginPage.PopulateRegistrationEmail(user.Email);
            RegistrationPage registrationPage = loginPage.ClickOnCreateAccount();
            registrationPage.PopulateAllMandatoryFieldsForRegistration(user);
            MyAccountPage myAccountPage = registrationPage.CreateAccount();
            myAccountPage.IsUserLoggedIn();            
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
