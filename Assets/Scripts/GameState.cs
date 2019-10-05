using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
