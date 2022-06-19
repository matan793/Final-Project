using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    public float speed = 50f;
    public CharacterController2D Controller;
    float MoveDirection;
    bool IsJumping = false;
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        MoveDirection = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(MoveDirection));
        if(Input.GetButtonDown("Run"))
        {
            speed += 15f;
            animator.SetBool("IsRuning", true);
        }
        else if(Input.GetButtonUp("Run"))
        {
            speed -= 15f;
            animator.SetBool("IsRuning", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            IsJumping = true;
            animator.SetBool("IsJumping", true);
        }
    }
    public void OnLand()
    {
        animator.SetBool("IsJumping", false);
    }
    private void FixedUpdate()
    {
        Controller.Move(MoveDirection * Time.fixedDeltaTime, false, IsJumping);
        IsJumping = false;
    }
}
