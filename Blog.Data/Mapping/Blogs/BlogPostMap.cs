using Blog.Core.Domain.Blogs;

namespace Blog.Data.Mapping.Blogs
{
    public partial class BlogPostMap : OsusEntityTypeConfiguration<BlogPost>
    {
        public BlogPostMap()
        {
            this.ToTable("BlogPost");
            this.HasKey(bp => bp.Id);
            this.Property(bp => bp.Title).IsRequired();
            this.Property(bp => bp.Body).IsRequired();
            this.Property(bp => bp.MetaKeywords).HasMaxLength(400);
            this.Property(bp => bp.MetaTitle).HasMaxLength(400);

            this.HasRequired(bp => bp.Language)
                .WithMany()
                .HasForeignKey(bp => bp.LanguageId).WillCascadeOnDelete(true);
        }
    }
}