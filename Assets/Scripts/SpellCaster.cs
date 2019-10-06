using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public GameObject NothingPrefab;

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

        switch (GameState.Instance.CurrentSpell)
        {
            case Spell.NOTHING:
                GameObject attack = Instantiate(NothingPrefab);
                attack.transform.position = mousePos;
                break;
        }
    }
}
