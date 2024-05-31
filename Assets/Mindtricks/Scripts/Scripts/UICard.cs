using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum CLICK_EVENT
{
    ADD_TO_DECK,
    REMOVE_FROM_DECK
}

public class UICard : MonoBehaviour
{
    public PlayingCard_Struct card;
    public CLICK_EVENT clickEvent;
    public int n;
    public CardUIManager manager;

    public Image cardImage;
    public Image overlay;

    public TMP_Text tmpText;
    public void SetCard(PlayingCard_Struct new_card)
    {
        card = new_card;
        cardImage.sprite = new_card.texture;
        overlay.color = new_card.color;
        tmpText.text = new_card.hint;
        //TO DO : Setta qui la grafica
    }

    public void SetCardPosition(int number, PlayingCard_Struct graphic)
    {
        n = number;
        cardImage.sprite = graphic.texture;
        overlay.color = graphic.color;
        tmpText.text = graphic.hint;
    }

    public void Click_Event()
    {
        switch(clickEvent)
        {
            case CLICK_EVENT.ADD_TO_DECK:
                GameManager.Instance.AddCard(card);
                break;
            case CLICK_EVENT.REMOVE_FROM_DECK:
                GameManager.Instance.RemoveCard(n);
                break;
        }

        manager.ClosePanel();
    }

}
