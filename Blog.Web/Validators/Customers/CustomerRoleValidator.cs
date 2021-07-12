using FluentValidation;
using Blog.Web.Models.Customers;
using Blog.Core.Domain.Customers;
using Blog.Data;
using Blog.Services.Localization;
using Blog.Web.Framework.Validators;

namespace Osus.Admin.Validators.Customers
{
    public partial class CustomerRoleValidator : BaseOsusValidator<CustomerRoleModel>
    {
        public CustomerRoleValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Customers.CustomerRoles.Fields.Name.Required"));

            SetDatabaseValidationRules<CustomerRole>(dbContext);
        }
    }
}