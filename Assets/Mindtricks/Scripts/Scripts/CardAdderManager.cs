using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct CardPool
{
    public string name;
    public PlayingCard[] addableCards;
    public bool active;
    public int numberOfExtractions;
}

public class CardAdderManager : MonoBehaviour
{
    public CardPool[] pool;
    public List<PlayingCard> currentPool;
    public CardUIManager uiManager;
    public HandAndDeckManager deckManager;
    
    // Start is called before the first frame update
    void Start()
    {
        // ExtractCardsToRemove(3);
        currentPool = new List<PlayingCard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshAddablePool()
    {
        currentPool.Clear();
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].active)
            {
                for(int z = 0; z < pool[i].numberOfExtractions; z++)
                {
                    int r = UnityEngine.Random.Range(0, pool[i].addableCards.Length);
                    currentPool.Add(pool[i].addableCards[r]);
                }    
            }
        }
    }

    public void ExtractCardsToAdd(int n)
    {
        RefreshAddablePool();
        List<PlayingCard_Struct> cardsToShow = new List<PlayingCard_Struct>();
        for(int i = 0; i < n; i++)
        {
            int r = UnityEngine.Random.Range(0, currentPool.Count);
            cardsToShow.Add(currentPool[r].get_struct());
        }

        uiManager.OpenInsertCardSelector(cardsToShow);
    }

    public void ExtractCardsToRemove(int n)
    {
        var random = new System.Random();
        int[] intArray = Enumerable.Range(0, deckManager.fullDeck.Count).OrderBy(t => random.Next()).Take(n).ToArray(); //check if it is too slow
        uiManager.OpenRemoveCardSelector(intArray, deckManager.fullDeck);
    }
}
