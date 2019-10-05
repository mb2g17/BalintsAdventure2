using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomPropertyDrawer(typeof(IconDictionary))]
public class IconDictionaryDrawer : DictionaryDrawer<Spell, Sprite> { }

[Serializable]
public class IconDictionary : SerializableDictionary<Spell, Sprite> { }

public class PauseMenuScript : MonoBehaviour
{
    public Image Slot1Image, Slot2Image;

    public IconDictionary SpellIcons;

    // Start is called before the first frame update
    void Start()
    {
        EmptyImage(Slot1Image);
        EmptyImage(Slot2Image);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearSlot1()
    {
        EmptyImage(Slot1Image);
    }

    public void ClearSlot2()
    {
        EmptyImage(Slot2Image);
    }
    
    public void SpellClick(string spellName)
    {
        Spell spell = (Spell) Enum.Parse(typeof(Spell), spellName);

        if (Slot1Image.color.a == 0)
            FillImage(Slot1Image, SpellIcons[spell]);
        else
            FillImage(Slot2Image, SpellIcons[spell]);
    }

    private void EmptyImage(Image image)
    {
        image.color = new Color(1, 1, 1, 0);
    }

    private void FillImage(Image image, Sprite sprite)
    {
        image.sprite = sprite;
        image.color = new Color(1, 1, 1, 1);
    }
}
