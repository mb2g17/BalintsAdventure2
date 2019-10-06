using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuItems : MonoBehaviour
{
    [MenuItem("Bálint's Adventure/Unlock all spells")]
    static void DoSomething()
    {
        foreach (Spell spell in Enum.GetValues(typeof(Spell)))
            GameState.Instance.Quantities[spell] = 100;
        GameState.Instance.Quantities[Spell.NOTHING] = -2;
    }
}
