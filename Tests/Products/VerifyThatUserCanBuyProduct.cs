using NUnit.Framework;
using QA_Framework.Pages.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Tests.Products
{
    [Parallelizable(ParallelScope.All)]
    public class VerifyThatUserCanBuyProduct : TestBase
    {
        UserModel user = new UserModel()
        {

            Password = "Password",
            Email = "nesto@getnada.com",
            FirstName = "a"

        };

        [TestCase("Printed dresses", "Printed Summer Dress", "Blue", "3", "M","5")]
        public void VerifyThatUserCanBuyProductTest(string product, string productName, string color, string quantity,string size, string discount) 
        {
            HomePage homePage = basePage.GoToHomePage();
            LoginPage loginPage = homePage.ClickOnSignIn();
            MyAccountPage accountPage = loginPage.LogIn(user);
            accountPage.GoToHomePage();
            ProductPage productPage = homePage.SearchProduct(product);
            ProductDetailPage productDetailPage = productPage.ClickOnProduct(productName);
            productDetailPage.SelectColor();
            productDetailPage.SelectQuantity(quantity);
            productDetailPage.SelectSize(size);
            productDetailPage.VerifyDiscount(discount);
            productDetailPage.AddToCart();
            productDetailPage.VerifyProductDetails(size, color, quantity);
            productDetailPage.ClickOnProceedToCheckout();
            productDetailPage.VerifyProductNameOnSummary(productName);
            productDetailPage.VerifyAddressData(user.FirstName);
            productDetailPage.ClickOnProceedToCheckoutOnCart();
            productDetailPage.ClickOnProceedToCheckoutOnAddress();
            productDetailPage.AcceptTermsAndConditions();
            productDetailPage.ClickOnProceedToCheckoutOnShiping();
            productDetailPage.ClickOnBankWire();
            productDetailPage.ClickOnConfirmOrder();
            productDetailPage.VerifyConfirmationTitle("Your order on My Store is complete.");


        }
    }
}
