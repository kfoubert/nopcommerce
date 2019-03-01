using System;
using Nop.Core.Plugins;
using Nop.Services.Localization;

namespace Nop.Plugin.Misc.CustomToken
{
    public class CustomTokenPlugin : BasePlugin
    {
        #region Properties

        private readonly ILocalizationService _localizationService;

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiate the Plugin
        /// </summary>
        public CustomTokenPlugin(ILocalizationService localizationService)
        {
            _localizationService = localizationService;

        }

        #endregion

        #region Methods

        public override void Install()
        {
            // install resources
            _localizationService.AddOrUpdatePluginLocaleResource("Custom.Token.CallForInfo", "Please call us at 253.555.1234");

            base.Install();
        }

        public override void Uninstall()
        {
            // remove resources
            _localizationService.DeletePluginLocaleResource("Custom.Token.CallForInfo");

            base.Uninstall();
        }

        #endregion

    }
}
