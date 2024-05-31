using System;
using UnityEngine;

public enum SUIT { DIAMOND, CLUB, HEART, SPADE }

[Serializable]
public struct PlayingCard_Struct
{
    public int id;
    public int value;
    public int altValue;
    public int rank;
    public Sprite texture;
    public SUIT suit;
    public string hint;
    public Color color;
}


[CreateAssetMenu(fileName = "Cards", menuName = "ScriptableObjects/Card", order = 1)]
public class PlayingCard : ScriptableObject
{
    public int id;
    public int value;
    public int altValue;
    public int rank;
    public Sprite texture;
    public SUIT suit;
    public string hint;
    public Color color;

    public PlayingCard_Struct get_struct()
    {
        PlayingCard_Struct card = new PlayingCard_Struct();
        card.id = id;
        card.value = value;
        card.altValue = altValue;
        card.rank = rank;
        card.texture = texture;
        card.suit = suit;
        card.hint = hint;
        card.color = color;

        return card;
    }
}
