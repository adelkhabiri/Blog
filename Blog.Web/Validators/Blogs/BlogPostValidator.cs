using FluentValidation;
using Blog.Services.Localization;
using Blog.Web.Framework.Validators;
using Blog.Web.Models.Blogs;

namespace Blog.Web.Validators.Blogs
{
    public partial class BlogPostValidator : BaseOsusValidator<BlogPostModel>
    {
        public BlogPostValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.AddNewComment.CommentText).NotEmpty().WithMessage(localizationService.GetResource("Blog.Comments.CommentText.Required")).When(x => x.AddNewComment != null);
        }
    }
}