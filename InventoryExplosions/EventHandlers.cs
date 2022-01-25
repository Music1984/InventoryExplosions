// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace InventoryExplosions
{
    using Exiled.API.Features.Items;
    using Exiled.Events.EventArgs;
    using Exiled.Loader;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnDying(DyingEventArgs)"/>
        public void OnDying(DyingEventArgs ev)
        {
            if (!ev.IsAllowed)
                return;

            foreach (Item item in ev.ItemsToDrop)
            {
                if (!(item is ExplosiveGrenade explosiveGrenade))
                    continue;

                if (Loader.Random.Next(100) < plugin.Config.ExplosionPercentage)
                {
                    ev.Target.RemoveItem(item);
                    explosiveGrenade.SpawnActive(ev.Target.Position, ev.Target);
                }

                if (plugin.Config.FirstGrenadeOnly)
                    break;
            }
        }
    }
}