using System;
using System.Collections.Generic;
//using System.ServiceModel.Syndication;
using System.Web.Mvc;
using Blog.Core;
using Blog.Core.Domain.Blogs;
using Blog.Core.Domain.Customers;
using Blog.Core.Domain.Localization;
using Blog.Services.Blogs;
//using Blog.Services.Events;
using Blog.Services.Localization;
using Blog.Services.Logging;
//using Blog.Services.Messages;
using Blog.Services.Security;
using Blog.Web.Extensions;
//using Blog.Services.Seo;
//using Blog.Services.Stores;
using Blog.Web.Factories;
using Blog.Web.Framework;
using Blog.Web.Framework.Controllers;
using Blog.Web.Framework.Security;
//using Blog.Web.Framework.Security.Captcha;
using Blog.Web.Models.Blogs;

namespace Blog.Web.Controllers
{
    //[NopHttpsRequirement(SslRequirement.No)]
    public partial class BlogController : BasePublicController
    {
        #region Fields

        private readonly IBlogService _blogService;
        private readonly IWorkContext _workContext;
        private readonly ILanguageService _languageService;
        //private readonly IStoreContext _storeContext;
        private readonly ILocalizationService _localizationService;
        //private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IWebHelper _webHelper;
        private readonly ICustomerActivityService _customerActivityService;
        //private readonly IStoreMappingService _storeMappingService;
        private readonly IPermissionService _permissionService;
        private readonly IBlogModelFactory _blogModelFactory;
        //private readonly IEventPublisher _eventPublisher;

        private readonly BlogSettings _blogSettings;
        private readonly LocalizationSettings _localizationSettings;
        //private readonly CaptchaSettings _captchaSettings;

        #endregion

        #region Constructors

        public BlogController(IBlogService blogService,
            IWorkContext workContext,
            ILanguageService languageService,
            //IStoreContext storeContext,
            ILocalizationService localizationService,
            //IWorkflowMessageService workflowMessageService,
            IWebHelper webHelper,
            ICustomerActivityService customerActivityService,
            //IStoreMappingService storeMappingService,
            IPermissionService permissionService,
            IBlogModelFactory blogModelFactory,
            //IEventPublisher eventPublisher,
            BlogSettings blogSettings,
            LocalizationSettings localizationSettings/*,
            CaptchaSettings captchaSettings*/)
        {
            this._blogService = blogService;
            this._workContext = workContext;
            this._languageService = languageService;
            //this._storeContext = storeContext;
            this._localizationService = localizationService;
            //this._workflowMessageService = workflowMessageService;
            this._webHelper = webHelper;
            this._customerActivityService = customerActivityService;
            //this._storeMappingService = storeMappingService;
            this._permissionService = permissionService;
            this._blogModelFactory = blogModelFactory;
            //this._eventPublisher = eventPublisher;

            this._blogSettings = blogSettings;
            this._localizationSettings = localizationSettings;
            //this._captchaSettings = captchaSettings;
        }

        #endregion

        #region Utilities

        [NonAction]
        protected virtual void PrepareLanguagesModel(BlogPostCreateModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var languages = _languageService.GetAllLanguages(true);
            foreach (var language in languages)
            {
                model.AvailableLanguages.Add(new SelectListItem
                {
                    Text = language.Name,
                    Value = language.Id.ToString()
                });
            }
        }
        #endregion
        #region Methods

        public virtual ActionResult List(BlogPagingFilteringModel command)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("HomePage");

            var model = _blogModelFactory.PrepareBlogPostListModel(command);
            return View("List", model);
        }
        public virtual ActionResult BlogByTag(BlogPagingFilteringModel command)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("HomePage");

