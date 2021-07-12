using FluentValidation;
using Blog.Web.Models.Localization;
using Blog.Services.Localization;
using Blog.Web.Framework.Validators;

namespace Osus.Admin.Validators.Localization
{
    public partial class LanguageResourceValidator : BaseOsusValidator<LanguageResourceModel>
    {
        public LanguageResourceValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Name.Required"));
            RuleFor(x => x.Value).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Value.Required"));
        }
    }
}