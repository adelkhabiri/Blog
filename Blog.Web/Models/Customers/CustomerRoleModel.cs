using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Osus.Admin.Validators.Customers;
using Blog.Web.Framework;
using Blog.Web.Framework.Mvc;

namespace Blog.Web.Models.Customers
{
    [Validator(typeof(CustomerRoleValidator))]
    public partial class CustomerRoleModel : BaseOsusEntityModel
    {
        [OsusResourceDisplayName("Admin.Customers.CustomerRoles.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [OsusResourceDisplayName("Admin.Customers.CustomerRoles.Fields.FreeShipping")]
        [AllowHtml]
        public bool FreeShipping { get; set; }

        [OsusResourceDisplayName("Admin.Customers.CustomerRoles.Fields.TaxExempt")]
        public bool TaxExempt { get; set; }

        [OsusResourceDisplayName("Admin.Customers.CustomerRoles.Fields.Active")]
        public bool Active { get; set; }

        [OsusResourceDisplayName("Admin.Customers.CustomerRoles.Fields.IsSystemRole")]
        public bool IsSystemRole { get; set; }

        [OsusResourceDisplayName("Admin.Customers.CustomerRoles.Fields.SystemName")]
        public string SystemName { get; set; }

        [OsusResourceDisplayName("Admin.Customers.CustomerRoles.Fields.EnablePasswordLifetime")]
        public bool EnablePasswordLifetime { get; set; }

        [OsusResourceDisplayName("Admin.Customers.CustomerRoles.Fields.PurchasedWithProduct")]
        public int PurchasedWithProductId { get; set; }

        [OsusResourceDisplayName("Admin.Customers.CustomerRoles.Fields.PurchasedWithProduct")]
        public string PurchasedWithProductName { get; set; }


        #region Nested classes

        //public partial class AssociateProductToCustomerRoleModel : BaseNopModel
        //{
        //    public AssociateProductToCustomerRoleModel()
        //    {
        //        AvailableCategories = new List<SelectListItem>();
        //        AvailableManufacturers = new List<SelectListItem>();
        //        AvailableStores = new List<SelectListItem>();
        //        AvailableVendors = new List<SelectListItem>();
        //        AvailableProductTypes = new List<SelectListItem>();
        //    }

        //    [OsusResourceDisplayName("Admin.Catalog.Products.List.SearchProductName")]
        //    [AllowHtml]
        //    public string SearchProductName { get; set; }
        //    [OsusResourceDisplayName("Admin.Catalog.Products.List.SearchCategory")]
        //    public int SearchCategoryId { get; set; }
        //    [OsusResourceDisplayName("Admin.Catalog.Products.List.SearchManufacturer")]
        //    public int SearchManufacturerId { get; set; }
        //    [OsusResourceDisplayName("Admin.Catalog.Products.List.SearchStore")]
        //    public int SearchStoreId { get; set; }
        //    [OsusResourceDisplayName("Admin.Catalog.Products.List.SearchVendor")]
        //    public int SearchVendorId { get; set; }
        //    [OsusResourceDisplayName("Admin.Catalog.Products.List.SearchProductType")]
        //    public int SearchProductTypeId { get; set; }

        //    public IList<SelectListItem> AvailableCategories { get; set; }
        //    public IList<SelectListItem> AvailableManufacturers { get; set; }
        //    public IList<SelectListItem> AvailableStores { get; set; }
        //    public IList<SelectListItem> AvailableVendors { get; set; }
        //    public IList<SelectListItem> AvailableProductTypes { get; set; }

        //    //vendor
        //    public bool IsLoggedInAsVendor { get; set; }


        //    public int AssociatedToProductId { get; set; }
        //}
        #endregion
    }
}