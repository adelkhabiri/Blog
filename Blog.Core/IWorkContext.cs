﻿using Blog.Core.Domain.Customers;
using Blog.Core.Domain.Generals;
using Blog.Core.Domain.Localization;
//using Blog.Core.Domain.Tax;
//using Blog.Core.Domain.Vendors;

namespace Blog.Core
{
    /// <summary>
    /// Work context
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        Customer CurrentCustomer { get; set; }
        /// <summary>
        /// Gets or sets the original customer (in case the current one is impersonated)
        /// </summary>
        Customer OriginalCustomerIfImpersonated { get; }
        ///// <summary>
        ///// Gets or sets the current vendor (logged-in manager)
        ///// </summary>
        //Vendor CurrentVendor { get; }

        /// <summary>
        /// Get or set current user working language
        /// </summary>
        Language WorkingLanguage { get; set; }
        /// <summary>
        /// Get or set current user working currency
        /// </summary>
        Currency WorkingCurrency { get; set; }
        ///// <summary>
        ///// Get or set current tax display type
        ///// </summary>
        //TaxDisplayType TaxDisplayType { get; set; }

        /// <summary>
        /// Get or set value indicating whether we're in admin area
        /// </summary>
        bool IsAdmin { get; set; }
    }
}
