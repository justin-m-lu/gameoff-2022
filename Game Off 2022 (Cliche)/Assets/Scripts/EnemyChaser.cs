using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 1.5f;
    
    [SerializeField] private EnemyStats data;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyStats();
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    private void SetEnemyStats()
    {
        GetComponent<CharacterStats>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(collider.GetComponent<CharacterStats>() != null)
            {
                collider.GetComponent<CharacterStats>().Damage(damage);
                this.GetComponent<CharacterStats>().Damage(10000);
                speed = 0f;
            }
        }
    }
}
