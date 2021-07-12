using System.Web.Mvc;
using FluentValidation.Attributes;
using Osus.Admin.Validators.Localization;
using Blog.Web.Framework;
using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Localization
{
    [Validator(typeof(LanguageResourceValidator))]
    public partial class LanguageResourceModel : BaseOsusEntityModel
    {
        [OsusResourceDisplayName("Admin.Configuration.Languages.Resources.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [OsusResourceDisplayName("Admin.Configuration.Languages.Resources.Fields.Value")]
        [AllowHtml]
        public string Value { get; set; }

        public int LanguageId { get; set; }
    }
}