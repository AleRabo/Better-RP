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

        [Description("The chance that the elevetor is broken (-1 for disable it)")]
        public int ElevatorBrokenChance { get; set; } = 9;

        [Description("The broadcast that shows up when the elevator is broken")]
        public string broken_elevator { get; set; } = "<size=70><color=red> The elevator was broken</color></size>";

        [Description("Whether or not is the broken elevator afflict the SCPS")]
        public bool ElevatorBrokeAfflictScps { get; set; } = true;

        [Description("The hint that shows up when a player find a blocked door")]
        public string InteractingBlockedDoor { get; set; } = "<size=30> I need a <size=30><color=green>Key Card</color></size> for open this door</size>";

        [Description("The hint that shows up when a player activate the alpha warhead")]
        public string ActivatingWarheadPanel { get; set; } = "<size=30> Ok, now i can activate the Alpha Warhead</size>";

        [Description("The hint that shows up when a player heal himself")]
        public string PlayerHealHint { get; set; } = "<size=20> Now i'm felling good</size>";

        [Description("Whether or not is the damage indicator is enabled?")]
        public bool DamageIndicatorIsEnabled { get; set; } = true;

        [Description("The hint that shows up when a player hit an another player")]
        public string DamageIndicatorHint { get; set; } = "<size=20> You damaged %player, %damage of damage caused</size>";

        [Description("The bypass for tesla gate with a tablet")]
        public bool TeslagateBypassWithTablet { get; set; } = true;

        [Description("The hint that shows up when a stop a tesla gate with a tablet")]
        public string TeslaGatebypasstHint { get; set; } = "<size=20> With a tablet the tesla gate are no longer a problem</size>";

        // The list of SCPS role that can be cuffed

        [Description("List of SCP roles that can be cuffed")]
        public List<RoleType> SCPRoles { get; set; } = new List<RoleType>
        {
            RoleType.Scp93989,
            RoleType.Scp93953,
            RoleType.Scp049,
            RoleType.Scp096,
            RoleType.Scp106,
            RoleType.Scp173,
            RoleType.Scp0492
        };
    }
}
