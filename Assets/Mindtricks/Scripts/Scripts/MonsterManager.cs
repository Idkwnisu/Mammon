using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MonsterManager : MonoBehaviour
{
    public Monster currentMonster;

    private int currentHealth;
    public UnityEvent enemyDead;
    public SpriteRenderer spriteRenderer;
    public TMP_Text text;
	public SequenceHandler handler;
    public HandAndDeckManager hadm;
    public int[] difficultyRise;
    public MonsterEncyclopedia encyclopedia;
    public GameObject currentMonsterObject;
    public GameObject currentMonsterParent;

    public int killed;
    public TMP_Text killedText;
    public TMP_Text multText;
    public TMP_Text enemyName;
    public float multiplier = 1.0f;
    public void NewGame()
    {
        killed = 0;
    }
    public void NewEnemy(Monster newMonster)
    {
        currentMonster = newMonster;
        currentHealth = currentMonster.fullHealth;
        if(currentMonsterObject != null)
        {
            Destroy(currentMonsterObject);
        }
        currentMonsterObject = Instantiate(newMonster.monsterPrefab, currentMonsterParent.transform);
        JuiceManager.Instance.SetEnemy(currentMonsterObject);
        text.text = currentHealth.ToString();
        enemyName.text = newMonster.monsterName;
    }

    public void Damage(int dmg)
    {
        currentHealth -= dmg;
        JuiceManager.Instance.HitEnemy(dmg);
        if(currentHealth <= 0)
        {
            killed++;
            if(encyclopedia.difficulty < difficultyRise.Length)
            {
                if(killed >= difficultyRise[encyclopedia.difficulty])
                {
                    encyclopedia.RaiseDifficulty();
                }
            }
            enemyDead.Invoke();
        }
        else
        {
            hadm.NewSerie();
        }
        text.text = currentHealth.ToString();
    }

    public void DamageWithHand(List<PlayingCard_Struct> hand)
    {
        int damage = 0;
        for(int i = 0; i < hand.Count; i++)
        {
            switch(hand[i].id)
            {
                case 0:
                    damage += 1;
                    break;
                case 1:
                    damage += 2;
                    break;
                case 2:
                    changeMultiplier(2);
                    break;
                case 3:
                    damage += 3;
                    break;
                case 4:
                    GameManager.Instance.Heal(5);
                    break;
                case 5:
                    GameManager.Instance.ResetOneNegative();
                    break;
                case 6:
                    GameManager.Instance.AddSeries(1);
                    break;
                case 7:
                    GameManager.Instance.ResetDeck();
                    break;
            }
        }
		int n = handler.CheckHand(hand.ToArray());
		if(n == 1)
		{
			Damage(Mathf.FloorToInt(damage * 2.0f * multiplier));
		}
		else
		{
			Damage(Mathf.FloorToInt(damage * multiplier));
		}
    }

    public void changeMultiplier(float newMulti)
    {
        multiplier *= newMulti;
        multText.text = multiplier.ToString();
    }

    public void ResetMultiplier()
    {
        multiplier = 1.0f;
        multText.text = multiplier.ToString();

    }
}
