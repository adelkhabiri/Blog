using System;
using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Blogs
{
    public partial class BlogCommentModel : BaseOsusEntityModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAvatarUrl { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool AllowViewingProfiles { get; set; }
    }
}