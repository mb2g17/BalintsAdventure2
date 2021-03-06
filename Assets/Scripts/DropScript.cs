﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour
{
    public Spell ThisSpell;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BalintScript>() != null)
        {
            if (GameState.Instance.Quantities[ThisSpell] == -1)
                GameState.Instance.Quantities[ThisSpell] = 0;

            GameState.Instance.Quantities[ThisSpell]++;

            Destroy(transform.parent.gameObject);
        }
    }
}
