using System;
using AutoMapper;
using Blog.Web.Models.Blogs;
using Blog.Web.Models.Customers;
using Blog.Web.Models.Generals;
using Blog.Web.Models.Localization;
//using Osus.Admin.Models.Logging;
using Blog.Core.Domain.Blogs;
using Blog.Core.Domain.Common;
using Blog.Core.Domain.Customers;
using Blog.Core.Domain.Generals;
using Blog.Core.Domain.Localization;
//using Blog.Core.Domain.Logging;
using Blog.Core.Domain.Media;
using Blog.Core.Infrastructure.Mapper;

namespace Blog.Web.Infrastructure.Mapper
{
    /// <summary>
    /// AutoMapper configuration for admin area models
    /// </summary>
    public class AdminMapperConfiguration : IMapperConfiguration
    {
        /// <summary>
        /// Get configuration
        /// </summary>
        /// <returns>Mapper configuration action</returns>
        public Action<IMapperConfigurationExpression> GetConfiguration()
        {
            //TODO remove 'CreatedOnUtc' ignore mappings because now presentation layer models have 'CreatedOn' property and core entities have 'CreatedOnUtc' property (distinct names)

            Action<IMapperConfigurationExpression> action = cfg =>
            {

                //countries
                cfg.CreateMap<CountryModel, Country>()
                    .ForMember(dest => dest.StateProvinces, mo => mo.Ignore())
                    //.ForMember(dest => dest.RestrictedShippingMethods, mo => mo.Ignore())
                    .ForMember(dest => dest.LimitedToStores, mo => mo.Ignore());
                cfg.CreateMap<Country, CountryModel>()
                    .ForMember(dest => dest.NumberOfStates,
                        mo => mo.MapFrom(src => src.StateProvinces != null ? src.StateProvinces.Count : 0))
                    .ForMember(dest => dest.Locales, mo => mo.Ignore())
                    .ForMember(dest => dest.AvailableStores, mo => mo.Ignore())
                    .ForMember(dest => dest.SelectedStoreIds, mo => mo.Ignore())
                    .ForMember(dest => dest.CustomProperties, mo => mo.Ignore());
                //state/provinces
                cfg.CreateMap<StateProvince, StateProvinceModel>()
                    .ForMember(dest => dest.Locales, mo => mo.Ignore())
                    .ForMember(dest => dest.CustomProperties, mo => mo.Ignore());
                cfg.CreateMap<StateProvinceModel, StateProvince>()
                    .ForMember(dest => dest.Country, mo => mo.Ignore());

                //language
                cfg.CreateMap<Language, LanguageModel>()
                    .ForMember(dest => dest.AvailableStores, mo => mo.Ignore())
                    .ForMember(dest => dest.AvailableCurrencies, mo => mo.Ignore())
                    .ForMember(dest => dest.SelectedStoreIds, mo => mo.Ignore())
                    .ForMember(dest => dest.Search, mo => mo.Ignore())
                    .ForMember(dest => dest.CustomProperties, mo => mo.Ignore());
                cfg.CreateMap<LanguageModel, Language>()
                    .ForMember(dest => dest.LocaleStringResources, mo => mo.Ignore())
                    .ForMember(dest => dest.LimitedToStores, mo => mo.Ignore());
               
                //currencies
                cfg.CreateMap<Currency, CurrencyModel>()
                    .ForMember(dest => dest.CreatedOn, mo => mo.Ignore())
                    .ForMember(dest => dest.IsPrimaryExchangeRateCurrency, mo => mo.Ignore())
                    .ForMember(dest => dest.IsPrimaryStoreCurrency, mo => mo.Ignore())
                    .ForMember(dest => dest.Locales, mo => mo.Ignore())
                    .ForMember(dest => dest.AvailableStores, mo => mo.Ignore())
                    .ForMember(dest => dest.SelectedStoreIds, mo => mo.Ignore())
                    .ForMember(dest => dest.CustomProperties, mo => mo.Ignore());
                cfg.CreateMap<CurrencyModel, Currency>()
                    .ForMember(dest => dest.CreatedOnUtc, mo => mo.Ignore())
                    .ForMember(dest => dest.UpdatedOnUtc, mo => mo.Ignore())
                    .ForMember(dest => dest.LimitedToStores, mo => mo.Ignore())
                    .ForMember(dest => dest.RoundingType, mo => mo.Ignore());

                //blogs
                cfg.CreateMap<BlogPost, BlogPostCreateModel>()
                    .ForMember(dest => dest.SeName, mo => mo.Ignore() /*mo.MapFrom(src => src.GetSeName(src.LanguageId, true, false))*/)
                    .ForMember(dest => dest.ApprovedComments, mo => mo.Ignore())
                    .ForMember(dest => dest.NotApprovedComments, mo => mo.Ignore())
                    .ForMember(dest => dest.StartDate, mo => mo.Ignore())
                    .ForMember(dest => dest.EndDate, mo => mo.Ignore())
                    .ForMember(dest => dest.CreatedOn, mo => mo.Ignore())
                    .ForMember(dest => dest.AvailableStores, mo => mo.Ignore())
                    .ForMember(dest => dest.SelectedStoreIds, mo => mo.Ignore())
                    .ForMember(dest => dest.CustomProperties, mo => mo.Ignore())
                    .ForMember(dest => dest.AvailableLanguages, mo => mo.Ignore());
                cfg.CreateMap<BlogPostCreateModel, BlogPost>()
                    .ForMember(dest => dest.BlogComments, mo => mo.Ignore())
                    .ForMember(dest => dest.Language, mo => mo.Ignore())
                    .ForMember(dest => dest.StartDateUtc, mo => mo.Ignore())
                    .ForMember(dest => dest.EndDateUtc, mo => mo.Ignore())
                    .ForMember(dest => dest.CreatedOnUtc, mo => mo.Ignore())
                    .ForMember(dest => dest.LimitedToStores, mo => mo.Ignore());
                //customer roles
                cfg.CreateMap<CustomerRole, CustomerRoleModel>()
                    .ForMember(dest => dest.PurchasedWithProductName, mo => mo.Ignore())
                    .ForMember(dest => dest.CustomProperties, mo => mo.Ignore());
                cfg.CreateMap<CustomerRoleModel, CustomerRole>()
                    .ForMember(dest => dest.PermissionRecords, mo => mo.Ignore());
            };
            return action;
        }

        /// <summary>
        /// Order of this mapper implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }
}