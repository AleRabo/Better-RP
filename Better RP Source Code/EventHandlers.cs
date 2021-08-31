using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using UnityEngine;

namespace BetterRP
{
    public class EventHandlers
    {
        Role scpsubject;

        // The scp annuncement when the round start (not configurable via config)
        public void ScpBreakContainmentAnnouncement()
        {
            var SCPs = Player.List.Where(x => x.Side == Side.Scp);
            var pronounciations = new Dictionary<RoleType, string>
            {
                { RoleType.Scp049, "SCP 0 4 9"},
                { RoleType.Scp079, "SCP 0 7 9" },
                { RoleType.Scp096, "SCP 0 9 6" },
                { RoleType.Scp106, "SCP 1 0 6" },
                { RoleType.Scp173, "SCP 1 7 3" },
                { RoleType.Scp93953, "SCP 9 3 9 5 3" },
                { RoleType.Scp93989, "SCP 9 3 9 8 9" }
            };
            var text = SCPs.Aggregate("", (current, scp) => current + $" {pronounciations[scp.Role]}");
            if (string.IsNullOrEmpty(text))
                Cassie.DelayedMessage($"attention all personnel detected {SCPs.Count()} scpsubject breach {text}", 5);
        }

        // The elevator broke
        public void OnBrokingElevator(InteractingElevatorEventArgs ev)
        {
            if (ev.Lift.InRange(ev.Player.Position, out GameObject gameObject) && Random.Range(0, 101) <= Plugin.Singleton.Config.ElevatorBrokenChance)
            {
                    if (Plugin.Singleton.Config.ElevatorBrokeAfflictScps && ev.Player.IsScp)
                    {
                        Timing.CallDelayed(2.0f, () => ev.Player.Hurt(400, DamageTypes.Falldown));
                        Timing.CallDelayed(2.0f, () => ev.Player.Broadcast(6, Plugin.Singleton.Config.broken_elevator));
                    }

                    if (ev.Player.IsHuman)
                    {
                        Timing.CallDelayed(2.0f, () => ev.Player.Kill(DamageTypes.Falldown));
                        Timing.CallDelayed(2.0f, () => ev.Player.Broadcast(6, Plugin.Singleton.Config.broken_elevator));
                    }
            }
        }

        // The hint that show up when someone interact with a blocked door
        public void OnInteractingBlockedDoor(InteractingDoorEventArgs ev)
        {
            if (!ev.IsAllowed)
                ev.Player.ShowHint(Plugin.Singleton.Config.InteractingBlockedDoor, 6);
        }

        // The bypass for tesla gate with a tablet in his inventory
        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (Plugin.Singleton.Config.TeslagateBypassWithTablet && ev.Player.HasItem(ItemType.WeaponManagerTablet))
            {
                // The hint that show up when a player bypass a tesla gate
                ev.Player.ShowHint(Plugin.Singleton.Config.TeslaGatebypasstHint);

                

                ev.IsTriggerable = false;
            }
        }

        // The hint that show up when someone activate the WarHead panel
        public void OnActivatingWarheadPanel(ActivatingWarheadPanelEventArgs ev)
            => ev.Player.ShowHint(Plugin.Singleton.Config.ActivatingWarheadPanel, 6);

        // The hint that show up when someone heal himself
        public void OnPlayerHeal(UsedItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.Medkit && ev.Item.Type == ItemType.Painkillers)
                Timing.CallDelayed(2.0f, () =>  ev.Player.ShowHint(Plugin.Singleton.Config.PlayerHealHint, 6));
        }

        // The damage indicator
        public void OnHurting(HurtingEventArgs ev)
        {
            if (Plugin.Singleton.Config.DamageIndicatorIsEnabled && ev.IsAllowed && ev.Target != null && !ev.Target.IsDead && !ev.Target.IsInvisible && ev.Amount > 0 && ev.Target != ev.Attacker)
                ev.Attacker.ShowHint(Plugin.Singleton.Config.DamageIndicatorHint.Replace("%damage", ev.Amount.ToString()).Replace("%player", ev.Target.Nickname), 6);
        }

        // The ability for human to cuff scps
        public void OnCuffingSCP(HandcuffingEventArgs ev)
        {
            if (ev.Target.Team == Team.SCP)
            {
                ev.IsAllowed = Plugin.Singleton.Config.SCPRoles.Contains(ev.Target.Role);
            }
        }
    }
}
