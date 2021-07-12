using System.Collections.Generic;
using Blog.Core.Domain.Common;
using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Customer
{
    public partial class CustomerAttributeModel : BaseOsusEntityModel
    {
        public CustomerAttributeModel()
        {
            Values = new List<CustomerAttributeValueModel>();
        }

        public string Name { get; set; }

        public bool IsRequired { get; set; }

        /// <summary>
        /// Default value for textboxes
        /// </summary>
        public string DefaultValue { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<CustomerAttributeValueModel> Values { get; set; }

    }

    public partial class CustomerAttributeValueModel : BaseOsusEntityModel
    {
        public string Name { get; set; }

        public bool IsPreSelected { get; set; }
    }
}