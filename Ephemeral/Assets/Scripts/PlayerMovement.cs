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
    public bool flashActive = false;
    public float flashLength = 1f;
    public float flashCounter = 0f;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scaleofobject = transform.localScale;
        flashCounter = flashLength;

    }
    private void Update()
    {
        
        mousepos = GameObject.Find("MousePos").transform.rotation.eulerAngles.z;
        AnimatePlayer();
        if (flashActive) OnHitFlash();
        
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void AnimatePlayer()
    {
        if (mousepos >= 0 && mousepos <= 180) transform.localScale = new Vector3(-scaleofobject.x, scaleofobject.y, scaleofobject.z);

        else transform.localScale = new Vector3(scaleofobject.x, scaleofobject.y, scaleofobject.z);

        if (moveX != 0) anim.SetBool("Walk", true);

        else anim.SetBool("Walk", false);

        if (moveY != 0) anim.SetBool("Walk", true);


    }
    void MovePlayer()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        moveY = Input.GetAxisRaw("Vertical");

        Vector2 movemement = new Vector2(moveX * speed, moveY * speed);
        rb.velocity = movemement;
    }


    public void OnHitFlash()
    {
       
       if(flashCounter > flashLength * .99f)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        }
       else if(flashCounter > flashLength * .82f)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
       else if(flashCounter > flashLength * .62f)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        }
       else if(flashCounter > flashLength * .49f)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
       else if(flashCounter > flashLength * .33f)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        }
       else if(flashCounter > flashLength * .16f)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
       else if(flashCounter > 0f)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        }
        else
        {
            flashActive = false;
            
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
        flashCounter -= Time.deltaTime;
    }

}