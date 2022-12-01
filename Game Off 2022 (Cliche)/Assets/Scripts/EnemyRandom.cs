using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 1.5f;
    private float x;
    private float y;
    private Vector2 NextPos;
    
    [SerializeField] private EnemyStats data;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Find", 0f, 0.2f);
        SetEnemyStats();
    }

    // Update is called once per frame
    void Update()
    {
        Flop();
    }

    private void SetEnemyStats()
    {
        GetComponent<CharacterStats>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    private void Find()
    {
        x = Random.Range (-10000, 10000);
        y = Random.Range (-10000, 10000);
        NextPos = new Vector2(x, y);
    }

    private void Flop()
    {
        transform.position = Vector2.MoveTowards(transform.position, NextPos, speed * Time.deltaTime);
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
