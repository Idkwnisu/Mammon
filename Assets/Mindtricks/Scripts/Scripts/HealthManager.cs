using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    public MonsterManager monsterManager;
    public int fullHealth = 20;
    public TMP_Text text;
    int currentHealth;

    public UnityEvent healthReachZero;
    // Start is called before the first frame update
    
    public void StartBattles()
    {
        currentHealth  = fullHealth;
    }
    public void Damage(int dmg)
    {
        currentHealth -= dmg;
        text.text = currentHealth.ToString();
        if(currentHealth <= 0)
        {
            healthReachZero.Invoke();
        }
        JuiceManager.Instance.HitPlayer(dmg);
    }

    public void Heal(int dmg)
    {
        currentHealth += dmg;
        text.text = currentHealth.ToString();

    }

    public void TakeCurrentEnemyDamage()
    {
        Damage(monsterManager.currentMonster.damage);
    }
}
