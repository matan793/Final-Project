using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy stats")]
    public int max_health = 100;
    int health;
    public Animator animator;
    [Header("Collider Parameters")]
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;


    void Start()
    {
        health = max_health;
    }
    void Update()
    {
        if (PlayerInSight())
        {
            transform.position += new Vector3(-0.004f, 0, 0);
            animator.SetBool("Run", true);
        }
        else
            animator.SetBool("Run", false);
    }
    public void GetHurt(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hit");
        if(health <= 0)
        {
            Die();
        }
    }
    bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        //if (hit.collider != null)
        //playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));



        //Debug.Log(PlayerInSight());
    }
    void Die()
    {
        animator.SetBool("Dead", true);
       
        //Destroy(gameObject);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;
    }
}