            var model = _blogModelFactory.PrepareBlogPostListModel(command);
            return View("List", model);
        }
        public virtual ActionResult BlogByMonth(BlogPagingFilteringModel command)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("HomePage");

            var model = _blogModelFactory.PrepareBlogPostListModel(command);
            return View("List", model);
        }

        //public virtual ActionResult ListRss(int languageId)
        //{
        //    var feed = new SyndicationFeed(
        //        string.Format("{0}: Blog", _storeContext.CurrentStore.GetLocalized(x => x.Name)),
        //        "Blog",
        //        new Uri(_webHelper.GetStoreLocation(false)),
        //        string.Format("urn:store:{0}:blog", _storeContext.CurrentStore.Id),
        //        DateTime.UtcNow);

        //    if (!_blogSettings.Enabled)
        //        return new RssActionResult(feed, _webHelper.GetThisPageUrl(false));

        //    var items = new List<SyndicationItem>();
        //    var blogPosts = _blogService.GetAllBlogPosts(_storeContext.CurrentStore.Id, languageId);
        //    foreach (var blogPost in blogPosts)
        //    {
        //        string blogPostUrl = Url.RouteUrl("BlogPost", new { SeName = blogPost.GetSeName(blogPost.LanguageId, ensureTwoPublishedLanguages: false) }, _webHelper.IsCurrentConnectionSecured() ? "https" : "http");
        //        items.Add(new SyndicationItem(blogPost.Title, blogPost.Body, new Uri(blogPostUrl), String.Format("urn:store:{0}:blog:post:{1}", _storeContext.CurrentStore.Id, blogPost.Id), blogPost.CreatedOnUtc));
        //    }
        //    feed.Items = items;
        //    return new RssActionResult(feed, _webHelper.GetThisPageUrl(false));
        //}

        public virtual ActionResult BlogPost(int blogPostId)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("HomePage");

            var blogPost = _blogService.GetBlogPostById(blogPostId);
            if (blogPost == null ||
                (blogPost.StartDateUtc.HasValue && blogPost.StartDateUtc.Value >= DateTime.UtcNow) ||
                (blogPost.EndDateUtc.HasValue && blogPost.EndDateUtc.Value <= DateTime.UtcNow))
                return RedirectToRoute("HomePage");

            ////Store mapping
            //if (!_storeMappingService.Authorize(blogPost))
            //    return InvokeHttp404();
            
            //display "edit" (manage) link
            if (_permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && _permissionService.Authorize(StandardPermissionProvider.ManageBlog))
                DisplayEditLink(Url.Action("Edit", "Blog", new { id = blogPost.Id, area = "Admin" }));

            var model = new BlogPostModel();
            _blogModelFactory.PrepareBlogPostModel(model, blogPost, true);

            return View(model);
        }

        [HttpPost, ActionName("BlogPost")]
        //[PublicAntiForgery]
        [FormValueRequired("add-comment")]
        //[CaptchaValidator]
        public virtual ActionResult BlogCommentAdd(int blogPostId, BlogPostModel model)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("HomePage");

            var blogPost = _blogService.GetBlogPostById(blogPostId);
            if (blogPost == null || !blogPost.AllowComments)
                return RedirectToRoute("HomePage");

            if (_workContext.CurrentCustomer.IsGuest() && !_blogSettings.AllowNotRegisteredUsersToLeaveComments)
            {
                ModelState.AddModelError("", _localizationService.GetResource("Blog.Comments.OnlyRegisteredUsersLeaveComments"));
            }

            ////validate CAPTCHA
            //if (_captchaSettings.Enabled && _captchaSettings.ShowOnBlogCommentPage && !captchaValid)
            //{
            //    ModelState.AddModelError("", _captchaSettings.GetWrongCaptchaMessage(_localizationService));
            //}

            if (ModelState.IsValid)
            {
                var comment = new BlogComment
                {
                    BlogPostId = blogPost.Id,
                    CustomerId = _workContext.CurrentCustomer.Id,
                    CommentText = model.AddNewComment.CommentText,
                    IsApproved = !_blogSettings.BlogCommentsMustBeApproved,
                    StoreId = 1,
                    CreatedOnUtc = DateTime.UtcNow,
                };
                blogPost.BlogComments.Add(comment);
                _blogService.UpdateBlogPost(blogPost);

                ////notify a store owner
                //if (_blogSettings.NotifyAboutNewBlogComments)
                //    _workflowMessageService.SendBlogCommentNotificationMessage(comment, _localizationSettings.DefaultAdminLanguageId);

                ////activity log
                //_customerActivityService.InsertActivity("PublicStore.AddBlogComment", _localizationService.GetResource("ActivityLog.PublicStore.AddBlogComment"));

                ////raise event
                //if (comment.IsApproved)
                //    _eventPublisher.Publish(new BlogCommentApprovedEvent(comment));

                ////The text boxes should be cleared after a comment has been posted
                ////That' why we reload the page
                //TempData["nop.blog.addcomment.result"] = comment.IsApproved
                //    ? _localizationService.GetResource("Blog.Comments.SuccessfullyAdded")
                //    : _localizationService.GetResource("Blog.Comments.SeeAfterApproving");
                //return RedirectToRoute("BlogPost", new { SeName = "" });
            }

            //If we got this far, something failed, redisplay form
            _blogModelFactory.PrepareBlogPostModel(model, blogPost, true);
            return View(model);
        }

        //[ChildActionOnly]
        //public virtual ActionResult BlogTags()
        //{
        //    if (!_blogSettings.Enabled)
        //        return Content("");

        //    var model = _blogModelFactory.PrepareBlogPostTagListModel();
        //    return PartialView(model);
        //}

        //[ChildActionOnly]
        //public virtual ActionResult BlogMonths()
        //{
        //    if (!_blogSettings.Enabled)
        //        return Content("");

        //    var model = _blogModelFactory.PrepareBlogPostYearModel();
        //    return PartialView(model);
        //}

        //[ChildActionOnly]
        //public virtual ActionResult RssHeaderLink()
        //{
        //    if (!_blogSettings.Enabled || !_blogSettings.ShowHeaderRssUrl)
        //        return Content("");

        //    string link = string.Format("<link href=\"{0}\" rel=\"alternate\" type=\"{1}\" title=\"{2}: Blog\" />",
        //        Url.RouteUrl("BlogRSS", new { languageId = _workContext.WorkingLanguage.Id }, _webHelper.IsCurrentConnectionSecured() ? "https" : "http"), MimeTypes.ApplicationRssXml, _storeContext.CurrentStore.GetLocalized(x => x.Name));

        //    return Content(link);
        //}
        #endregion

        public virtual ActionResult Create()
        {
            //if (!_permissionService.Authorize(StandardPermissionProvider.ManageBlog))
                //return AccessDeniedView();

            var model = new BlogPostCreateModel();
            //languages
            PrepareLanguagesModel(model);

            //default values
            model.AllowComments = true;
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual ActionResult Create(BlogPostCreateModel model, bool continueEditing)
        {
            //if (!_permissionService.Authorize(StandardPermissionProvider.ManageBlog))
                //return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var blogPost = model.ToEntity();
                blogPost.StartDateUtc = model.StartDate;
                blogPost.EndDateUtc = model.EndDate;
                blogPost.CreatedOnUtc = DateTime.UtcNow;
                _blogService.InsertBlogPost(blogPost);

                ////activity log
                //_customerActivityService.InsertActivity("AddNewBlogPost", _localizationService.GetResource("ActivityLog.AddNewBlogPost"), blogPost.Id);

                ////search engine name
                //var seName = blogPost.ValidateSeName(model.SeName, model.Title, true);
                //_urlRecordService.SaveSlug(blogPost, seName, blogPost.LanguageId);


                SuccessNotification(_localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Added"));

                //if (continueEditing)
                //{
                //    //selected tab
                //    SaveSelectedTabName();

                //    return RedirectToAction("Edit", new { id = blogPost.Id });
                //}
                return RedirectToAction("List");
            }

            //If we got this far, something failed, redisplay form
            PrepareLanguagesModel(model);
            return View(model);
        }

    }
}
