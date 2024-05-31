using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ColorModifier
{
    public int id;
    public Color color;
}

public class CardTemplate : MonoBehaviour
{
    public PlayingCard_Struct card;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer rendererModifier;


    public static ColorModifier[] modifiers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        InfosManager.Instance.OpenInfos(card);
    }

    public void SetCard(PlayingCard_Struct card)
    {
        this.card = card;
        spriteRenderer.sprite = card.texture;

        rendererModifier.color = card.color;

    }
}
