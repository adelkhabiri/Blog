using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using Blog.Core;
using Blog.Core.Domain.Customers;
using Blog.Services.Generals;
using Blog.Services.Localization;
using Blog.Web.Framework.Validators;
using Blog.Web.Models.Customer;

namespace Blog.Web.Validators.Customers
{
    public partial class RegisterValidator : BaseOsusValidator<RegisterModel>
    {
        public RegisterValidator(ILocalizationService localizationService, 
            //IStateProvinceService stateProvinceService,
            CustomerSettings customerSettings)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
            
            if (customerSettings.EnteringEmailTwice)
            {
                RuleFor(x => x.ConfirmEmail).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.ConfirmEmail.Required"));
                RuleFor(x => x.ConfirmEmail).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
                RuleFor(x => x.ConfirmEmail).Equal(x => x.Email).WithMessage(localizationService.GetResource("Account.Fields.Email.EnteredEmailsDoNotMatch"));
            }
            
            if (customerSettings.UsernamesEnabled)
            {
                RuleFor(x => x.Username).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Username.Required"));
            }
            
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.FirstName.Required"));
            RuleFor(x => x.LastName).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.LastName.Required"));


            RuleFor(x => x.Password).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Password.Required"));
            RuleFor(x => x.Password).Length(customerSettings.PasswordMinLength, 999).WithMessage(string.Format(localizationService.GetResource("Account.Fields.Password.LengthValidation"), customerSettings.PasswordMinLength));
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.ConfirmPassword.Required"));
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage(localizationService.GetResource("Account.Fields.Password.EnteredPasswordsDoNotMatch"));

            //form fields
            if (customerSettings.CountryEnabled && customerSettings.CountryRequired)
            {
                RuleFor(x => x.CountryId)
                    .NotEqual(0)
                    .WithMessage(localizationService.GetResource("Account.Fields.Country.Required"));
            }

            if (customerSettings.DateOfBirthEnabled && customerSettings.DateOfBirthRequired)
            {
                Custom(x =>
                {
                    var dateOfBirth = x.ParseDateOfBirth();
                    //entered?
                    if (!dateOfBirth.HasValue)
                    {
                        return new ValidationFailure("DateOfBirthDay", localizationService.GetResource("Account.Fields.DateOfBirth.Required"));
                    }
                    //minimum age
                    if (customerSettings.DateOfBirthMinimumAge.HasValue &&
                        CommonHelper.GetDifferenceInYears(dateOfBirth.Value, DateTime.Today) < customerSettings.DateOfBirthMinimumAge.Value)
                    {
                        return new ValidationFailure("DateOfBirthDay", string.Format(localizationService.GetResource("Account.Fields.DateOfBirth.MinimumAge"), customerSettings.DateOfBirthMinimumAge.Value));
                    }
                    return null;
                });
            }
            if (customerSettings.CompanyRequired && customerSettings.CompanyEnabled)
            {
                RuleFor(x => x.Company).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Company.Required"));
            }
            if (customerSettings.StreetAddressRequired && customerSettings.StreetAddressEnabled)
            {
                RuleFor(x => x.StreetAddress).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.StreetAddress.Required"));
            }
            if (customerSettings.StreetAddress2Required && customerSettings.StreetAddress2Enabled)
            {
                RuleFor(x => x.StreetAddress2).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.StreetAddress2.Required"));
            }
            if (customerSettings.ZipPostalCodeRequired && customerSettings.ZipPostalCodeEnabled)
            {
                RuleFor(x => x.ZipPostalCode).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.ZipPostalCode.Required"));
            }
            if (customerSettings.CityRequired && customerSettings.CityEnabled)
            {
                RuleFor(x => x.City).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.City.Required"));
            }
            if (customerSettings.PhoneRequired && customerSettings.PhoneEnabled)
            {
                RuleFor(x => x.Phone).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Phone.Required"));
            }
            if (customerSettings.FaxRequired && customerSettings.FaxEnabled)
            {
                RuleFor(x => x.Fax).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Fax.Required"));
            }
        }
    }
}