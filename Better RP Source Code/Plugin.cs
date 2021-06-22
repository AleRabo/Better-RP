
using Exiled.API.Features;
using PlayerHandlers = Exiled.Events.Handlers.Player;
using ServerHandlers = Exiled.Events.Handlers.Server;

namespace BetterRP
{
    public class Plugin : Plugin<Config>
    {

        // The singleton of the plugin
        public static Plugin Singleton;


        public override string Prefix => "BetterRP";


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
            PlayerHandlers.InteractingElevator += EventHandlers.OnBrokingElevator;
            PlayerHandlers.InteractingDoor += EventHandlers.OnInteractingBlockedDoor;
            PlayerHandlers.ActivatingWarheadPanel += EventHandlers.OnActivatingWarheadPanel;
            PlayerHandlers.MedicalItemUsed += EventHandlers.OnPlayerHeal;
            PlayerHandlers.Handcuffing += EventHandlers.OnCuffingSCP;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerHandlers.RoundStarted -= EventHandlers.ScpBreakContainmentAnnouncement;
            PlayerHandlers.TriggeringTesla -= EventHandlers.OnTriggeringTesla;
            PlayerHandlers.Hurting -= EventHandlers.OnHurting;
            PlayerHandlers.InteractingElevator -= EventHandlers.OnBrokingElevator;
            PlayerHandlers.InteractingDoor -= EventHandlers.OnInteractingBlockedDoor;
            PlayerHandlers.ActivatingWarheadPanel -= EventHandlers.OnActivatingWarheadPanel;
            PlayerHandlers.MedicalItemUsed -= EventHandlers.OnPlayerHeal;
            PlayerHandlers.Handcuffing -= EventHandlers.OnCuffingSCP;
            EventHandlers = null;
            Singleton = null;
            base.OnDisabled();
        }
    }
}
