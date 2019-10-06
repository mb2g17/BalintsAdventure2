using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class GameState : Singleton<GameState>
    {
        /// <summary>
        /// Stores quantities for the spells
        /// -1 - Not discovered yet
        /// -2 - Infinite
        /// 0 or above - The actual quantity
        /// </summary>
        public readonly Dictionary<Spell, int> Quantities = new Dictionary<Spell, int>();

        private readonly Dictionary<(Spell, Spell), (Spell, Spell)> mappings = new Dictionary<(Spell, Spell), (Spell, Spell)>()
        {
            { (Spell.FIRE, Spell.WATER),    (Spell.STEAM, Spell.NOTHING) },
            { (Spell.FIRE, Spell.WIND),     (Spell.SMOKE, Spell.NOTHING) },
            { (Spell.FIRE, Spell.EARTH),    (Spell.LAVA, Spell.NOTHING) },
            { (Spell.FIRE, Spell.THUNDER),  (Spell.FIRE, Spell.NOTHING) },
            { (Spell.WATER, Spell.WIND),    (Spell.RAIN, Spell.NOTHING) },
            { (Spell.WATER, Spell.EARTH),   (Spell.ICE, Spell.NOTHING) },
            { (Spell.WATER, Spell.THUNDER), (Spell.DISCHARGE, Spell.NOTHING) },
            { (Spell.WIND, Spell.EARTH),    (Spell.STORM, Spell.NOTHING) },
            { (Spell.WIND, Spell.THUNDER),  (Spell.WIND, Spell.NOTHING) },
            { (Spell.EARTH, Spell.THUNDER), (Spell.EARTH, Spell.NOTHING) },

            { (Spell.STEAM, Spell.SMOKE),   (Spell.STEAM, Spell.SMOKE) },
            { (Spell.STEAM, Spell.LAVA),    (Spell.LAVA, Spell.NOTHING) },
            { (Spell.STEAM, Spell.RAIN),    (Spell.RAIN, Spell.NOTHING) },
            { (Spell.STEAM, Spell.ICE),     (Spell.WATER, Spell.NOTHING) },
            { (Spell.STEAM, Spell.DISCHARGE), (Spell.CHAINLIGHTNING, Spell.NOTHING) },
            { (Spell.STEAM, Spell.STORM), (Spell.STORM, Spell.NOTHING) },
            { (Spell.STEAM, Spell.FIRE), (Spell.STEAM, Spell.NOTHING) },
            { (Spell.STEAM, Spell.WATER), (Spell.WATER, Spell.NOTHING) },
            { (Spell.STEAM, Spell.WIND), (Spell.RAIN, Spell.NOTHING) },
            { (Spell.STEAM, Spell.EARTH), (Spell.EARTH, Spell.NOTHING) },
            { (Spell.STEAM, Spell.THUNDER), (Spell.THUNDER, Spell.NOTHING) },

            { (Spell.SMOKE, Spell.LAVA), (Spell.LAVA, Spell.NOTHING) },
            { (Spell.SMOKE, Spell.RAIN), (Spell.RAIN, Spell.NOTHING) },
            { (Spell.SMOKE, Spell.ICE), (Spell.WATER, Spell.NOTHING) },
            { (Spell.SMOKE, Spell.DISCHARGE), (Spell.SMOKE, Spell.NOTHING) },
            { (Spell.SMOKE, Spell.STORM), (Spell.STORM, Spell.NOTHING) },
            { (Spell.SMOKE, Spell.FIRE), (Spell.EXPLOSION, Spell.NOTHING) },
            { (Spell.SMOKE, Spell.WATER), (Spell.POISON, Spell.NOTHING) },
            { (Spell.SMOKE, Spell.WIND), (Spell.SMOKE, Spell.NOTHING) },
            { (Spell.SMOKE, Spell.EARTH), (Spell.FIRE, Spell.NOTHING) },
            { (Spell.SMOKE, Spell.THUNDER), (Spell.THUNDER, Spell.NOTHING) },

            { (Spell.LAVA, Spell.RAIN), (Spell.EARTH, Spell.NOTHING) },
            { (Spell.LAVA, Spell.ICE), (Spell.STEAM, Spell.LAVA) },
            { (Spell.LAVA, Spell.DISCHARGE), (Spell.LAVA, Spell.NOTHING) },
            { (Spell.LAVA, Spell.STORM), (Spell.EARTH, Spell.STORM) },
            { (Spell.LAVA, Spell.FIRE), (Spell.LAVA, Spell.NOTHING) },
            { (Spell.LAVA, Spell.WATER), (Spell.EARTH, Spell.SMOKE) },
            { (Spell.LAVA, Spell.WIND), (Spell.LAVA, Spell.NOTHING) },
            { (Spell.LAVA, Spell.EARTH), (Spell.LAVA, Spell.NOTHING) },
            { (Spell.LAVA, Spell.THUNDER), (Spell.EXPLOSION, Spell.NOTHING) },

            { (Spell.RAIN, Spell.ICE), (Spell.RAIN, Spell.NOTHING) },
            { (Spell.RAIN, Spell.DISCHARGE), (Spell.THUNDERSTORM, Spell.NOTHING) },
            { (Spell.RAIN, Spell.STORM), (Spell.STORM, Spell.NOTHING) },
            { (Spell.RAIN, Spell.FIRE), (Spell.STEAM, Spell.NOTHING) },
            { (Spell.RAIN, Spell.WATER), (Spell.RAIN, Spell.NOTHING) },
            { (Spell.RAIN, Spell.WIND), (Spell.STORM, Spell.NOTHING) },
            { (Spell.RAIN, Spell.EARTH), (Spell.EARTH, Spell.WATER) },
            { (Spell.RAIN, Spell.THUNDER), (Spell.STORM, Spell.NOTHING) },

            { (Spell.ICE, Spell.DISCHARGE), (Spell.ICE, Spell.NOTHING) },
            { (Spell.ICE, Spell.STORM), (Spell.BLIZZARD, Spell.NOTHING) },
            { (Spell.ICE, Spell.FIRE), (Spell.WATER, Spell.NOTHING) },
            { (Spell.ICE, Spell.WATER), (Spell.WATER, Spell.NOTHING) },
            { (Spell.ICE, Spell.WIND), (Spell.CONEOFCOLD, Spell.NOTHING) },
            { (Spell.ICE, Spell.EARTH), (Spell.ICE, Spell.NOTHING) },
            { (Spell.ICE, Spell.THUNDER), (Spell.ICE, Spell.NOTHING) },

            { (Spell.DISCHARGE, Spell.STORM), (Spell.STORM, Spell.NOTHING) },
            { (Spell.DISCHARGE, Spell.FIRE), (Spell.STEAM, Spell.NOTHING) },
            { (Spell.DISCHARGE, Spell.WATER), (Spell.DISCHARGE, Spell.NOTHING) },
            { (Spell.DISCHARGE, Spell.WIND), (Spell.CHAINLIGHTNING, Spell.NOTHING) },
            { (Spell.DISCHARGE, Spell.EARTH), (Spell.EARTH, Spell.NOTHING) },
            { (Spell.DISCHARGE, Spell.THUNDER), (Spell.DISCHARGE, Spell.NOTHING) },

            { (Spell.STORM, Spell.FIRE), (Spell.STORM, Spell.NOTHING) },
            { (Spell.STORM, Spell.WATER), (Spell.TSUNAMI, Spell.NOTHING) },
            { (Spell.STORM, Spell.WIND), (Spell.STORM, Spell.NOTHING) },
            { (Spell.STORM, Spell.EARTH), (Spell.STORM, Spell.EARTH) },
            { (Spell.STORM, Spell.THUNDER), (Spell.THUNDERSTORM, Spell.NOTHING) },
        };

        /// <summary>
        /// A list of learned mappings
        /// </summary>
        public readonly HashSet<(Spell, Spell)> LearnedMappings = new HashSet<(Spell, Spell)>();

        /// <summary>
        /// Current spell
        /// </summary>
        public Spell CurrentSpell = Spell.NOTHING;

        private void Start()
        {
            // Hide all spells
            foreach (Spell spell in Enum.GetValues(typeof(Spell)))
                Quantities[spell] = -1;

            // Show the beginner spell
            Quantities[Spell.NOTHING] = -2;
        }

        /// <summary>
        /// Crafts new spells and updates learned mappings
        /// </summary>
        /// <param name="spell1">The first spell to craft</param>
        /// <param name="spell2">How much of the first spell to craft</param>
        /// <param name="quantity1">The second spell to craft</param>
        /// <param name="quantity2">How much of the second spell to craft</param>
        /// <returns>The spells crafted and their quantities</returns>
        public (Spell spell1, int quantity1, Spell spell2, int quantity2) Craft(Spell spell1, Spell spell2, int quantity1, int quantity2)
        {
            // Add to learned mappings
            LearnedMappings.Add((spell1, spell2));

            // Gets the two spells from this
            Spell resultSpell1, resultSpell2;
            if (mappings.ContainsKey((spell1, spell2)))
                (resultSpell1, resultSpell2) = mappings[(spell1, spell2)];
            else
                (resultSpell1, resultSpell2) = mappings[(spell2, spell1)];

            // Gets the new quantity
            int newQuantity = (quantity1 + quantity2) / 3;

            // If there's two spells, split it in half
            if (resultSpell1 != Spell.NOTHING && resultSpell2 != Spell.NOTHING)
                newQuantity /= 2;

            // If we've ended up with 0, round to 1
            newQuantity = newQuantity == 0 ? 1 : newQuantity;

            // Returns new spells
            return (
                resultSpell1,
                newQuantity,
                resultSpell2,
                newQuantity
            );
        }
    }
}
