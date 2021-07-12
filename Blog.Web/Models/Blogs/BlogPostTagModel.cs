using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Blogs
{
    public partial class BlogPostTagModel : BaseOsusModel
    {
        public string Name { get; set; }

        public int BlogPostCount { get; set; }
    }
}