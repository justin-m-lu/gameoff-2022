using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int mana = 50;
    [SerializeField] private int experience = 0;
    [SerializeField] private int MAX_HEALTH = 100;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite newSprite;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }
    
    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        this.health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if(wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        GetComponent<Animator>().enabled = false;
        spriteRenderer.sprite = newSprite;
        Debug.Log("I am dead.");
        Destroy(gameObject, 0.25f);
        if (gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
