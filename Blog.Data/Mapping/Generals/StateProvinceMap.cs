using Blog.Core.Domain.Generals;

namespace Blog.Data.Mapping.Generals
{
    public partial class StateProvinceMap : OsusEntityTypeConfiguration<StateProvince>
    {
        public StateProvinceMap()
        {
            this.ToTable("StateProvince");
            this.HasKey(sp => sp.Id);
            this.Property(sp => sp.Name).IsRequired().HasMaxLength(100);
            this.Property(sp => sp.Abbreviation).HasMaxLength(100);


            this.HasRequired(sp => sp.Country)
                .WithMany(c => c.StateProvinces)
                .HasForeignKey(sp => sp.CountryId);
        }
    }
}