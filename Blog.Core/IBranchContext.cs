using Blog.Core.Domain.Branches;

namespace Blog.Core
{
    /// <summary>
    /// Store context
    /// </summary>
    public interface IBranchContext
    {
        /// <summary>
        /// Gets or sets the current store
        /// </summary>
        Branch CurrentStore { get; }
    }
}
