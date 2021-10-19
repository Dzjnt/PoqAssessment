using FluentValidation;
using Poq.Application.Parameter;
using System.Collections.Generic;

namespace Poq.Application.Common.Validators
{
    public class GetProductsQueryValidator : AbstractValidator<ProductParams>
    {
        private readonly List<string> _sizes = new() { string.Empty, "small", "medium", "large" };
        public GetProductsQueryValidator()
        {
            RuleFor(x => x.Size)
                .Must(x => _sizes.Contains(x));

            RuleFor(x => x.MaxPrice).GreaterThan(0);

        }
    }
}
