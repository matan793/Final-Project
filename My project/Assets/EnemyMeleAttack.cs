using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] GameObject Player;
    //References
    private Animator anim;
    
    //private EnemyPatrol enemyPatrol;

    private void Awake()
    {
            anim = GetComponent<Animator>();
        //    enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
                Player.GetComponent<PlayerHealth>().TakeDamage(damage);
                
            }
        }

        //if (enemyPatrol != null)
        //    enemyPatrol.enabled = !PlayerInSight();
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));



        //Debug.Log(PlayerInSight());
    }

    //private void DamagePlayer()
    //{
    //    if (PlayerInSight())
    //        playerHealth.TakeDamage(damage);
    //}
}
