using Exiled.API.Interfaces;
using InventorySystem.Items.Usables.Scp330;
using System.Collections.Generic;
using System.ComponentModel;

namespace BetterRP
{
    public sealed class Translation : ITranslation
    {

        [Description("The hint that shows up when a player find a blocked door")]
        public string InteractingBlockedDoor { get; set; } = "<size=20> I need a <size=30><color=green>Key Card</color></size> to open this door</size>";

        [Description("The hint that shows up when a player activate the alpha warhead")]
        public string ActivatingWarheadPanel { get; set; } = "<size=30> Ok, now i can activate the Alpha Warhead</size>";

        [Description("The hint that shows up when a player heal himself")]
        public string PlayerHealHint { get; set; } = "<size=20> Now i'm felling good</size>";

        [Description("The hint that shows up when a player hit an another player")]
        public string DamageIndicatorHint { get; set; } = "<size=20> You damaged %target, %damage of damage caused</size>";

        [Description("The hint that shows up when a stop a tesla gate with a keycard")]
        public string TeslaGatebypasstHint { get; set; } = "<size=20> With this keycard the tesla gate are no longer a problem</size>";
    }
}