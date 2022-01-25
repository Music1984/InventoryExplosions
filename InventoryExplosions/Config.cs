// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace InventoryExplosions
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;
    using UnityEngine;

    /// <inheritdoc />
    public sealed class Config : IConfig
    {
        private float explosionPercentage = 20f;

        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the chance that a grenade will explode instead of being dropped when a player is killed.
        /// </summary>
        [Description("The chance that a grenade will explode instead of being dropped when a player is killed.")]
        public float ExplosionPercentage
        {
            get => explosionPercentage;
            set => explosionPercentage = Mathf.Clamp(value, 0, 100);
        }

        /// <summary>
        /// Gets or sets a value indicating whether only the first grenade in a player's inventory will have a chance to explode.
        /// </summary>
        [Description("Indicates whether only the first grenade in a player's inventory will have a chance to explode.")]
        public bool FirstGrenadeOnly { get; set; } = true;
    }
}