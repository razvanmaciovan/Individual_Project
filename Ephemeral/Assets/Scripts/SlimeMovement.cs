using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class SlimeMovement : MonoBehaviour
{
	private Animator anim;
    private Vector3 newpos;
    public int FOW;
    public AIPath pathLength;
    
    private void Start()
    {
        newpos = transform.position;
        anim = GetComponent<Animator>();
        
        
        
        
        anim.SetBool("Moving", false);
        
    }
   
    // Use this for initialization
    void Update()
	{
        MoveAnimation();
        CheckDistance();
        
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
    
    private void CheckDistance()
    {
        if(pathLength.remainingDistance <= FOW)
        {
            gameObject.GetComponent<AIPath>().canMove = true;
        }
        else gameObject.GetComponent<AIPath>().canMove = false;
    }
    
}
