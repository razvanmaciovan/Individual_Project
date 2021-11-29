using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeMovement : MonoBehaviour
{
	private Animator anim;
    private Vector3 newpos;
   
    
    private void Start()
    {       
        anim = GetComponent<Animator>();
        newpos = transform.position;
        anim.SetBool("Moving", false);       
    }
   
    // Use this for initialization
    void Update()
	{      
        MoveAnimation();      
    }
	
    private void MoveAnimation()
    {
        if (newpos != transform.position)
        {
            anim.SetBool("Moving", true);
            newpos = transform.position;
        }
        else anim.SetBool("Moving", false);
    }
    
   
    
}
