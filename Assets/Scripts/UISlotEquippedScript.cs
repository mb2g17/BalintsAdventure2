using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UISlotScript))]
public class UISlotEquippedScript : MonoBehaviour
{
    private UISlotScript uiSlot;

    // Start is called before the first frame update
    void Start()
    {
        uiSlot = GetComponent<UISlotScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Updates ui
        uiSlot.Spell = GameState.Instance.CurrentSpell;
        uiSlot.Quantity = GameState.Instance.Quantities[GameState.Instance.CurrentSpell];
    }
}
