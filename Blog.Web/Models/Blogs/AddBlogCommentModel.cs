using System.Web.Mvc;
using Blog.Web.Framework;
using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Blogs
{
    public partial class AddBlogCommentModel : BaseOsusEntityModel
    {
        [OsusResourceDisplayName("Blog.Comments.CommentText")]
        [AllowHtml]
        public string CommentText { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}