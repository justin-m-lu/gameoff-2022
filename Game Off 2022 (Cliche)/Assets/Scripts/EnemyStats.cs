using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyStats : ScriptableObject

{
    public int hp;
    public int damage;
    public int speed;

}