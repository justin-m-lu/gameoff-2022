using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 1.5f;
    
    [SerializeField] private EnemyStats data;

    // Start is called before the first frame update
    void Start()
    {
        SetEnemyStats();
    }

    private void SetEnemyStats()
    {
        GetComponent<CharacterStats>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(collider.GetComponent<CharacterStats>() != null)
            {
                collider.GetComponent<CharacterStats>().Damage(damage);
                this.GetComponent<CharacterStats>().Damage(10000);
            }
        }
    }
}
