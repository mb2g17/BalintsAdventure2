using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomPropertyDrawer(typeof(IconDictionary))]
public class IconDictionaryDrawer : DictionaryDrawer<Spell, Sprite> { }

[Serializable]
public class IconDictionary : SerializableDictionary<Spell, Sprite> { }

public class SpellIconsScript : MonoBehaviour
{
    public IconDictionary SpellIcons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
