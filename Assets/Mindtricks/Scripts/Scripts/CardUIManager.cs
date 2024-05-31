using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardUIManager : MonoBehaviour
{
    public GameObject cardSelectorObject;
    public GameObject cardSelectorParent;
    public TMP_Text tip;

    public GameObject cardUIPrefab;
    public GameObject cardUIPrefabDeck;
    public GameObject buttonCloseDeck;

    public HandAndDeckManager hadM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInsertCardSelector(List<PlayingCard_Struct> cards)
    {
        while (cardSelectorParent.transform.childCount > 0)
        {
            DestroyImmediate(cardSelectorParent.transform.GetChild(0).gameObject);
        }

        cardSelectorObject.SetActive(true);
        for(int i = 0; i < cards.Count; i++)
        {
            GameObject cardUI = Instantiate(cardUIPrefab, cardSelectorParent.transform);
            UICard uiCard = cardUI.GetComponent<UICard>();
            uiCard.manager = this;
            uiCard.SetCard(cards[i]);
            uiCard.clickEvent = CLICK_EVENT.ADD_TO_DECK;
        }
        buttonCloseDeck.SetActive(false);
        tip.text = "Choose a new card for your deck";
    }
    public void OpenRemoveCardSelector(int[] cards, List<PlayingCard_Struct> deck)
    {
        while (cardSelectorParent.transform.childCount > 0)
        {
            DestroyImmediate(cardSelectorParent.transform.GetChild(0).gameObject);
        }
        cardSelectorObject.SetActive(true);
        for(int i = 0; i < cards.Length; i++)
        {
            GameObject cardUI = Instantiate(cardUIPrefab, cardSelectorParent.transform);
            UICard uiCard = cardUI.GetComponent<UICard>();
            uiCard.manager = this;
            uiCard.SetCardPosition(cards[i], deck[cards[i]]);
            uiCard.clickEvent = CLICK_EVENT.REMOVE_FROM_DECK;
        }
        buttonCloseDeck.SetActive(false);

        tip.text = "Remove a card from your deck";

    }

    public void OpenDeckViewer()
    {
        while (cardSelectorParent.transform.childCount > 0)
        {
            DestroyImmediate(cardSelectorParent.transform.GetChild(0).gameObject);
        }
        cardSelectorObject.SetActive(true);
        for (int i = 0; i < hadM.currentDeck.Count; i++)
        {
            GameObject cardUI = Instantiate(cardUIPrefabDeck, cardSelectorParent.transform);
            UICard uiCard = cardUI.GetComponent<UICard>();
            uiCard.manager = this;
            uiCard.SetCard(hadM.currentDeck[i]);
        }
        buttonCloseDeck.SetActive(true);

        tip.text = "this is your current deck";

    }


    internal void ClosePanel()
    {
        cardSelectorObject.SetActive(false);
        while (cardSelectorParent.transform.childCount > 0)
        {
            DestroyImmediate(cardSelectorParent.transform.GetChild(0).gameObject);
        }

    }
}
