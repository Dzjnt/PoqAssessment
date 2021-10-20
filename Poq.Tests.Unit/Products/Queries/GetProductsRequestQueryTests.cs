using AutoMapper;
using Poq.Application.Common.Exceptions;
using Poq.Application.Common.Mappings;
using Poq.Application.Handlers;
using Poq.Application.Parameter;
using Poq.Application.Queries.GetProducts;
using Poq.Tests.Unit.Mocks;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Poq.Tests.Unit.Products.Queries
{
    [Collection("QueryTests")]
    public class GetProductsRequestQueryTests
    {
        private readonly GetProductsQueryHandler _handler;
        public GetProductsRequestQueryTests()
        {
            var _mockRepo = new MockProductApi().GetProductApi();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });

            var _mapper = mapperConfig.CreateMapper();
            _handler = new GetProductsQueryHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ReturnsAllProductsForDefaultParams()
        {
            var parameters = new ProductParams();

            var result = await _handler.Handle(new GetProductsQuery(parameters), CancellationToken.None);

            result.Value.Products.Count.ShouldBe(12);
        }


        [Theory]
        [InlineData("")]
        [InlineData("medium")]
        [InlineData("large")]
        [InlineData("small")]

        public async Task Handle_ReturnsFilteredProductBySize(string size)
        {
            var parameters = new ProductParams() { Size = size };

            var result = await _handler.Handle(new GetProductsQuery(parameters), CancellationToken.None);

            result.Value.Products.TrueForAll(x => x.Sizes.All(e => e == size));

        }

        [Theory]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(5)]

        public async Task Handle_ReturnsFilteredProductByMaxPrice(double maxPrice)
        {
            var parameters = new ProductParams() { MaxPrice = maxPrice };

            var result = await _handler.Handle(new GetProductsQuery(parameters), CancellationToken.None);

            result.Value.Products.TrueForAll(x => x.Price <= maxPrice);

        }

        [Theory]
        [InlineData("blue")]
        [InlineData("red,blue")]
        [InlineData("green,blue,red")]

        public async Task Handle_ReturnsHighlightedProductsDescriptionByKeyword(string keyword)
        {
            var parameters = new ProductParams() { Highlights = keyword };

            var result = await _handler.Handle(new GetProductsQuery(parameters), CancellationToken.None);

            result.Value.Products.ShouldSatisfyAllConditions(
                p => p.Where(x => x.Description.Contains(keyword)),
                p => p.ShouldContain(x => Regex.IsMatch(x.Description, @"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>")));

        }

        [Fact]
        public async Task Handle_ReturnsNotHighlightedProductsDescription_EmptyInput()
        {
            var parameters = new ProductParams();

            var result = await _handler.Handle(new GetProductsQuery(parameters), CancellationToken.None);

            result.Value.Products.ShouldNotContain(p => Regex.IsMatch(p.Description, @"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>"));

        }

        [Fact]
        public async Task Handle_ReturnsNotHighlightedProductsDescription_InvalidInput()
        {
            var parameters = new ProductParams() { Highlights = "Not existing word" };

            var result = await _handler.Handle(new GetProductsQuery(parameters), CancellationToken.None);

            result.Value.Products.ShouldNotContain(p => Regex.IsMatch(p.Description, @"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>"));

        }
        [Fact]
        public async Task Handle_ReturnsMostCommonKeywords()
        {

            var mostCommonWords = new List<string> { "a", "shirt.", "red", "green", "blue", "belt." };
            var parameters = new ProductParams();

            var result = await _handler.Handle(new GetProductsQuery(parameters), CancellationToken.None);

            result.Value.MostCommonWords.ShouldBe(mostCommonWords);

        }

        [Theory]
        [InlineData("sadsa")]
        public async Task Handle_ShouldThrowExceptionWhenInvalidSize(string size)
        {
            var parameters = new ProductParams() { Size = size };


            await Should.ThrowAsync<RestApiException>(() => _handler.Handle(new GetProductsQuery(parameters), CancellationToken.None));

        }

        [Theory]
        [InlineData(-6.0)]
        public async Task Handle_ShouldThrowExceptionWhenNegativeMaxPrice(double maxPrice)
        {
            var parameters = new ProductParams() { MaxPrice = maxPrice };


            await Should.ThrowAsync<RestApiException>(() => _handler.Handle(new GetProductsQuery(parameters), CancellationToken.None));

        }
    }
}
