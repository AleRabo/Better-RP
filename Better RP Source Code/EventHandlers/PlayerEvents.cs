namespace BetterRP.EventHandlers
{
    using System;
    using System.Collections.Generic;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using Respawning;
    using Hints;
    using CustomPlayerEffects;
    using MEC;
    using UnityEngine;
    using Exiled.API.Extensions;
    using Exiled.Bootstrap;
    using Exiled.Events.Extensions;
    using UnityEditor;
    using UnityEngineInternal;
    using UnityStandardAssets;
    

    public class PlayerEvents
    {
        public static void OnBrokingElevator(InteractingElevatorEventArgs ev)
        {
            if (new System.Random().Next(0, 101) <= Plugin.Instance.Config.ElevatorBrokenChance)
            {
                if (Plugin.Instance.Config.ElevatorBrokeAfflictScps)
                {
                    if (ev.Player.Team == Team.SCP)
                    {
                        ev.Player.Hurt(400, DamageTypes.Falldown);
                        ev.Player.Broadcast(6, Plugin.Instance.Config.broken_elevator);
                    }

                    if (ev.Player.IsHuman)
                    {
                        ev.Player.Kill(DamageTypes.Falldown);
                        ev.Player.Broadcast(6, Plugin.Instance.Config.broken_elevator);
                    }
                }
            }
        }


    public static void OnInteractingBlockedDoor(InteractingDoorEventArgs ev)
        {
            if (ev.IsAllowed == false)
            {
                ev.Player.ShowHint(Plugin.Instance.Config.InteractingBlockedDoor, 6);
            }
        }

        public static void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (Plugin.Instance.Config.TeslagateBypassWithTablet)
            {
                if (ev.Player.HasItem(ItemType.WeaponManagerTablet))
                {

                    ev.IsTriggerable = false;
                    ev.Player.ShowHint(Plugin.Instance.Config.TeslaGatebypasstHint, 3);
                }
            }
        }

        public static void OnActivatingWarheadPanel(ActivatingWarheadPanelEventArgs ev)
        {
            ev.Player.ShowHint(Plugin.Instance.Config.ActivatingWarheadPanel, 6);
        }

        public static void OnPlayerHeal(UsedMedicalItemEventArgs ev)
        {
            ev.Player.ShowHint(Plugin.Instance.Config.PlayerHealHint, 6);
        }


        public void OnHurting(HurtingEventArgs ev)
        {

            if (Plugin.Instance.Config.DamageIndicatorIsEnabled == false)
            {
                return;
            }

            if (ev.IsAllowed == false)
            {
                return;
            }


            if (ev.Target == null)
            {
                return;
            }

            if (ev.Target.IsDead || ev.Target.IsInvisible || ev.Amount < 0)
            {
                return;
            }

            if (ev.Target == ev.Attacker)
            {
                return;
            }

            ev.Attacker.ShowHint(Plugin.Instance.Config.DamageIndicatorHint.Replace("%damage", ev.Amount.ToString()).Replace("%player", ev.Target.Nickname), 6);
        }
        public static void OnCuffingSCP(HandcuffingEventArgs ev)
        {
            if (Plugin.Instance.Config.HumanCanCuffSCPS == true)
            {
                if (ev.Cuffer.IsHuman && ev.Target.Team == Team.SCP && true)
                {
                    if (ev.Target.Role == RoleType.Scp93989)
                    {
                        ev.IsAllowed = Plugin.Instance.Config.Scps939;
                    }

                    if (ev.Target.Role == RoleType.Scp93953)
                    {
                        ev.IsAllowed = Plugin.Instance.Config.Scps939;
                    }

                    if (ev.Target.Role == RoleType.Scp173)
                    {
                        ev.IsAllowed = Plugin.Instance.Config.Scp173;
                    }

                    if (ev.Target.Role == RoleType.Scp049)
                    {
                        ev.IsAllowed = Plugin.Instance.Config.Scp049;
                    }

                    if (ev.Target.Role == RoleType.Scp0492)
                    {
                        ev.IsAllowed = Plugin.Instance.Config.Scp0492;
                    }

                    if (ev.Target.Role == RoleType.Scp096)
                    {
                        ev.IsAllowed = Plugin.Instance.Config.Scp096;
                    }

                    ev.IsAllowed = true;


                }

            }



        }

          
    }
}


