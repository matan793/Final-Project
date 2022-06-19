using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int max_health = 100;
    int health;
    public Animator animator;
    void Start()
    {
        health = max_health;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        //animator.SetTrigger("Hit");
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetTrigger("Dead");

        //Destroy(gameObject);
        GetComponent<Collider2D>().enabled = false;
        //GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;
    }
}
