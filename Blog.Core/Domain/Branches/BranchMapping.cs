namespace Blog.Core.Domain.Branches
{
    /// <summary>
    /// Represents a store mapping record
    /// </summary>
    public partial class BranchMapping : BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// Gets or sets the entity name
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the store identifier
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the store
        /// </summary>
        public virtual Branch Store { get; set; }
    }
}
