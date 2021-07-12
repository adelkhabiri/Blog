using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Common
{
    public partial class HeaderLinksModel : BaseOsusModel
    {
        public bool IsAuthenticated { get; set; }
        public string CustomerName { get; set; }

        public bool AllowPrivateMessages { get; set; }
        public string UnreadPrivateMessages { get; set; }
        public string AlertMessage { get; set; }
    }
}