using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using OsfPay.Controllers;
using OsfPay.Data;
using OsfPay.Data.Entities;
using OsfPay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OsfPayTest
{
    public class SampleTest
    {
        [Fact]
        public void Home_Index_Returns_CorrectNumberOf_Products()
        {
            //arrange
            var dataStore = A.Fake<IProductRepository>();
            var fakeProducts = A.CollectionOfDummy<Product>(5);
            A.CallTo(() => dataStore.AllProducts).Returns(fakeProducts);
            var controller = new HomeController(dataStore);


            //act
            var result = controller.Index() as ViewResult;


            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var products = Assert.IsAssignableFrom<ProductViewModel>(viewResult.ViewData.Model);
            Assert.Equal(5, products.Products.Count());
        }

       [Fact]
        public void CanUpdateProductPrice()
        {
            // Arrange
            var product = new Product { Name = "Sample product", Price = 12.95M };
            // Act
            product.Price = 20M;
            //Assert
            Assert.Equal(20M, product.Price);
        }

        [Fact]
        public void CanUpdateProductName()
        {
            // Arrange
            var product = new Product { Name = "Sample product", Price = 12.95M };
            // Act
            product.Name = "Another product";
            //Assert
            Assert.Equal("Another product", product.Name);
        }
       
      

    }
}
