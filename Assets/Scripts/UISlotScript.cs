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

    public Sprite UnknownSpellSprite;

    private SpellIconsScript spellIcons;

    // Start is called before the first frame update
    void Start()
    {
        spellIcons = FindObjectOfType<SpellIconsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Quantity == -1) // If the spell is unknown, hide it
            FillImage(UnknownSpellSprite);
        else if (Spell != Spell.NOTHING) // If the spell isn't just nothing, show its sprite
            FillImage(spellIcons.SpellIcons[Spell]);
        else // It's nothing; show nothing
            EmptyImage();

        // If we've actually discovered this spell
        if (Quantity != -1)
        {
            if (Quantity == -2)
                QuantityText.text = "∞";
            else
                QuantityText.text = "" + Quantity;
        }
        else
        {
            QuantityText.text = "";
        }
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
