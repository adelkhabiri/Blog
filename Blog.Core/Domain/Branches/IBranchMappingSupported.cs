namespace Blog.Core.Domain.Branches
{
    /// <summary>
    /// Represents an entity which supports store mapping
    /// </summary>
    public partial interface IBranchMappingSupported
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        bool LimitedToStores { get; set; }
    }
}
