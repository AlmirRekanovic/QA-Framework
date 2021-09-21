using NUnit.Framework;
using QA_Framework.Helpers;
using QA_Framework.Pages.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Tests.Products
{
    [Parallelizable(ParallelScope.All)]
    public class VerifyProductSearchReults : TestBase
    {

        List<string> productNames = new List<string>()
        {
        "Printed Summer Dress",
        "Printed Dress",
        "Printed Chiffon Dress",
        "Printed Summer Dress",
        "Printed Dress"
        };
        UserModel user = new UserModel()
        {
            
            Password = "Password",           
            Email = "nesto@getnada.com"

        };

        [TestCase("Printed dresses")]
        public void VerifyProductSearchReultsTest(string product) 
        {
            HomePage homePage = basePage.GoToHomePage();
            LoginPage loginPage = homePage.ClickOnSignIn();
            MyAccountPage accountPage = loginPage.LogIn(user);
            accountPage.GoToHomePage();
            ProductPage productPage = homePage.SearchProduct(product);
            List<String> namesOfProdcut = productPage.GetProductNames();
            FileHandler fileHandler = new FileHandler("Products.txt");
            fileHandler.CreateFile(namesOfProdcut);
            Assert.IsTrue(fileHandler.VerifyFileData(productNames));
        }
    }
}
