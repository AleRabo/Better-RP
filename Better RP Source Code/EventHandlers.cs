using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using HintServiceMeow.UI.Utilities;
using PlayerRoles;

namespace BetterRP
{
    public class EventHandlers
    {
        Role scpsubject;
        bool teslaEnabled = true;
        Exiled.API.Features.TeslaGate tesla;

        // The scp annuncement when the round start (not configurable via config)
        public void ScpBreakContainmentAnnouncement()
        {

        var SCPs = Player.List.Where(x => x.LeadingTeam == LeadingTeam.Anomalies);
            var pronounciations = new Dictionary<RoleTypeId, string>
            {
                { RoleTypeId.Scp049, "SCP 0 4 9"},
                { RoleTypeId.Scp079, "SCP 0 7 9" },
                { RoleTypeId.Scp096, "SCP 0 9 6" },
                { RoleTypeId.Scp106, "SCP 1 0 6" },
                { RoleTypeId.Scp173, "SCP 1 7 3" },
                { RoleTypeId.Scp939, "SCP 9 3 9" },
            };
            var text = SCPs.Aggregate("", (current, scp) => current + $" {pronounciations[scp.Role]}");
            if (string.IsNullOrEmpty(text))
                Cassie.DelayedMessage($"attention all personnel detected {SCPs.Count()} scpsubject breach {text}", 5);
        }

        // The hint that show up when someone interact with a blocked door
        public void OnInteractingBlockedDoor(InteractingDoorEventArgs ev)
        {
            if (!ev.IsAllowed)
            {
                var playerUi = PlayerUI.Get(ev.Player);//Could be ReferenceHub or Player
                playerUi.CommonHint.ShowItemHint(BetterRP.Singleton.Translation.InteractingBlockedDoor);
            }
        }

        // The bypass for tesla gate with a tablet in his inventory
        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            tesla = ev.Tesla;
            if (BetterRP.Singleton.Config.AutoTeslaBypasss)
            {
                if (ev.Player.Inventory.UserInventory.Items.Any(item => BetterRP.Singleton.Config.TeslagateBypassItem.Contains(item.Value.ItemTypeId)))
                { 
                    ev.DisableTesla = true;
                }
            }
            else
            { 
                if (teslaEnabled)
                {
                    ev.DisableTesla = false;
                }
                else
                {
                    var playerUi = PlayerUI.Get(ev.Player);//Could be ReferenceHub or Player
                    playerUi.CommonHint.ShowItemHint(BetterRP.Singleton.Translation.TeslaGatebypasstHint);

                    ev.DisableTesla = true;
                }
            }
        }

        public void OnThrowing(DroppingItemEventArgs ev)
        {
            if (!BetterRP.Singleton.Config.AutoTeslaBypasss && ev.IsThrown && BetterRP.Singleton.Config.TeslagateBypassItem.Contains(ev.Item.Type) && tesla.IsPlayerInIdleRange(ev.Player))
            {
                ev.IsAllowed = false;
                if (teslaEnabled)
                {
                    teslaEnabled = false;
                }
                else
                {
                    teslaEnabled = true;
                }
            }
        }

        // The hint that show up when someone activate the WarHead panel
        public void OnActivatingWarheadPanel(ActivatingWarheadPanelEventArgs ev)
        {
            var playerUi = PlayerUI.Get(ev.Player);//Could be ReferenceHub or Player
            playerUi.CommonHint.ShowItemHint(BetterRP.Singleton.Translation.ActivatingWarheadPanel);
        }
        // The hint that show up when someone heal himself
        public void OnPlayerHeal(UsedItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.Medkit || ev.Item.Type == ItemType.Painkillers)
            {
                var playerUi = PlayerUI.Get(ev.Player);//Could be ReferenceHub or Player
                playerUi.CommonHint.ShowItemHint(BetterRP.Singleton.Translation.PlayerHealHint);
            }
        }

        // The damage indicator
        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Attacker != null && ev.Amount > 0 && ev.Attacker != ev.Player && ev.Attacker.IsAlive && BetterRP.Singleton.Config.DamageIndicatorIsEnabled)
            {
                var playerUi = PlayerUI.Get(ev.Attacker);//Could be ReferenceHub or Player
                playerUi.CommonHint.ShowRoleHint(BetterRP.Singleton.Translation.DamageIndicatorHint.Replace("%damage", ev.Amount.ToString()).Replace("%target", ev.Player.Nickname));
            }
        }
    }
}
