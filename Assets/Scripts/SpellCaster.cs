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
        ThunderPrefab,
        SteamPrefab,
        SmokePrefab,
        LavaPrefab,
        RainPrefab,
        IcePrefab,
        StormPrefab,
        ChainLightningPrefab,
        ExplosionPrefab,
        PoisonPrefab,
        BlizzardPrefab,
        TsunamiPrefab;

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
        mousePos.z = 0;

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
                case Spell.STEAM:
                    Instantiate(SteamPrefab).transform.position = mousePos + new Vector3(1, 1, 0);
                    Instantiate(SteamPrefab).transform.position = mousePos + new Vector3(-1, 1, 0);
                    Instantiate(SteamPrefab).transform.position = mousePos + new Vector3(1, -1, 0);
                    Instantiate(SteamPrefab).transform.position = mousePos + new Vector3(-1, -1, 0);
                    break;
                case Spell.SMOKE:
                    Instantiate(SmokePrefab).transform.position = mousePos + new Vector3(1, 1, 0);
                    Instantiate(SmokePrefab).transform.position = mousePos + new Vector3(-1, 1, 0);
                    Instantiate(SmokePrefab).transform.position = mousePos + new Vector3(1, -1, 0);
                    Instantiate(SmokePrefab).transform.position = mousePos + new Vector3(-1, -1, 0);
                    break;
                case Spell.LAVA:
                    Instantiate(LavaPrefab).transform.position = mousePos + new Vector3(1, 1, 0);
                    Instantiate(LavaPrefab).transform.position = mousePos + new Vector3(-1, 1, 0);
                    Instantiate(LavaPrefab).transform.position = mousePos + new Vector3(1, -1, 0);
                    Instantiate(LavaPrefab).transform.position = mousePos + new Vector3(-1, -1, 0);
                    break;
                case Spell.RAIN:
                    for (int j = -1; j <= 1; j++)
                        for (int i = -10; i < 10; i++)
                            Instantiate(RainPrefab).transform.position = mousePos + new Vector3(j * 2, i * 2, 0);
                    break;
                case Spell.ICE:
                    Instantiate(IcePrefab).transform.position = mousePos;
                    break;
                case Spell.DISCHARGE:
                    int distance = 2;
                    Instantiate(ThunderPrefab).transform.position = mousePos;
                    Instantiate(WaterPrefab).transform.position = mousePos + new Vector3(distance, distance, 0);
                    Instantiate(WaterPrefab).transform.position = mousePos + new Vector3(-distance, distance, 0);
                    Instantiate(WaterPrefab).transform.position = mousePos + new Vector3(distance, -distance, 0);
                    Instantiate(WaterPrefab).transform.position = mousePos + new Vector3(-distance, -distance, 0);

                    Instantiate(WaterPrefab).transform.position = mousePos + new Vector3(0, -distance, 0);
                    Instantiate(WaterPrefab).transform.position = mousePos + new Vector3(0, distance, 0);
                    Instantiate(WaterPrefab).transform.position = mousePos + new Vector3(-distance, 0, 0);
                    Instantiate(WaterPrefab).transform.position = mousePos + new Vector3(distance, 0, 0);
                    break;
                case Spell.STORM:
                    for (int j = -1; j <= 1; j++)
                        for (int i = -10; i < 10; i++)
                            Instantiate(StormPrefab).transform.position = mousePos + new Vector3(j * 2, i * 2, 0);
                    break;
                case Spell.CHAINLIGHTNING:
                    for (int i = 0; i < 40; i++)
                        Instantiate(ChainLightningPrefab).transform.position = mousePos + new Vector3(
                            Random.Range(-10, 10), Random.Range(-10, 10), 0);
                    break;
                case Spell.EXPLOSION:
                    for (int i = 0; i < 3; i++)
                        Instantiate(ExplosionPrefab).transform.position = mousePos;
                    break;
                case Spell.POISON:
                    Instantiate(PoisonPrefab).transform.position = mousePos;
                    break;
                case Spell.THUNDERSTORM:
                    for (int j = -1; j <= 1; j++)
                        for (int i = -10; i < 10; i++)
                            Instantiate(ChainLightningPrefab).transform.position = mousePos + new Vector3(j * 2, i * 2, 0);
                    break;
                case Spell.BLIZZARD:
                    for (int j = -1; j <= 1; j++)
                        for (int i = -10; i < 10; i++)
                            Instantiate(BlizzardPrefab).transform.position = mousePos + new Vector3(j * 2, i * 2, 0);
                    break;
                case Spell.CONEOFCOLD:
                    for (int i = -60; i < 60; i++)
                        Instantiate(BlizzardPrefab).transform.position = mousePos + new Vector3(i / 4, 0, 0);
                    break;
                case Spell.TSUNAMI:
                    for (int i = -60; i < 60; i++)
                        Instantiate(TsunamiPrefab).transform.position = mousePos + new Vector3(0, i / 4, 0);
                    break;
            }

            // If we don't have infinite, deduct one
            if (GameState.Instance.Quantities[GameState.Instance.CurrentSpell] != -2)
                GameState.Instance.Quantities[GameState.Instance.CurrentSpell]--;
        }
    }
}
