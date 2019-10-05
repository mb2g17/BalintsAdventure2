using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlotScript : MonoBehaviour
{
    public Spell Spell;
    public int Quantity;

    public Image IconImage;
    public TextMeshProUGUI QuantityText;

    private SpellIconsScript spellIcons;

    // Start is called before the first frame update
    void Start()
    {
        spellIcons = FindObjectOfType<SpellIconsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Spell != Spell.NOTHING)
            FillImage(spellIcons.SpellIcons[Spell]);
        else
            EmptyImage();

        if (Quantity == -2)
            QuantityText.text = "∞";
        else
            QuantityText.text = "" + Quantity;
    }

    private void EmptyImage()
    {
        IconImage.color = new Color(1, 1, 1, 0);
    }

    private void FillImage(Sprite sprite)
    {
        IconImage.sprite = sprite;
        IconImage.color = new Color(1, 1, 1, 1);
    }
}
