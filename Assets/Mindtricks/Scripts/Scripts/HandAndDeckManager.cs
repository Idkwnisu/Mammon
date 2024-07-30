using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HandAndDeckManager : MonoBehaviour
{
    public List<PlayingCard> startingDeck;
    public List<PlayingCard_Struct> fullDeck;
    public List<PlayingCard_Struct> currentDeck;
    public List<PlayingCard_Struct> currentSerie;

    public UnityEvent lostSerie;
    public UnityEvent lostHands;
    public UnityEvent<List<PlayingCard_Struct>> serieContinuing;
    public UnityEvent<List<PlayingCard_Struct>> serie21;
    public UnityEvent newSerie;

    public UnityEvent finalize;
    // Start is called before the first frame update

    public SequenceHandler seqHandler;
    public GridCreator grid;
    public GameObject parent;
    public GameObject template;
    public MonsterManager monsterManager;

    public int debugNumber = 13;
    public int maxHands = 5;
    private int handsLeft;
    public TMP_Text handsText;
    public TMP_Text deckText;
    public float animationTimeHands = 1.5f;

    public GameObject negativeOne;
    public GameObject negativeTwo;
    public GameObject negativeThree;


    public void ResetNegatives()
    {
        negativeOne.SetActive(true);
        negativeTwo.SetActive(true);
        negativeThree.SetActive(true);
        StartNewGame();
        NewSerie();
    }
    
    public void ResetOneNegative()
    {
        if(!negativeOne.activeInHierarchy)
            negativeOne.SetActive(true);
        else if(!negativeTwo.activeInHierarchy)
            negativeTwo.SetActive(true);
        else
            negativeThree.SetActive(true);

        StartNewGame();
        NewSerie();
    }
     
    public void ResetOneNegativeNoStart()
    {
        if(!negativeOne.activeInHierarchy)
            negativeOne.SetActive(true);
        else if(!negativeTwo.activeInHierarchy)
            negativeTwo.SetActive(true);
        else
            negativeThree.SetActive(true);

    }

    void Awake()
    {
        fullDeck = new List<PlayingCard_Struct>();
        for(int i = 0; i < startingDeck.Count; i++)
        {
            fullDeck.Add(startingDeck[i].get_struct());
        }

        currentDeck = new List<PlayingCard_Struct>();
        currentSerie = new List<PlayingCard_Struct>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        currentDeck.Clear();
        for(int i = 0; i < fullDeck.Count; i++)
        {
            currentDeck.Add(fullDeck[i]);
        }
        handsLeft = maxHands;
        handsText.text = handsLeft.ToString();
    }

    public void AddCardToDeck(PlayingCard_Struct card)
    {
        fullDeck.Add(card);
        StartNewGame();
        NewSerie();
    }

    public void RemoveCardFromDeck(int index)
    {
        fullDeck.RemoveAt(index);
        StartNewGame();
        NewSerie();
    }

    public void RemoveCardFromDeck(PlayingCard_Struct card)
    {
        fullDeck.Remove(card);
    }


    public void ForceCard(PlayingCard card)
    {
        ForceCard(card.get_struct());
    }
    
    public void ForceCard(PlayingCard_Struct card)
    {
        GameObject pc = Instantiate(template, parent.transform);
        CardTemplate ct = pc.GetComponent<CardTemplate>();
        grid.UpdateGrid();

        PlayingCard_Struct currentCard = card;
        ct.SetCard(currentCard);
        currentSerie.Add(currentCard);
        int result = seqHandler.CheckHand(currentSerie.ToArray());
        if (result == -1)
        {
            lostSerie.Invoke();
        }
        else if (result == 0)
        {
            serieContinuing.Invoke(currentSerie);
        }
        else
        {
            serie21.Invoke(currentSerie);
        }
    }

    public void NewCard()
    {
        if (currentDeck.Count == 0)
        {
            FinalizeHand();
        }
        else
        {
            GameObject pc = Instantiate(template, parent.transform);
            CardTemplate ct = pc.GetComponent<CardTemplate>();
            grid.UpdateGrid();

            int rand = Random.Range(0, currentDeck.Count);
            PlayingCard_Struct currentCard = currentDeck[rand];
            ct.SetCard(currentCard);
            currentSerie.Add(currentCard);
            currentDeck.Remove(currentDeck[rand]);
            deckText.text = currentDeck.Count.ToString();
            int result = seqHandler.CheckHand(currentSerie.ToArray());
            if (result == -1)
            {
                lostSerie.Invoke();
            }
            else if (result == 0)
            {
                serieContinuing.Invoke(currentSerie);
            }
            else
            {
                serie21.Invoke(currentSerie);
            }
        }
    }

    public void DamageWithHand()
    {
        if(!monsterManager.DamageWithHand(currentSerie))
        {
            if (handsLeft <= 0)
            {
                Invoke("LostHand", animationTimeHands);
            }
        }
    }

    public void CheckIfDead()
    {
        if(handsLeft <= 0)
        {
            Invoke("LostHand", animationTimeHands);

        }
    }

    public void FinalizeHand()
    {

        finalize.Invoke();
        CancelSerie();
       // NewSerie();

    }

    public void CancelSerie()
    {
        foreach (Transform g in parent.transform)
        {
            Destroy(g.gameObject);
        }
    }

    public void ResetHands()
    {
        handsLeft = maxHands;
    }

    public void ResetDeck()
    {
        currentDeck.Clear();
        for (int i = 0; i < fullDeck.Count; i++)
        {
            currentDeck.Add(fullDeck[i]);
        }
    }

    public void StartFirstSerie()
    {
        seqHandler.ResetText();
        currentSerie.Clear();
    }

    public void RestoreHand()
    {
        handsLeft++;
    }
    public void NewSerie()
    {
        handsLeft -= 1;

        handsText.text = handsLeft.ToString();


        if (handsLeft < 0)
        {
            Invoke("LostHand", animationTimeHands);
        }
        else
        {
            seqHandler.ResetText();
            currentSerie.Clear();
        }

        newSerie.Invoke();
    }

    public void LostHand()
    {
        lostHands.Invoke();
    }
}
