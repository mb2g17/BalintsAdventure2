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

            // -- DEBUG --
            foreach (Spell spell in Enum.GetValues(typeof(Spell)))
                Quantities[spell] = 100;
            // -----------
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
