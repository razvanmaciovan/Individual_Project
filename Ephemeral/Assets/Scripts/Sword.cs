using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [Header("Modifiables values")]
    [SerializeField]
    private GameObject Particles;
    public int damage = 1;
    public float delay;
    
    private Animator anim;
    private Animator swingParticles;
    private AudioSource sound;
    private float nextAttack = 0f;
    private bool isHit = false;
    //private CapsuleCollider2D swordColl;
    //private LayerMask enemiesInRange;

    // Start is called before the first frame update
    void Start()
    {   
        anim = gameObject.GetComponent<Animator>();
        swingParticles = Particles.GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();
        //swordColl = gameObject.GetComponent<CapsuleCollider2D>();
        //Player player = GetComponent<Player>();
        //transform.position = player.transform.position;



    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        

    }
   

    //Attack animation
    private void Attack()
    {       
        if (Time.time >= nextAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                anim.SetTrigger("Attack");
                sound.Play();
                swingParticles.SetTrigger("Swing");
                nextAttack = Time.time + delay;               
            }
        }      
    }

    //Detects collision with Enemies
    //Deals damage according to the Player level
    //Triggers the hit animations from enemies.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Enemy") == true) && (isHit == false))
        {
            
            other.gameObject.GetComponent<Alive>().currentHitPoints -= (int)Mathf.Sqrt(gameObject.GetComponentInParent<Player>().level) * damage;
            if (other.gameObject.GetComponent<EnemyManager>())
            {
                other.gameObject.GetComponent<EnemyManager>().hpBar.UpdateHealthBarCurrent(other.gameObject.GetComponent<EnemyManager>().currentHitPoints);
                other.gameObject.GetComponentInChildren<HpBar>().Fade();
            }
            other.gameObject.GetComponent<Alive>().GetComponent<Animator>().SetTrigger("Hit");
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity += collision.relativeVelocity * bounce;

            isHit = true;
            Debug.Log("damage");
            StartCoroutine("HitCooldown");

        }
    }

    //Cooldown before hitting again
    private IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(delay);
        isHit = false;
    }

}
