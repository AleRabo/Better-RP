namespace BetterRP
{
    using BetterRP.EventHandlers;
    using System;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using PlayerHandlers = Exiled.Events.Handlers.Player;
    using ServerHandlers = Exiled.Events.Handlers.Server;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private static readonly Plugin InstanceValue = new Plugin();

        private Plugin()
        {
        }

        /// <summary>
        /// Gets an instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; } = InstanceValue;

        /// <inheritdoc />
        public override string Prefix { get; } = "BetterRP";

        /// <summary>
        /// Gets an instance of the <see cref="EventHandlers.PlayerEvents"/> class.
        /// </summary>
        public PlayerEvents PlayerEvents { get; private set; }

        /// <summary>
        /// Gets an instance of the <see cref="EventHandlers.ServerEvents"/> class.
        /// </summary>
        public ServerEvents ServerEvents { get; private set; }

        /// <inheritdoc />
        public override void OnEnabled()
        {
            ServerEvents = new ServerEvents();
            PlayerEvents = new PlayerEvents();

            ServerHandlers.RoundStarted += ServerEvents.OnRoundStarted;

            PlayerHandlers.TriggeringTesla += PlayerEvents.OnTriggeringTesla;
            PlayerHandlers.Hurting += PlayerEvents.OnHurting;
            PlayerHandlers.InteractingElevator += PlayerEvents.OnBrokingElevator;
            PlayerHandlers.InteractingDoor += PlayerEvents.OnInteractingBlockedDoor;
            PlayerHandlers.ActivatingWarheadPanel += PlayerEvents.OnActivatingWarheadPanel;
            PlayerHandlers.MedicalItemUsed += PlayerEvents.OnPlayerHeal;
            PlayerHandlers.Handcuffing += PlayerEvents.OnCuffingSCP;

            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {

            ServerHandlers.RoundStarted -= ServerEvents.OnRoundStarted;

            PlayerHandlers.TriggeringTesla -= PlayerEvents.OnTriggeringTesla;
            PlayerHandlers.Hurting -= PlayerEvents.OnHurting;
            PlayerHandlers.InteractingElevator -= PlayerEvents.OnBrokingElevator;
            PlayerHandlers.InteractingDoor -= PlayerEvents.OnInteractingBlockedDoor;
            PlayerHandlers.ActivatingWarheadPanel -= PlayerEvents.OnActivatingWarheadPanel;
            PlayerHandlers.MedicalItemUsed -= PlayerEvents.OnPlayerHeal;
            PlayerHandlers.Handcuffing -= PlayerEvents.OnCuffingSCP;

            PlayerEvents = null;
            ServerEvents = null;
        }
    }
}
