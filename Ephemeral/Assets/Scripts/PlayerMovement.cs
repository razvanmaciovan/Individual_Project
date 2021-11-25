using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    private float moveX = 0f, moveY = 0f;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 scaleofobject;
    private float mousepos;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scaleofobject = transform.localScale;
        
    }
    private void Update()
    {
        MovePlayer();
        mousepos = GameObject.Find("MousePos").transform.rotation.eulerAngles.z;
        AnimatePlayer();
    }
    void AnimatePlayer()
    {
        if(mousepos >= 0 && mousepos<= 180) transform.localScale = new Vector3(-scaleofobject.x, scaleofobject.y, scaleofobject.z);

        else transform.localScale = new Vector3(scaleofobject.x, scaleofobject.y, scaleofobject.z);

        if (moveX != 0)   anim.SetBool("Walk", true);

        else  anim.SetBool("Walk", false);
        
        if (moveY != 0) anim.SetBool("Walk", true);

   
    }
    void MovePlayer()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        moveY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(moveX * speed, moveY * speed);
    }
    
}
