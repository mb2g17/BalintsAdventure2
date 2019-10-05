using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
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
            // Get inventory quantity
            int quantity = GameState.Instance.Quantities[spell];

            // Fills in slot
            UISlotScript slot = GetSlot(spell);
            if (slot != null)
                slot.Quantity = quantity;
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
        Spell spell = (Spell) Enum.Parse(typeof(Spell), spellName);

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
}
