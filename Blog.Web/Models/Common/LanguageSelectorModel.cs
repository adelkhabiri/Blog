using System.Collections.Generic;
using Blog.Web.Models.Localization;
using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Common
{
    public partial class LanguageSelectorModel : BaseOsusModel
    {
        public LanguageSelectorModel()
        {
            AvailableLanguages = new List<LanguageModel>();
        }

        public IList<LanguageModel> AvailableLanguages { get; set; }

        public LanguageModel CurrentLanguage { get; set; }
    }
}