using FluentValidation;
using Blog.Web.Models.Blogs;
using Blog.Core.Domain.Blogs;
using Blog.Data;
using Blog.Services.Localization;
using Blog.Web.Framework.Validators;

namespace Blog.Web.Validators.Blogs
{
    public partial class BlogPostCreateValidator : BaseOsusValidator<BlogPostCreateModel>
    {
        public BlogPostCreateValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Fields.Title.Required"));

            RuleFor(x => x.Body)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Fields.Body.Required"));

            //blog tags should not contain dots
            //current implementation does not support it because it can be handled as file extension
            RuleFor(x => x.Tags)
                .Must(x => x == null || !x.Contains("."))
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Fields.Tags.NoDots"));

            SetDatabaseValidationRules<BlogPost>(dbContext);

        }
    }
}