using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public MonsterEncyclopedia monsterEnc;
    public MonsterManager monsterManager;
    public HealthManager healthManager;
    public HandAndDeckManager handAndDeckManager;

    public GameObject deadPanel;


    public void Start()
    {
        NewGame();
    }

    public void ResetNegatives()
    {
        handAndDeckManager.ResetNegatives();
    }

    public void AddSeries(int n)
    {
        handAndDeckManager.RestoreHand();
    }


    public void Heal(int n)
    {
        healthManager.Heal(n);
    }


    public void NewGame()
    {
        monsterEnc.NewMonster();
        healthManager.StartBattles();
        handAndDeckManager.StartNewGame();
        handAndDeckManager.NewSerie();
    }

    public void Dead()
    {
        deadPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }    

    public void RemoveCard(int n)
    {
        handAndDeckManager.RemoveCardFromDeck(n);
    }

    public void AddCard(PlayingCard_Struct card)
    {
        handAndDeckManager.AddCardToDeck(card);
    }

    internal void ResetDeck()
    {
        handAndDeckManager.ResetDeck();
    }

    internal void ResetOneNegative()
    {
        handAndDeckManager.ResetOneNegative();
    }
}
