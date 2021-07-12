using FluentValidation;
using Blog.Web.Models.Generals;
using Blog.Core.Domain.Generals;
using Blog.Data;
using Blog.Services.Localization;
using Blog.Web.Framework.Validators;

namespace Blog.Web.Validators.Generals
{
    public partial class StateProvinceValidator : BaseOsusValidator<StateProvinceModel>
    {
        public StateProvinceValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.Fields.Name.Required"));

            SetDatabaseValidationRules<StateProvince>(dbContext);
        }
    }
}