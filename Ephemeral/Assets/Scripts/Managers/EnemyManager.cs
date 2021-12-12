using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : Alive
{
    public int damage = 1;
    private bool isCooldown = false;
    private Collider2D col;
    private GameObject player;
    private NavMeshAgent agent;
    public float chaseDistance = 1.5f;
    private float hitCooldown = 0.5f;
    public HpBar hpBar;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }
    protected override void Start()
    {
        base.Start();
        hpBar.UpdateHealthBarMax(maxHitPoints);
        hpBar.UpdateHealthBarCurrent(maxHitPoints);
    }
    protected override void TakeDamageAndDie()
    {
        if (currentHitPoints <= 0)
        {
            player.GetComponent<Player>().xpCurrent += (int)xpWorth;
            //agent.enabled = false;
            
            Destroy(gameObject);
            currentHitPoints = 0;
            

        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.transform.name);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isCooldown == false)
        {
            isCooldown = true;
            
            //Player player = collision.gameObject.GetComponent<Player>();
            //player.currentHitPoints -= damage * (int)Mathf.Sqrt(level);
            collision.gameObject.GetComponentInParent<Player>().currentHitPoints -= damage * (int)Mathf.Sqrt(level);
            collision.gameObject.GetComponentInParent<PlayerMovement>().flashCounter = collision.gameObject.GetComponentInParent<PlayerMovement>().flashLength;
            collision.gameObject.GetComponentInParent<PlayerMovement>().flashActive = true;
            DamagePopup.CreateDamagePopup(collision.transform.position, damage * (int)Mathf.Sqrt(level),new Color(1,0,0),36);
            CameraShake.Instance.ShakeCamera(2f,0.2f);
            StartCoroutine("Cooldown");
            //StartCoroutine(collision.gameObject.GetComponent<PlayerMovement>().Knockback(knockbackDuration,knockbackPower,this.transform));
            

        }
        else player.layer = 8;
    }
    protected override void Update()
    {
        ChasePlayer();
        TakeDamageAndDie();
        
        
    }
    private void ChasePlayer()
    {
        if (agent != null && player != null)
        {


            //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            if (Vector3.Distance(transform.position, player.transform.position) < chaseDistance)
            {
                agent.speed = 0.7f;
                agent.SetDestination(player.transform.position);
            }
            else
            {
                agent.speed = 0;
            }
        }
    }
    IEnumerator Cooldown()
    {
        player.layer = 10;
        yield return new WaitForSeconds(hitCooldown);
        isCooldown = false;
        if(GameObject.FindGameObjectWithTag("Player"))
        player.layer = 8;
        //yield break;
    }

    
   
}
