using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComBat : MonoBehaviour
{
    public int attacl_damage;
    public Animator animator;
    public Transform sword_point;
    public float sword_range = 0.5f;
    public LayerMask enemy_leyers;
    public int attacks_per_second = 2;
    float next_attack = 0;
    
    void Update()
    {
        if (Time.time >= next_attack)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                next_attack = Time.time + 1f / (float)(attacks_per_second);
            }
            
        }
    }
    void Attack()
    {
        animator.SetTrigger("Hit");

        var enemies = Physics2D.OverlapCircleAll(sword_point.position, sword_range, enemy_leyers);
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Enemy>().GetHurt(attacl_damage);
        }
    }
    
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawSphere(sword_point.position, sword_range);
    //}
}
