using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public GameObject
        NothingPrefab,
        FirePrefab,
        WaterPrefab,
        WindPrefab,
        EarthPrefab,
        ThunderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CastSpell()
    {
        // Gets mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -5;

        // If we have enough
        if (GameState.Instance.Quantities[GameState.Instance.CurrentSpell] > 0 ||
            GameState.Instance.Quantities[GameState.Instance.CurrentSpell] == -2)
        {
            switch (GameState.Instance.CurrentSpell)
            {
                case Spell.NOTHING:
                    GameObject attack = Instantiate(NothingPrefab);
                    attack.transform.position = mousePos;
                    break;
                case Spell.FIRE:
                    attack = Instantiate(FirePrefab);
                    attack.transform.position = mousePos;
                    break;
                case Spell.WATER:
                    attack = Instantiate(WaterPrefab);
                    attack.transform.position = mousePos;
                    break;
                case Spell.WIND:
                    attack = Instantiate(WindPrefab);
                    attack.transform.position = mousePos;
                    break;
                case Spell.EARTH:
                    attack = Instantiate(EarthPrefab);
                    attack.transform.position = mousePos;
                    break;
                case Spell.THUNDER:
                    attack = Instantiate(ThunderPrefab);
                    attack.transform.position = mousePos;
                    break;
            }

            // If we don't have infinite, deduct one
            if (GameState.Instance.Quantities[GameState.Instance.CurrentSpell] != -2)
                GameState.Instance.Quantities[GameState.Instance.CurrentSpell]--;
        }
    }
}
