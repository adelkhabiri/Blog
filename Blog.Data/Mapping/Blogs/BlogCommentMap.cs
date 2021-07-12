using Blog.Core.Domain.Blogs;

namespace Blog.Data.Mapping.Blogs
{
    public partial class BlogCommentMap : OsusEntityTypeConfiguration<BlogComment>
    {
        public BlogCommentMap()
        {
            this.ToTable("BlogComment");
            this.HasKey(comment => comment.Id);

            this.HasRequired(comment => comment.BlogPost)
                .WithMany(blog => blog.BlogComments)
                .HasForeignKey(comment => comment.BlogPostId);

            this.HasRequired(comment => comment.Customer)
                .WithMany()
                .HasForeignKey(comment => comment.CustomerId);

        }
    }
}