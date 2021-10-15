using Moq;
using Poq.Application.Common.Interfaces;
using Poq.Application.Products;
using System.Collections.Generic;

namespace Poq.Tests.Unit.Mocks
{
    public class MockProductApi
    {
        public Mock<IProductsService> GetProductApi()
        {
            var productTypes =
                new GetProductsResponse
                {
                    Products = new List<Product>
                    {

                        new Product {
                                  Title = "A Red Trouser",
                                  Price= 10,
                                  Sizes = new List<string> { "small", "medium", "large" },
                                  Description = "This trouser perfectly pairs with a green shirt." },

                          new Product {
                                  Title = "A Green Trouser",
                                  Price= 11,
                                  Sizes = new List<string> { "small" },
                                  Description = "This trouser perfectly pairs with a blue shirt."
                          },

                          new Product {
                                  Title = "A Blue Trouser",
                                  Price= 12,
                                  Sizes = new List<string> {  "medium" },
                                  Description = "This trouser perfectly pairs with a red shirt."},


                          new Product{
                                  Title = "A Red Trouser",
                                  Price= 13,
                                  Sizes = new List<string> { "large" },
                                  Description = "This trouser perfectly pairs with a green shirt."
                          },
                          new Product
                          {
                                  Title = "A Green Trouser",
                                  Price= 14,
                                  Sizes = new List<string> { "small", "medium",},
                                  Description = "This trouser perfectly pairs with a blue shirt."
                          },


                          new Product {
                                  Title = "A Blue Trouser",
                                  Price= 15,
                                  Sizes = new List<string> { "small", "large" },
                                  Description = "This trouser perfectly pairs with a red shirt."

                          },
                          new Product {
                                  Title = "A Blue Trouser",
                                  Price= 16,
                                  Sizes = new List<string>() { "small", "large" },
                                  Description = "This trouser perfectly pairs with a red shirt."

                          },
                          new Product {
                                  Title = "A Blue Trouser",
                                  Price= 17,
                                  Sizes = new List<string> { "small", "large" },
                                  Description = "This trouser perfectly pairs with a red shirt."

                          },
                          new Product {
                                  Title = "A Blue Trouser",
                                  Price= 18,
                                  Sizes = new List<string> { "small","medium" ,"large" },
                                  Description = "This trouser perfectly pairs with a red shirt."

                          },
                          new Product {
                                  Title = "A Red Trouser",
                                  Price= 19,
                                  Sizes = new List<string> { "small" },
                                  Description = "This trouser perfectly pairs with a green belt."

                          },
                          new Product {
                                  Title = "A Green Trouser",
                                  Price= 20,
                                  Sizes = new List<string> { "medium" },
                                  Description = "This trouser perfectly pairs with a blue belt."

                          },
                          new Product {
                                  Title = "A Blue Trouser",
                                  Price= 21,
                                  Sizes = new List<string> { "large" },
                                  Description = "This trouser perfectly pairs with a red belt."

                          },

                    }
                };

            var mockRepo = new Mock<IProductsService>();
            mockRepo.Setup(r => r.GetProducts()).ReturnsAsync(productTypes);

            return mockRepo;

        }
    }
}
