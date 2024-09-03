using Exiled.API.Features;
using System;
using PlayerHandlers = Exiled.Events.Handlers.Player;
using ServerHandlers = Exiled.Events.Handlers.Server;

namespace BetterRP
{
    public class BetterRP : Plugin<Config, Translation>
    {

        public static BetterRP Singleton;

        // Plugin properties
        public override string Name => "BetterRP";
        public override string Prefix => "BetterRP";
        public override string Author => "AleRabo";
        public override Version Version => new Version(2, 0, 2);
        public override Version RequiredExiledVersion => new Version(8, 11, 0);

        /// <summary>
        /// The event handlers <see cref="BetterRP.EventHandlers"/> class.
        /// </summary>
        private EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            Singleton = this;
            EventHandlers = new EventHandlers();


            ServerHandlers.RoundStarted += EventHandlers.ScpBreakContainmentAnnouncement;


            PlayerHandlers.TriggeringTesla += EventHandlers.OnTriggeringTesla;
            PlayerHandlers.Hurting += EventHandlers.OnHurting;
            PlayerHandlers.InteractingDoor += EventHandlers.OnInteractingBlockedDoor;
            PlayerHandlers.ActivatingWarheadPanel += EventHandlers.OnActivatingWarheadPanel;
            PlayerHandlers.UsedItem += EventHandlers.OnPlayerHeal;
            PlayerHandlers.DroppingItem += EventHandlers.OnThrowing;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerHandlers.RoundStarted -= EventHandlers.ScpBreakContainmentAnnouncement;

            PlayerHandlers.TriggeringTesla -= EventHandlers.OnTriggeringTesla;
            PlayerHandlers.Hurting -= EventHandlers.OnHurting;
            PlayerHandlers.InteractingDoor -= EventHandlers.OnInteractingBlockedDoor;
            PlayerHandlers.ActivatingWarheadPanel -= EventHandlers.OnActivatingWarheadPanel;
            PlayerHandlers.UsedItem -= EventHandlers.OnPlayerHeal;
            PlayerHandlers.DroppingItem -= EventHandlers.OnThrowing;

            EventHandlers = null;

            Singleton = null;
            base.OnDisabled();
        }
    }
}
