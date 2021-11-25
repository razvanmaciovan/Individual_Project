using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator anim;
    public GameObject Particles;
    Animator swing;

    private AudioSource sound;
    public float delay;
    float nextAttack = 0f;
    private bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {   
        anim = gameObject.GetComponent<Animator>();
        swing = Particles.GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();
        
        
        

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        

    }
   


    private void Attack()
    {
        

        if (Time.time >= nextAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                anim.SetTrigger("Attack");
                sound.Play();
                swing.SetTrigger("Swing");
                nextAttack = Time.time + delay;
                


            }

        }
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") == true) && (isHit == false))
        {
            isHit = true;
            Debug.Log("damage");
            StartCoroutine("HitCooldown");

        }
    }
    
    IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(delay);
        isHit = false;
    }

}
