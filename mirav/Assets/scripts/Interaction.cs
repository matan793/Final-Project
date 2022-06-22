using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] Transform InteractionPoint;
    [SerializeField] bool DoOnce = true;
    [SerializeField] GameObject gameObject;
    [SerializeField] Vector2 positionToDecrement;
    [SerializeField] Animator animator;
    int count = 0;
    [SerializeField] KeyCode KeyCode;
    float radius = 0.5f;
    
    [SerializeField] LayerMask PlayerLayer;
    private void Update()
    {
        if (DoOnce && count == 0)
        {
            if (Input.GetKeyDown(KeyCode))
            {
                if (DetectedInteraction())
                {

                    animator.SetBool("activated", true);
                    gameObject.transform.position -= -((Vector3)positionToDecrement);
                   count++;
                }
            }
        }
        else if(!DoOnce)
        {
            if (Input.GetKeyDown(KeyCode))
            {
                if (DetectedInteraction())
                {
                    gameObject.transform.position -= -((Vector3)positionToDecrement);
                    animator.SetBool("activated", true);
                    Debug.Log("halit");
                    //door.transform.position -= -((Vector3)positionToDecrement);
                    count++;
                }
            }
        }
        
    }
    bool DetectedInteraction()
    {
        return Physics2D.OverlapCircle(InteractionPoint.position, radius, PlayerLayer);
    }
   
}
