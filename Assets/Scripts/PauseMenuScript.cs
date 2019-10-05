using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public UISlotScript Slot1Image, Slot2Image;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearSlot1()
    {
        Slot1Image.Spell = Spell.NOTHING;
    }

    public void ClearSlot2()
    {
        Slot2Image.Spell = Spell.NOTHING;
    }
    
    public void SpellClick(string spellName)
    {
        Spell spell = (Spell) Enum.Parse(typeof(Spell), spellName);

        if (Slot1Image.IconImage.color.a == 0)
            Slot1Image.Spell = spell;
        else
            Slot2Image.Spell = spell;
    }
}
