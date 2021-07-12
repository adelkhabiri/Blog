using System.Web.Routing;
using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Cms
{
    public partial class RenderWidgetModel : BaseOsusModel
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
    }
}