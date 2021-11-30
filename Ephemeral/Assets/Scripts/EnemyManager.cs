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
    public float knockbackPower = 10f;
    public float knockbackDuration = 1f;
    public float chaseDistance = 1.5f;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

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
        Debug.Log(collision.gameObject.transform.name);
        if (collision.gameObject.tag == "Player" && isCooldown == false)
        {
            isCooldown = true;            
            //Player player = collision.gameObject.GetComponent<Player>();
            //player.currentHitPoints -= damage * (int)Mathf.Sqrt(level);
            collision.gameObject.GetComponentInParent<Player>().currentHitPoints -= damage * (int)Mathf.Sqrt(level);
            StartCoroutine("Cooldown");
            StartCoroutine(collision.gameObject.GetComponent<PlayerMovement>().Knockback(knockbackDuration,knockbackPower,this.transform));
            

        }
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
        yield return new WaitForSeconds(0.5f);
        isCooldown = false;
        //yield break;
    }

    //IEnumerator KnockBack()
    //{
        //agent.enabled = false;
        //GetComponent<Rigidbody2D>().isKinematic = true;
        //player.GetComponent<Rigidbody2D>().AddForce(new Vector2(5,5), ForceMode2D.Impulse);
        //yield return new WaitForSeconds(0.5f);
        //GetComponent<Rigidbody2D>().isKinematic = false;
        //agent.enabled = true;
    //}
   
}
