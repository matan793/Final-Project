using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : MonoBehaviour
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

    [Header("Animator")]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
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
}
