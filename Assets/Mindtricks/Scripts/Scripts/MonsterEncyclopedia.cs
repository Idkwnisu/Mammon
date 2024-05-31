using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MonsterTier
{
    public string name;
    public Monster[] monsters;
    public GameObject ambient;
}

public class MonsterEncyclopedia : MonoBehaviour
{

    public MonsterTier[] monsters;
    public MonsterManager monsterManager;
    public int difficulty = 0;
    public GameObject currentAmbient;

    private void Start()
    {
        if (monsters[0].ambient != null)
            currentAmbient = Instantiate(monsters[0].ambient);
    }

    public void StartGame()
    {
        NewMonster();
        monsterManager.NewGame();
    }
    public void NewMonster()
    {
        int rand = UnityEngine.Random.Range(0, monsters[difficulty].monsters.Length);
        monsterManager.NewEnemy(monsters[difficulty].monsters[rand]);
    }

    internal void RaiseDifficulty()
    {
        if(currentAmbient != null)
            Destroy(currentAmbient);
        difficulty++;
        if (monsters[difficulty].ambient != null)
            currentAmbient = Instantiate(monsters[difficulty].ambient);
    }
}
