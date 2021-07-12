using Blog.Core.Domain.Customers;

namespace Blog.Data.Mapping.Customers
{
    public partial class CustomerPasswordMap : OsusEntityTypeConfiguration<CustomerPassword>
    {
        public CustomerPasswordMap()
        {
            this.ToTable("CustomerPassword");
            this.HasKey(password => password.Id);

            this.HasRequired(password => password.Customer)
                .WithMany()
                .HasForeignKey(password => password.CustomerId);

            this.Ignore(password => password.PasswordFormat);
        }
    }
}