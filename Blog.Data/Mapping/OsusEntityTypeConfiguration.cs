using System.Data.Entity.ModelConfiguration;

namespace Blog.Data.Mapping
{
    public abstract class OsusEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected OsusEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
            
        }
    }
}