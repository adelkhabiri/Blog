using FluentValidation;
using Blog.Web.Models.Customers;
using Blog.Core.Domain.Customers;
using Blog.Data;
using Blog.Services.Localization;
using Blog.Web.Framework.Validators;

namespace Blog.Web.Validators.Customers
{
    public partial class CustomerAttributeValueValidator : BaseOsusValidator<CustomerAttributeValueModel>
    {
        public CustomerAttributeValueValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Customers.CustomerAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<CustomerAttributeValue>(dbContext);
        }
    }
}