using System.Collections.Generic;
using System.Diagnostics;
using AppTeste.Controllers;
using AppTeste.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AppTeste.Tests
{
    public class HomeControllerTests
    {
        class FakeDataSource : IDataSource
        {
            public FakeDataSource(Product[] data) => Products = data;
            public IEnumerable<Product> Products { get; set; }
        }
        // [Fact]
        // public void IndexActionModelIsCompleteV1()
        // {
        //     //Given
        //     Product[] testData = new Product[]{
        //         new Product { Name = "P1", Price = 75.10M },
        //         new Product { Name = "P2", Price = 120M },
        //         new Product { Name = "P3", Price = 110M }
        //     };
        //     IDataSource data = new FakeDataSource(testData);
        //     var controller = new HomeController();
        //     controller.dataSource = data;

        //     //When
        //     //parece que simula uma chamada de controller
        //     //~cast de .index para view result, 
        //     //depois o model (conjunto de resposta) para enumerable. 
        //     var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
        //     //== ViewResult index = controller.Index();
        //     // var mod = (IEnumerable<Product>)index.ViewData.Model;

        //     //Then
        //     //ve se products e model são iguais
        //     Assert.Equal(data.Products, model,
        //         Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name &&
        //                                           p1.Price == p2.Price));
        // }
        [Fact]
        public void IndexActionModelIsComplete()
        {
            //Given
            Product[] testData = new Product[]{
                new Product { Name = "P1", Price = 75.10M },
                new Product { Name = "P2", Price = 120M },
                new Product { Name = "P3", Price = 110M }
            };
            var mock = new Mock<IDataSource>();
            mock.SetupGet(m => m.Products).Returns(testData);

            var controller = new HomeController();
            controller.dataSource = mock.Object;

            //When
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Then
            Assert.Equal(testData, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name &&
                                                  p1.Price == p2.Price));
            // mock.VerifyGet(m => m.Products, Times.Exactly(2));
        }

    }
}