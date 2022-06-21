using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : MonoBehaviour
{
    
    [Header("Attack Parameters")]
    [SerializeField] float attackCooldown;
    [SerializeField] float attack_range;
    [SerializeField] int damage;

    [Header("Attack Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Enemy's sight")]
    [SerializeField] float range;
    [SerializeField] float sight_colliderDistance;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] GameObject Player;

    [Header("Animator")]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInSight())
        {
            Debug.Log("player in sight");
        }

        
        if (PlayerInAttackRange())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                //animator.SetTrigger("attack");
                Player.GetComponent<PlayerManeger>().TakeDamage(damage);
                Debug.Log("attacking");
            }
        }
    }
    bool PlayerInAttackRange()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * attack_range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * attack_range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        //if (hit.collider != null)
        //playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }
    bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * sight_colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        //if (hit.collider != null)
        //playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * attack_range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * attack_range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * sight_colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));


        //Debug.Log(PlayerInSight());
    }
}
