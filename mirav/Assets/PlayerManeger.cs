using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManeger : MonoBehaviour
{
    [Header("Stats")]
    public int max_health;
    int health;
    public int damage;
    [Header("Movment")]
    [SerializeField] float speed;
    [SerializeField] CharacterController2D characterController;
    float move_direction;
    bool jumping;
    [Header("Combat")]
    public int attack_damage;
    public Transform sword_point;
    public float sword_range = 0.5f;
    public LayerMask enemy_leyers;
    public int attacks_per_second = 2;
    float next_attack = 0;
    [Header("Animator")]
    public Animator animator;

    void Start()
    {
        health = max_health;
    }

    void Update()
    {
        move_direction = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(move_direction));

        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
            animator.SetBool("IsJumping", true);
        }
        if(Input.GetButtonDown("Run"))
        {
            speed += 15;
            animator.SetBool("IsRunning", true);
        }
        else if(Input.GetButtonUp("Run"))
        {
            speed -= 15;
            animator.SetBool("IsRunning", false);
        }
        if (Time.time >= next_attack)
        {
            if (Input.GetButtonDown("attack"))
            {
                Attack();
                next_attack = Time.time + 1f / (float)(attacks_per_second);
                animator.SetTrigger("attack");
            }

        }

    }

    void FixedUpdate()
    {
        characterController.Move(move_direction * Time.fixedDeltaTime, false, jumping);
        jumping = false;
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    void Attack()
    {

        var enemies = Physics2D.OverlapCircleAll(sword_point.position, sword_range, enemy_leyers);
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Enemy>().GetHurt(attack_damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(sword_point.position, sword_range);
    }



}
