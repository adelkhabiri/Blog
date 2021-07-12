using System.Collections.Generic;
using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Blogs
{
    public partial class BlogPostListModel : BaseOsusModel
    {
        public BlogPostListModel()
        {
            PagingFilteringContext = new BlogPagingFilteringModel();
            BlogPosts = new List<BlogPostModel>();
        }

        public int WorkingLanguageId { get; set; }
        public BlogPagingFilteringModel PagingFilteringContext { get; set; }
        public IList<BlogPostModel> BlogPosts { get; set; }
    }
}