using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Blog.Core;
using Blog.Core.Caching;
using Blog.Core.Domain;
using Blog.Core.Domain.Blogs;
using Blog.Core.Domain.Common;
using Blog.Core.Domain.Customers;
using Blog.Core.Domain.Localization;
using Blog.Services.Common;
using Blog.Services.Customers;
using Blog.Services.Localization;
using Blog.Services.Media;
using Blog.Services.Security;
using Blog.Web.Framework.UI;
using Blog.Web.Models.Common;

namespace Blog.Web.Factories
{
    /// <summary>
    /// Represents the common models factory
    /// </summary>
    public partial class CommonModelFactory : ICommonModelFactory
    {
        #region Fields
        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;
        private readonly IWorkContext _workContext;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IWebHelper _webHelper;
        private readonly IPermissionService _permissionService;
        private readonly ICacheManager _cacheManager;
        private readonly IPageHeadBuilder _pageHeadBuilder;
        private readonly IPictureService _pictureService;
        private readonly HttpContextBase _httpContext;

        private readonly CommonSettings _commonSettings;
        private readonly BlogSettings _blogSettings;

        private readonly LocalizationSettings _localizationSettings;


        #endregion

        #region Constructors

        public CommonModelFactory(
            ILanguageService languageService,
            ILocalizationService localizationService,
            IWorkContext workContext,
            IGenericAttributeService genericAttributeService,
            IWebHelper webHelper,
            IPermissionService permissionService,
            ICacheManager cacheManager,
            IPageHeadBuilder pageHeadBuilder,
            IPictureService pictureService,
            HttpContextBase httpContext,
            CommonSettings commonSettings,
            BlogSettings blogSettings,
            LocalizationSettings localizationSettings)
        {
            this._languageService = languageService;
            this._localizationService = localizationService;
            this._workContext = workContext;
            this._genericAttributeService = genericAttributeService;
            this._webHelper = webHelper;
            this._permissionService = permissionService;
            this._cacheManager = cacheManager;
            this._pageHeadBuilder = pageHeadBuilder;
            this._pictureService = pictureService;
            this._httpContext = httpContext;
            this._blogSettings = blogSettings;
        }

        #endregion

        #region Utilities

        ///// <summary>
        ///// Get the number of unread private messages
        ///// </summary>
        ///// <returns>Number of private messages</returns>
        //protected virtual int GetUnreadPrivateMessages()
        //{
        //    var result = 0;
        //    var customer = _workContext.CurrentCustomer;
        //    if (_forumSettings.AllowPrivateMessages && !customer.IsGuest())
        //    {
        //        var privateMessages = _forumservice.GetAllPrivateMessages(_storeContext.CurrentStore.Id,
        //            0, customer.Id, false, null, false, string.Empty, 0, 1);

        //        if (privateMessages.TotalCount > 0)
        //        {
        //            result = privateMessages.TotalCount;
        //        }
        //    }

        //    return result;
        //}

        #endregion

        #region Methods


        /// <summary>
        /// Prepare the language selector model
        /// </summary>
        /// <returns>Language selector model</returns>
        public virtual LanguageSelectorModel PrepareLanguageSelectorModel()
        {
                var result = _languageService
                    .GetAllLanguages(storeId: 1)
                    .Select(x => new LanguageModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        FlagImageFileName = x.FlagImageFileName,
                    })
                    .ToList();

            var model = new LanguageSelectorModel
            {
                //CurrentLanguageId = _workContext.WorkingLanguage.Id,
                AvailableLanguages = result
                //UseImages = _localizationSettings.UseImagesForLanguageSelection
            };
            
            return model;
        }


        /// <summary>
        /// Prepare the header links model
        /// </summary>
        /// <returns>Header links model</returns>
        public virtual HeaderLinksModel PrepareHeaderLinksModel()
        {
            var customer = _workContext.CurrentCustomer;

            var unreadMessage = string.Empty;
            var alertMessage = string.Empty;

            var model = new HeaderLinksModel
            {
                IsAuthenticated = customer.IsRegistered(),
                CustomerName = customer.IsRegistered() ? customer.FormatUserName() : "",
                UnreadPrivateMessages = unreadMessage,
                AlertMessage = alertMessage,
            };

            return model;
        }

        
        #endregion
    }
}
