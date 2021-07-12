using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Home
{
    public partial class CommonStatisticsModel : BaseOsusModel
    {
        public int NumberOfMembers { get; set; }

        public int NumberOfActiveMembers { get; set; }

        public int NumberOfInActiveMembers { get; set; }

        public int NumberOfInquiryFollowup { get; set; }
    }
}