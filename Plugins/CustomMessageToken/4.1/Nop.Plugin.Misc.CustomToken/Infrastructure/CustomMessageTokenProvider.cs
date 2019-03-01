using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Nop.Core;
using Nop.Core.Domain;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using Nop.Core.Domain.Tax;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Events;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Payments;
using Nop.Services.Seo;
using Nop.Services.Stores;
using Nop.Services.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Misc.CustomToken.Infrastructure
{
    class CustomMessageTokenProvider : MessageTokenProvider
    {
        #region Properties

        private readonly CatalogSettings _catalogSettings;
        private readonly CurrencySettings _currencySettings;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IAddressAttributeFormatter _addressAttributeFormatter;
        private readonly ICurrencyService _currencyService;
        private readonly ICustomerAttributeFormatter _customerAttributeFormatter;
        private readonly ICustomerService _customerService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IDownloadService _downloadService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly IStoreContext _storeContext;
        private readonly IStoreService _storeService;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IVendorAttributeFormatter _vendorAttributeFormatter;
        private readonly IWorkContext _workContext;
        private readonly MessageTemplatesSettings _templatesSettings;
        private readonly PaymentSettings _paymentSettings;
        private readonly StoreInformationSettings _storeInformationSettings;
        private readonly TaxSettings _taxSettings;

        #endregion

        #region Constructor

        public CustomMessageTokenProvider(CatalogSettings catalogSettings,
            CurrencySettings currencySettings,
            IActionContextAccessor actionContextAccessor,
            IAddressAttributeFormatter addressAttributeFormatter,
            ICurrencyService currencyService,
            ICustomerAttributeFormatter customerAttributeFormatter,
            ICustomerService customerService,
            IDateTimeHelper dateTimeHelper,
            IDownloadService downloadService,
            IEventPublisher eventPublisher,
            IGenericAttributeService genericAttributeService,
            ILanguageService languageService,
            ILocalizationService localizationService,
            IOrderService orderService,
            IPaymentService paymentService,
            IPriceFormatter priceFormatter,
            IStoreContext storeContext,
            IStoreService storeService,
            IUrlHelperFactory urlHelperFactory,
            IUrlRecordService urlRecordService,
            IVendorAttributeFormatter vendorAttributeFormatter,
            IWorkContext workContext,
            MessageTemplatesSettings templatesSettings,
            PaymentSettings paymentSettings,
            StoreInformationSettings storeInformationSettings,
            TaxSettings taxSettings) : base(catalogSettings,
                currencySettings,
                actionContextAccessor,
                addressAttributeFormatter,
                currencyService,
                customerAttributeFormatter,
                customerService,
                dateTimeHelper,
                downloadService,
                eventPublisher,
                genericAttributeService,
                languageService,
                localizationService,
                orderService,
                paymentService,
                priceFormatter,
                storeContext,
                storeService,
                urlHelperFactory,
                urlRecordService,
                vendorAttributeFormatter,
                workContext,
                templatesSettings,
                paymentSettings,
                storeInformationSettings,
                taxSettings
            )
        {

            this._catalogSettings = catalogSettings;
            this._currencySettings = currencySettings;
            this._actionContextAccessor = actionContextAccessor;
            this._addressAttributeFormatter = addressAttributeFormatter;
            this._currencyService = currencyService;
            this._customerAttributeFormatter = customerAttributeFormatter;
            this._customerService = customerService;
            this._dateTimeHelper = dateTimeHelper;
            this._downloadService = downloadService;
            this._eventPublisher = eventPublisher;
            this._genericAttributeService = genericAttributeService;
            this._languageService = languageService;
            this._localizationService = localizationService;
            this._orderService = orderService;
            this._paymentService = paymentService;
            this._priceFormatter = priceFormatter;
            this._storeContext = storeContext;
            this._storeService = storeService;
            this._urlHelperFactory = urlHelperFactory;
            this._urlRecordService = urlRecordService;
            this._vendorAttributeFormatter = vendorAttributeFormatter;
            this._workContext = workContext;
            this._templatesSettings = templatesSettings;
            this._paymentSettings = paymentSettings;
            this._storeInformationSettings = storeInformationSettings;
            this._taxSettings = taxSettings;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Implement our own AddOrderTokens to the MessageTokenProvider class
        /// This allows to create own Tokens for the message templates
        /// We're going to add a token for replacing the Burkhart Status Website
        /// </summary>
        /// <param name="tokens"></param>
        /// <param name="order"></param>
        /// <param name="languageId"></param>
        /// <param name="vendorId"></param>
        public override void AddOrderTokens(IList<Token> tokens, Order order, int languageId, int vendorId = 0)
        {
            // This value is hardcoded, but you could pull the value
            // from a setting or language resource string
            string callForInformation = _localizationService.GetLocaleStringResourceByName("Custom.Token.CallForInfo").ResourceValue;

            // Create a token that we can use on Message Templates
            tokens.Add(new Token("Custom.Message.Token.CallForInfo", callForInformation, true));

            base.AddOrderTokens(tokens, order, languageId, vendorId);
        }

        #endregion

    }
}
