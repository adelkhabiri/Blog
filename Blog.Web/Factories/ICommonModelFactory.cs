using System.Web.Mvc;
using Blog.Web.Models.Common;

namespace Blog.Web.Factories
{
    /// <summary>
    /// Represents the interface of the common models factory
    /// </summary>
    public partial interface ICommonModelFactory
    {


        /// <summary>
        /// Prepare the language selector model
        /// </summary>
        /// <returns>Language selector model</returns>
        LanguageSelectorModel PrepareLanguageSelectorModel();




        /// <summary>
        /// Prepare the header links model
        /// </summary>
        /// <returns>Header links model</returns>
        HeaderLinksModel PrepareHeaderLinksModel();
    }
}
