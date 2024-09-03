using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using MEC;
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
                ev.Player.ShowHint(BetterRP.Singleton.Config.InteractingBlockedDoor, 6);
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
                  // The hint that show up when a player bypass a tesla gate
                    ev.Player.ShowHint(BetterRP.Singleton.Config.TeslaGatebypasstHint);

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
            => ev.Player.ShowHint(BetterRP.Singleton.Config.ActivatingWarheadPanel, 6);

        // The hint that show up when someone heal himself
        public void OnPlayerHeal(UsedItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.Medkit || ev.Item.Type == ItemType.Painkillers)
                Timing.CallDelayed(2.0f, () => ev.Player.ShowHint(BetterRP.Singleton.Config.PlayerHealHint, 6));
        }

        // The damage indicator
        public void OnHurting(HurtingEventArgs ev)
        {
            if (BetterRP.Singleton.Config.DamageIndicatorIsEnabled && ev.IsAllowed && ev.Player != null && !ev.Player.IsDead && ev.Amount > 0 && ev.Player != ev.Attacker)
                ev.Attacker.ShowHint(BetterRP.Singleton.Config.DamageIndicatorHint.Replace("%damage", ev.Amount.ToString()).Replace("%player", ev.Player.Nickname), 6);
        }
    }
}
