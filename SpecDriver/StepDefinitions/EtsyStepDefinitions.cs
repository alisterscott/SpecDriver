namespace Project1.StepDefinitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TechTalk.SpecFlow;
    using NUnit.Framework;
    using Project1.Pages;

    [Binding]
    public class EtsyStepDefinitions : BaseStepDefinitions
    {
        [Given(@"I am searching on Etsy\.com")]
        public void GivenIAmSearchingOnEtsyDotCom()
        {
            EtsySearchPage = new EtsySearchPageModel(Driver);
            Assert.AreEqual("Etsy :: Advanced Search", EtsySearchPage.Title);
        }

        [Given(@"I am on Etsy\.com")]
        public void GivenIAmOnEtsy_Com()
        {
            EtsyHomePage = new EtsyHomePageModel(Driver);
            Assert.AreEqual("Etsy - Your place to buy and sell all things handmade, vintage, and supplies", EtsyHomePage.Title);
        }

        [Given(@"I am on the Etsy cart page")]
        public void GivenIAmOnTheEtsyCartPage()
        {
            EtsyCartPage = new EtsyCartPageModel(Driver);
            Assert.AreEqual("Etsy - Shopping Cart", EtsyCartPage.Title);
        }

        [Given(@"that the cart is empty")]
        public void GivenThatTheCartIsEmpty()
        {
            EtsyCartPage.EnsureCartEmpty();
            Assert.AreEqual("0 items in your cart", EtsyCartPage.ItemsInCart());
        }

        [When(@"I specify the (.+) sub category")]
        public void WhenISpecifyASubCategory(string subCategory)
        {
            EtsySearchPage.SpecifySubCategory(subCategory);
        }

        [When(@"I search for '(.+)'")]
        public void WhenISearchForSomething(string term)
        {
            EtsySearchResultsPage = EtsySearchPage.SearchForSomething(term);
        }

        [When(@"I want to browse through a treasury gallery")]
        public void WhenIWantToBrowseThroughATreasuryGallery()
        {
            EtsyBuyPage = EtsyHomePage.clickBuy();
            Assert.AreEqual("Etsy - Buy", EtsyBuyPage.Title);
            EtsyTreasuryPage = EtsyBuyPage.ClickTreasuryButton();
            Assert.AreEqual("Etsy - Treasury", EtsyTreasuryPage.Title);
        }

        [When(@"an item is added to the cart")]
        public void WhenAnItemIsAddedToTheCart()
        {
            EtsySearchPage = new EtsySearchPageModel(Driver);
            EtsySearchResultsPage = EtsySearchPage.SearchForSomething("Hat");
            EtsyItemPage = EtsySearchResultsPage.ClickFirstResult();
            ScenarioContext.Current["Item Title"] = EtsyItemPage.ItemTitle();
            EtsyCartPage = EtsyItemPage.ClickAddToCart();
        }

        [When(@"I remove the item from the cart")]
        public void WhenIRemoveTheItemFromTheCart()
        {
            EtsyCartPage.RemoveOneItem();
        }

        [Then(@"the cart contains that item")]
        public void ThenTheCartContainsThatItem()
        {
            Assert.AreEqual("1 item in your cart", EtsyCartPage.ItemsInCart());
            Assert.AreEqual(ScenarioContext.Current["Item Title"], EtsyCartPage.FirstItemTitle());
        }

        [Then(@"the cart is empty")]
        public void ThenTheCartIsEmpty()
        {
            Assert.IsTrue(EtsyCartPage.IsCartEmpty());
        }

        [Then(@"I should see some search results for '(.+)'")]
        public void ThenIShouldSeeSomeSearchResults(string term)
        {
            StringAssert.IsMatch(@".+ "+term+@"\d+,?\d* items", EtsySearchResultsPage.SearchResultsText());
            StringAssert.DoesNotMatch(@"^We didn't find anything for " + term + @"\.$", EtsySearchResultsPage.SearchResultsText());
        }

        [Then(@"I should see no search results for '(.+)'")]
        public void ThenIShouldSeeNoSearchResults(string term)
        {
            StringAssert.DoesNotMatch(@"\d+,?\d* items for " + term, EtsySearchResultsPage.SearchResultsText());
            StringAssert.IsMatch(@"^We didn't find anything for " + term + @"\.$", EtsySearchResultsPage.SearchResultsText());
        }

        [Then(@"I should see that the search was for '(.+)' instead of '(.+)'")]
        public void ThenIShouldSeeTheSearchWasFor(string newTerm, string oldTerm)
        {
            StringAssert.IsMatch("No results found for " + oldTerm + ", searching instead for " + newTerm + ".", EtsySearchResultsPage.SpellingText());
        }

        [Then(@"results will be displayed in the gallery")]
        public void ThenResultsWillBeDisplayedInTheGallery()
        {
            EtsyTreasuryPage.AssertGalleryPresent();
        }

    }
}
