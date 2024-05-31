using UnityEngine;

[CreateAssetMenu(fileName = "Monsters", menuName = "ScriptableObjects/Monster", order = 1)]
public class Monster : ScriptableObject
{
    public int id;
    public int fullHealth;
    public int damage;
    public GameObject monsterPrefab;
    public string monsterName;
}
