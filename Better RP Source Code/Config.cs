using System.ComponentModel;
using Exiled.API.Interfaces;
using Exiled.Loader.Features.Configs;


namespace BetterRP
{
    public class Config : IConfig
    {
        [Description("Whether or not is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("The chance that the elevetor is broken (-1 for disable it)")]
        public int ElevatorBrokenChance { get; set; } = 9;

        [Description("The broadcast that shows up when the elevator is broken")]
        public string broken_elevator { get; set; } = "<size=70><color=red> The elevator was broken</color></size>";

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

        [Description("Whether or not is the damage indicator is enabled?")]
        public bool MTFCanCuffScps { get; set; } = true;
    }

}
