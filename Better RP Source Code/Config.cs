using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace BetterRP
{
    /// <inheritdoc cref="IConfig"/>
    public class Config : IConfig
    {
        // The plugin configs

        [Description("Whether or not is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not is the plugin is in debug mode?")]
        public bool Debug { get; set; } = false;

        [Description("Whether or not is the damage indicator is enabled")]
        public bool DamageIndicatorIsEnabled { get; set; } = true;

        [Description("The tesla gate bypass item (Set an item to None if you want to disable it")]
        public List<ItemType> TeslagateBypassItem { get; set; } = new List<ItemType>
        {
            ItemType.KeycardMTFCaptain,
            ItemType.KeycardMTFOperative,
            ItemType.KeycardO5,
            ItemType.KeycardMTFPrivate,
            ItemType.KeycardGuard,
        };

        [Description("If set to false you must manually disable and reenable the tesla pressing T, if true the tesla automatically disables for the players with the bypass item")]
        public bool AutoTeslaBypasss { get; set; } = false;

    }
}
