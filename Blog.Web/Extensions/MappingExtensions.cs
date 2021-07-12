using System;
using System.Linq;
using Blog.Web.Models.Blogs;
using Blog.Web.Models.Customers;
using Blog.Web.Models.Generals;
//using Osus.Admin.Models.ExternalAuthentication;
using Blog.Web.Models.Localization;
//using Blog.Web.Models.Logging;
//using Blog.Web.Models.Settings;
using Blog.Core.Domain.Blogs;
using Blog.Core.Domain.Common;
using Blog.Core.Domain.Customers;
using Blog.Core.Domain.Generals;
using Blog.Core.Domain.Localization;
using Blog.Core.Domain.Logging;
using Blog.Core.Infrastructure.Mapper;

namespace Blog.Web.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }


     

        #region Languages

        public static LanguageModel ToModel(this Language entity)
        {
            return entity.MapTo<Language, LanguageModel>();
        }

        public static Language ToEntity(this LanguageModel model)
        {
            return model.MapTo<LanguageModel, Language>();
        }

        public static Language ToEntity(this LanguageModel model, Language destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        //#region Log

        //public static LogModel ToModel(this Log entity)
        //{
        //    return entity.MapTo<Log, LogModel>();
        //}

        //public static Log ToEntity(this LogModel model)
        //{
        //    return model.MapTo<LogModel, Log>();
        //}

        //public static Log ToEntity(this LogModel model, Log destination)
        //{
        //    return model.MapTo(destination);
        //}

        //public static ActivityLogTypeModel ToModel(this ActivityLogType entity)
        //{
        //    return entity.MapTo<ActivityLogType, ActivityLogTypeModel>();
        //}

        //public static ActivityLogModel ToModel(this ActivityLog entity)
        //{
        //    return entity.MapTo<ActivityLog, ActivityLogModel>();
        //}

        //#endregion

        #region Currencies

        public static CurrencyModel ToModel(this Currency entity)
        {
            return entity.MapTo<Currency, CurrencyModel>();
        }

        public static Currency ToEntity(this CurrencyModel model)
        {
            return model.MapTo<CurrencyModel, Currency>();
        }

        public static Currency ToEntity(this CurrencyModel model, Currency destination)
        {
            return model.MapTo(destination);
        }
        #endregion


        //#region Shipping methods

        //public static ShippingMethodModel ToModel(this ShippingMethod entity)
        //{
        //    return entity.MapTo<ShippingMethod, ShippingMethodModel>();
        //}

        //public static ShippingMethod ToEntity(this ShippingMethodModel model)
        //{
        //    return model.MapTo<ShippingMethodModel, ShippingMethod>();
        //}

        //public static ShippingMethod ToEntity(this ShippingMethodModel model, ShippingMethod destination)
        //{
        //    return model.MapTo(destination);
        //}

        //#endregion

        //#region Delivery dates

        //public static DeliveryDateModel ToModel(this DeliveryDate entity)
        //{
        //    return entity.MapTo<DeliveryDate, DeliveryDateModel>();
        //}

        //public static DeliveryDate ToEntity(this DeliveryDateModel model)
        //{
        //    return model.MapTo<DeliveryDateModel, DeliveryDate>();
        //}

        //public static DeliveryDate ToEntity(this DeliveryDateModel model, DeliveryDate destination)
        //{
        //    return model.MapTo(destination);
        //}

        //#endregion

        //#region Product availability ranges

        //public static ProductAvailabilityRangeModel ToModel(this ProductAvailabilityRange entity)
        //{
        //    return entity.MapTo<ProductAvailabilityRange, ProductAvailabilityRangeModel>();
        //}

        //public static ProductAvailabilityRange ToEntity(this ProductAvailabilityRangeModel model)
        //{
        //    return model.MapTo<ProductAvailabilityRangeModel, ProductAvailabilityRange>();
        //}

        //public static ProductAvailabilityRange ToEntity(this ProductAvailabilityRangeModel model, ProductAvailabilityRange destination)
        //{
        //    return model.MapTo(destination);
        //}


        //#region External authentication methods

        //public static AuthenticationMethodModel ToModel(this IExternalAuthenticationMethod entity)
        //{
        //    return entity.MapTo<IExternalAuthenticationMethod, AuthenticationMethodModel>();
        //}

        //#endregion

        //#region Widgets

        //public static WidgetModel ToModel(this IWidgetPlugin entity)
        //{
        //    return entity.MapTo<IWidgetPlugin, WidgetModel>();
        //}

        //#endregion

        

        #region Blog

        //blog posts
        public static BlogPostCreateModel ToModel(this BlogPost entity)
        {
            return entity.MapTo<BlogPost, BlogPostCreateModel>();
        }

        public static BlogPost ToEntity(this BlogPostCreateModel model)
        {
            return model.MapTo<BlogPostCreateModel, BlogPost>();
        }

        public static BlogPost ToEntity(this BlogPostCreateModel model, BlogPost destination)
        {
            return model.MapTo(destination);
        }

        #endregion

       
        #region Customer roles

        //customer roles
        public static CustomerRoleModel ToModel(this CustomerRole entity)
        {
            return entity.MapTo<CustomerRole, CustomerRoleModel>();
        }

        public static CustomerRole ToEntity(this CustomerRoleModel model)
        {
            return model.MapTo<CustomerRoleModel, CustomerRole>();
        }

        public static CustomerRole ToEntity(this CustomerRoleModel model, CustomerRole destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Countries / states

        public static CountryModel ToModel(this Country entity)
        {
            return entity.MapTo<Country, CountryModel>();
        }

        public static Country ToEntity(this CountryModel model)
        {
            return model.MapTo<CountryModel, Country>();
        }

        public static Country ToEntity(this CountryModel model, Country destination)
        {
            return model.MapTo(destination);
        }

        public static StateProvinceModel ToModel(this StateProvince entity)
        {
            return entity.MapTo<StateProvince, StateProvinceModel>();
        }

        public static StateProvince ToEntity(this StateProvinceModel model)
        {
            return model.MapTo<StateProvinceModel, StateProvince>();
        }

        public static StateProvince ToEntity(this StateProvinceModel model, StateProvince destination)
        {
            return model.MapTo(destination);
        }


        #endregion

        //#region Settings


        //public static BlogSettingsModel ToModel(this BlogSettings entity)
        //{
        //    return entity.MapTo<BlogSettings, BlogSettingsModel>();
        //}
        //public static BlogSettings ToEntity(this BlogSettingsModel model, BlogSettings destination)
        //{
        //    return model.MapTo(destination);
        //}

        ////customer/user settings
        //public static CustomerUserSettingsModel.CustomerSettingsModel ToModel(this CustomerSettings entity)
        //{
        //    return entity.MapTo<CustomerSettings, CustomerUserSettingsModel.CustomerSettingsModel>();
        //}
        //public static CustomerSettings ToEntity(this CustomerUserSettingsModel.CustomerSettingsModel model, CustomerSettings destination)
        //{
        //    return model.MapTo(destination);
        //}
        //public static CustomerUserSettingsModel.AddressSettingsModel ToModel(this AddressSettings entity)
        //{
        //    return entity.MapTo<AddressSettings, CustomerUserSettingsModel.AddressSettingsModel>();
        //}
        //public static AddressSettings ToEntity(this CustomerUserSettingsModel.AddressSettingsModel model, AddressSettings destination)
        //{
        //    return model.MapTo(destination);
        //}
    }
}