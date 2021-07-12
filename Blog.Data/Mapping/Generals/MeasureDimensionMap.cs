using Blog.Core.Domain.Generals;

namespace Blog.Data.Mapping.Generals
{
    public partial class MeasureDimensionMap : OsusEntityTypeConfiguration<MeasureDimension>
    {
        public MeasureDimensionMap()
        {
            this.ToTable("MeasureDimension");
            this.HasKey(m => m.Id);
            this.Property(m => m.Name).IsRequired().HasMaxLength(100);
            this.Property(m => m.SystemKeyword).IsRequired().HasMaxLength(100);
            this.Property(m => m.Ratio).HasPrecision(18, 8);
        }
    }
}