using System.Collections.Generic;

namespace Blog.Web.Framework.Localization
{
    public interface ILocalizedModel
    {

    }
    public interface ILocalizedModel<TLocalizedModel> : ILocalizedModel
    {
        IList<TLocalizedModel> Locales { get; set; }
    }
}
