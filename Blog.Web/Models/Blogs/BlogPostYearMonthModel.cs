using System.Collections.Generic;
using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Blogs
{
    public partial class BlogPostYearModel : BaseOsusModel
    {
        public BlogPostYearModel()
        {
            Months = new List<BlogPostMonthModel>();
        }
        public int Year { get; set; }
        public IList<BlogPostMonthModel> Months { get; set; }
    }
    public partial class BlogPostMonthModel : BaseOsusModel
    {
        public int Month { get; set; }

        public int BlogPostCount { get; set; }
    }
}