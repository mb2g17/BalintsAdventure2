using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuItems : MonoBehaviour
{
    [MenuItem("Bálint's Adventure/Unlock all spells")]
    static void UnlockAllSpells()
    {
        foreach (Spell spell in Enum.GetValues(typeof(Spell)))
            GameState.Instance.Quantities[spell] = 100;
        GameState.Instance.Quantities[Spell.NOTHING] = -2;
    }

    [MenuItem("Bálint's Adventure/Unlock tier 1 spells")]
    static void UnlockTier1()
    {
        foreach (Spell spell in Enum.GetValues(typeof(Spell)))
        {
            if ((int)spell >= 1 && (int)spell <= 5)
                GameState.Instance.Quantities[spell] = 100;
        }
    }

    [MenuItem("Bálint's Adventure/Unlock tier 2 spells")]
    static void UnlockTier2()
    {
        foreach (Spell spell in Enum.GetValues(typeof(Spell)))
        {
            if ((int)spell >= 6 && (int)spell <= 12)
                GameState.Instance.Quantities[spell] = 100;
        }
    }

    [MenuItem("Bálint's Adventure/Unlock tier 3 spells")]
    static void UnlockTier3()
    {
        foreach (Spell spell in Enum.GetValues(typeof(Spell)))
        {
            if ((int)spell >= 13)
                GameState.Instance.Quantities[spell] = 100;
        }
    }

    [MenuItem("Bálint's Adventure/Learn all mappings")]
    static void LearnAllMappings()
    {
        foreach ((Spell, Spell) spellPair in GameState.Instance.Mappings.Keys)
            GameState.Instance.LearnedMappings.Add(spellPair);
    }
}
