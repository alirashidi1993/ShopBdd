using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Controllers;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Shop.Test
{
    [Binding]
    public class ShoppingCartStepDefinitions
    {
        CartController controller=new CartController(new DataAccess.CartRepository());

        [Given(@"my shopping cart is empty")]
        public void GivenMyShoppingCartIsEmpty()
        {
            controller.Clear();
        }

        [When(@"I add a product with name '([^']*)' to cart")]
        public void WhenIAddAProductWithNameToCart(string productName)
        {
            controller.Add(productName, 1);
        }

        [Then(@"my cart should contain (.*) copy of '([^']*)'")]
        public void ThenMyCartShouldContainCopyOf(int expectedQuantity, string productName)
        {
            var result = ((OkObjectResult)controller.Index().Result).Value as IList<CartItem>;

            result = result.Where(i => i.SKU == productName).ToList();
            Console.WriteLine("Gala => "+productName);
            Assert.AreEqual(result.Count, expectedQuantity);
        }




        [Given(@"my shopping cart contains 1 copy of '([^']*)' with '(.*)' quantity")]
        public void GivenMyShoppingCartContainsCopyOfWithQuantity(string productName, int beforeQuantity)
        {
            controller.Add(productName, beforeQuantity);
        }

        [When(@"I add a '([^']*)' to my cart")]
        public void WhenIAddAToMyCart(string productName)
        {
            controller.Add(productName, 1);
        }

        [Then(@"the quantity of '([^']*)' should be '(.*)'")]
        public void ThenTheQuantityOfShouldBe(string productName, int afterQuantity)
        {
            var result = ((OkObjectResult)controller.Index().Result).Value as IList<CartItem>;

            result = result.Where(i => i.SKU == productName).ToList();
            Console.WriteLine("Ga jahannam ol => " + productName);
            Assert.AreEqual(result.Sum(i=>i.Quantity), afterQuantity);
        }

    }
}
