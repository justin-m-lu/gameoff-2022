using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Projectile : MonoBehaviour

{
    [SerializeField] private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<CharacterStats>() != null)
        {
            CharacterStats health = collider.GetComponent<CharacterStats>();
            health.Damage(damage);
        }
    }
}