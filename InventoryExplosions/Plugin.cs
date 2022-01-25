// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace InventoryExplosions
{
    using System;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using PlayerHandlers = Exiled.Events.Handlers.Player;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc />
        public override string Author { get; } = "Build";

        /// <inheritdoc />
        public override PluginPriority Priority { get; } = PluginPriority.Lower;

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(4, 2, 3);

        /// <inheritdoc />
        public override Version Version { get; } = new Version(1, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            PlayerHandlers.Dying += eventHandlers.OnDying;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            PlayerHandlers.Dying -= eventHandlers.OnDying;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}