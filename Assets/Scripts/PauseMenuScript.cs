using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    // -- UI --
    public UISlotScript Slot1, Slot2;

    [Serializable]
    public class InventorySlot
    {
        public Spell spell;
        public UISlotScript slot;
    }
    public List<InventorySlot> InventorySlots;

    public Toggle SelectModeToggle, CraftModeToggle;

    public TextMeshProUGUI UnlockedText;

    // -- MODEL --
    [HideInInspector]
    public Spell Slot1Spell, Slot2Spell;

    [HideInInspector]
    public int Slot1Quantity, Slot2Quantity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Crafting UI
        Slot1.Spell = Slot1Spell;
        Slot1.Quantity = Slot1Quantity;
        Slot2.Spell = Slot2Spell;
        Slot2.Quantity = Slot2Quantity;
        
        // Fill out inventory
        foreach (Spell spell in Enum.GetValues(typeof(Spell)))
        {
            // Except for nothing and everything
            if (spell != Spell.NOTHING && spell != Spell.EVERYTHING)
            {
                // Get inventory quantity
                int quantity = GameState.Instance.Quantities[spell];

                // Fills in slot
                UISlotScript slot = GetSlot(spell);
                if (slot != null)
                    slot.Quantity = quantity;
            }
        }

        // Fills out combinations we've unlocked
        UnlockedText.text = "";
        foreach ((Spell, Spell) spellPair in GameState.Instance.Mappings.Keys)
        {
            if (GameState.Instance.LearnedMappings.Contains(spellPair))
            {
                (Spell, Spell) resultSpellPair = GameState.Instance.Mappings[spellPair];
                UnlockedText.text +=
                    spellPair.Item1.ToString() +
                    " + " +
                    spellPair.Item2.ToString() +
                    " -> " +
                    resultSpellPair.Item1.ToString() +
                        (resultSpellPair.Item2 != Spell.NOTHING ?
                         " + " + resultSpellPair.Item2.ToString() :
                         "") +
                    "\n";
            }
            else
                UnlockedText.text += "???\n";
        }
    }

    public void ClearSlot1()
    {
        // Updates inventory
        GameState.Instance.Quantities[Slot1Spell] += Slot1Quantity;

        // Updates crafting ui model
        Slot1Spell = Spell.NOTHING;
        Slot1Quantity = 0;
    }

    public void ClearSlot2()
    {
        // Updates inventory
        GameState.Instance.Quantities[Slot2Spell] += Slot2Quantity;

        // Updates crafting ui model
        Slot2Spell = Spell.NOTHING;
        Slot2Quantity = 0;
    }

    /// <summary>
    /// Gets a UI slot from a spell
    /// </summary>
    /// <param name="spell">The spell to look for</param>
    /// <returns>The slot for that spell</returns>
    public UISlotScript GetSlot(Spell spell)
    {
        for (int i = 0; i < InventorySlots.Count; i++)
        {
            if (InventorySlots[i].spell == spell)
                return InventorySlots[i].slot;
        }
        return null;
    }
    
    public void SpellClick(string spellName)
    {
        // Gets the spell
        Spell spell = (Spell) Enum.Parse(typeof(Spell), spellName);

        // If we don't even know what this spell is, do nothing
        if (GameState.Instance.Quantities[spell] == -1)
            return;

        // If we're crafting
        if (CraftModeToggle.isOn)
        {
            // If this is a tier 3 spell, do nothing
            if ((int)spell >= 13)
                return;

            // Deduct 1 from inventory
            GameState.Instance.Quantities[spell]--;

            // Increment if it's already in there
            if (Slot1Spell == spell)
                Slot1Quantity++;
            else if (Slot2Spell == spell)
                Slot2Quantity++;
            else
            {
                // Update craft model
                if (Slot1Spell == Spell.NOTHING)
                {
                    Slot1Spell = spell;
                    Slot1Quantity = 1;
                }
                else if (Slot2Spell == Spell.NOTHING)
                {
                    Slot2Spell = spell;
                    Slot2Quantity = 1;
                }
                else
                {
                    // Increment 1 from inventory (turns out we didn't move anything after all)
                    GameState.Instance.Quantities[spell]++;
                }
            }
        }
        else
        {
            // Set this to equipped
            GameState.Instance.CurrentSpell = spell;
        }
    }

    public void Craft()
    {
        // If either of the spells are nothing, do not craft
        if (Slot1Spell == Spell.NOTHING || Slot2Spell == Spell.NOTHING)
            return;

        // Crafts
        (Spell resultSpell1,
         int resultQuantity1,
         Spell resultSpell2,
         int resultQuantity2) = GameState.Instance.Craft(Slot1Spell, Slot2Spell, Slot1Quantity, Slot2Quantity);

        // If the quantities are -1 (newly discovered), set them to zero before adding
        if (GameState.Instance.Quantities[resultSpell1] == -1)
            GameState.Instance.Quantities[resultSpell1] = 0;
        if (GameState.Instance.Quantities[resultSpell2] == -1)
            GameState.Instance.Quantities[resultSpell2] = 0;

        // Updates inventory
        GameState.Instance.Quantities[resultSpell1] += resultQuantity1;
        GameState.Instance.Quantities[resultSpell2] += resultQuantity2;

        // Clears model
        Slot1Spell = Spell.NOTHING;
        Slot1Quantity = 0;
        Slot2Spell = Spell.NOTHING;
        Slot2Quantity = 0;
    }

    /// <summary>
    /// Unequips spell, leaving nothing
    /// </summary>
    public void Unequip()
    {
        GameState.Instance.CurrentSpell = Spell.NOTHING;
    }
}
