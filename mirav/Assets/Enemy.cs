using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy stats")]
    public int max_health = 100;
    int health;
    [Header("Animator")]
    public Animator animator;

    void Start()
    {
        health = max_health;
    }
    void Update()
    {

        //if (PlayerInSight())
        //{
        //    transform.position += new Vector3(-0.004f, 0, 0);
        //    animator.SetBool("Run", true);
        //}
        //else
        //    animator.SetBool("Run", false);
    }
    public void GetHurt(int damage)
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
        //animator.SetBool("Dead", true);

        //Destroy(gameObject);
        GetComponent<Collider2D>().enabled = false;
        //GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;
    }
}
