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

        [Description("The hint that shows up when a player find a blocked door")]
        public string InteractingBlockedDoor { get; set; } = "<size=30> I need a <size=30><color=green>Key Card</color></size> for open this door</size>";

        [Description("The hint that shows up when a player activate the alpha warhead")]
        public string ActivatingWarheadPanel { get; set; } = "<size=30> Ok, now i can activate the Alpha Warhead</size>";

        [Description("The hint that shows up when a player heal himself")]
        public string PlayerHealHint { get; set; } = "<size=20> Now i'm felling good</size>";

        [Description("Whether or not is the damage indicator is enabled")]
        public bool DamageIndicatorIsEnabled { get; set; } = true;

        [Description("The hint that shows up when a player hit an another player")]
        public string DamageIndicatorHint { get; set; } = "<size=20> You damaged %player, %damage of damage caused</size>";

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

        [Description("The hint that shows up when a stop a tesla gate with a keycard")]
        public string TeslaGatebypasstHint { get; set; } = "<size=20> With this keycard the tesla gate are no longer a problem</size>";

    }
}
