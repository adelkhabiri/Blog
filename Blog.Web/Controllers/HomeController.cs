using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Osus.Admin.Infrastructure.Cache;
using Blog.Web.Models.Home;
using Blog.Core;
using Blog.Core.Caching;
using Blog.Core.Domain.Common;
using Blog.Core.Domain.Customers;
using Blog.Services.Configuration;
//using Blog.Services.Customers;
using Blog.Services.Security;

namespace Blog.Web.Controllers
{
    public class HomeController : BaseAdminController
    {
        #region Fields
        private readonly AdminAreaSettings _adminAreaSettings;
        private readonly ISettingService _settingService;
        private readonly IPermissionService _permissionService;
        private readonly IWorkContext _workContext;
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        public HomeController(//IStoreContext storeContext,
            AdminAreaSettings adminAreaSettings,
            ISettingService settingService,
            IPermissionService permissionService,
            //ICustomerService customerService,
            IWorkContext workContext,
            ICacheManager cacheManager)
        {
            this._adminAreaSettings = adminAreaSettings;
            this._settingService = settingService;
            this._permissionService = permissionService;
            //this._customerService = customerService;
            this._workContext = workContext;
            this._cacheManager = cacheManager;
        }

        #endregion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}