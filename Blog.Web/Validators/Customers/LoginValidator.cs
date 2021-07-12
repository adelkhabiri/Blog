using FluentValidation;
using Blog.Core.Domain.Customers;
using Blog.Services.Localization;
using Blog.Web.Framework.Validators;
using Blog.Web.Models.Customer;

namespace Blog.Web.Validators.Customers
{
    public partial class LoginValidator : BaseOsusValidator<LoginModel>
    {
        public LoginValidator(ILocalizationService localizationService, CustomerSettings customerSettings)
        {
            if (!customerSettings.UsernamesEnabled)
            {
                //login by email
                RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.Login.Fields.Email.Required"));
                RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
            }
        }
    }
}