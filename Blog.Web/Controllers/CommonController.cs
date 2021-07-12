using System;
using System.Web.Mvc;
using Blog.Core;
using Blog.Core.Domain;
using Blog.Core.Domain.Common;
using Blog.Core.Domain.Customers;
using Blog.Core.Domain.Localization;
using Blog.Core.Domain.Messages;
using Blog.Services.Common;
using Blog.Services.Generals;
using Blog.Services.Localization;
using Blog.Services.Logging;
using Blog.Web.Factories;
using Blog.Web.Framework;
using Blog.Web.Framework.Localization;
using Blog.Web.Framework.Security;
using Blog.Web.Models.Common;

namespace Blog.Web.Controllers
{
    public partial class CommonController : BasePublicController
    {
        #region Fields

        private readonly ICommonModelFactory _commonModelFactory;
        private readonly ILanguageService _languageService;
        private readonly ICurrencyService _currencyService;
        private readonly ILocalizationService _localizationService;
        private readonly IWorkContext _workContext;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly CommonSettings _commonSettings;
        private readonly LocalizationSettings _localizationSettings;

        #endregion

        #region Constructors

        public CommonController(ICommonModelFactory commonModelFactory,
            ILanguageService languageService,
            ICurrencyService currencyService,
            ILocalizationService localizationService,
            IWorkContext workContext,
            IGenericAttributeService genericAttributeService,
            ICustomerActivityService customerActivityService,
            CommonSettings commonSettings,
            LocalizationSettings localizationSettings)
        {
            this._commonModelFactory = commonModelFactory;
            this._languageService = languageService;
            this._currencyService = currencyService;
            this._localizationService = localizationService;
            this._workContext = workContext;
            this._genericAttributeService = genericAttributeService;
            this._customerActivityService = customerActivityService;
            this._commonSettings = commonSettings;
            this._localizationSettings = localizationSettings;
        }

        #endregion

        #region Methods

        //page not found
        public virtual ActionResult PageNotFound()
        {
            this.Response.StatusCode = 404;
            this.Response.TrySkipIisCustomErrors = true;
            this.Response.ContentType = "text/html";

            return View();
        }

        //language
        [ChildActionOnly]
        public virtual ActionResult LanguageSelector()
        {
            var model = _commonModelFactory.PrepareLanguageSelectorModel();

            if (model.AvailableLanguages.Count == 1)
                Content("");

            return PartialView(model);
        }
        public virtual ActionResult SetLanguage(int langid, string returnUrl = "")
        {
            var language = _languageService.GetLanguageById(langid);
            if (language != null && language.Published)
            {
                _workContext.WorkingLanguage = language;
            }

            //home page
            if (String.IsNullOrEmpty(returnUrl))
                returnUrl = Url.RouteUrl("HomePage");

            //prevent open redirection attack
            if (!Url.IsLocalUrl(returnUrl))
                returnUrl = Url.RouteUrl("HomePage");

            //language part in URL
            if (_localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
            {
                string applicationPath = HttpContext.Request.ApplicationPath;
                if (returnUrl.IsLocalizedUrl(applicationPath, true))
                {
                    //already localized URL
                    returnUrl = returnUrl.RemoveLanguageSeoCodeFromRawUrl(applicationPath);
                }
                returnUrl = returnUrl.AddLanguageSeoCodeToRawUrl(applicationPath, _workContext.WorkingLanguage);
            }
            return Redirect(returnUrl);
        }

        public virtual ActionResult SetCurrency(int customerCurrency, string returnUrl = "")
        {
            var currency = _currencyService.GetCurrencyById(customerCurrency);
            if (currency != null)
                _workContext.WorkingCurrency = currency;

            //home page
            if (String.IsNullOrEmpty(returnUrl))
                returnUrl = Url.RouteUrl("HomePage");

            //prevent open redirection attack
            if (!Url.IsLocalUrl(returnUrl))
                returnUrl = Url.RouteUrl("HomePage");

            return Redirect(returnUrl);
        }

        //footer
        [ChildActionOnly]
        public virtual ActionResult JavaScriptDisabledWarning()
        {
            if (!_commonSettings.DisplayJavaScriptDisabledWarning)
                return Content("");

            return PartialView();
        }

        //header links
        [ChildActionOnly]
        public virtual ActionResult HeaderLinks()
        {
            var model = _commonModelFactory.PrepareHeaderLinksModel();
            return PartialView(model);
        }

        public virtual ActionResult GenericUrl()
        {
            //seems that no entity was found
            return InvokeHttp404();
        }


        #endregion
    }
}
