using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyDamage : Alive
{
    public int damage = 1;
    private bool isCooldown = false;
    private Collider2D col;
    private GameObject player;
    private NavMeshAgent agent;

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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.transform.name);
        if (collision.gameObject.tag == "Player" && isCooldown == false)
        {
            isCooldown = true;            
            //Player player = collision.gameObject.GetComponent<Player>();
            //player.currentHitPoints -= damage * (int)Mathf.Sqrt(level);
            collision.gameObject.GetComponentInParent<Player>().currentHitPoints -= damage * (int)Mathf.Sqrt(level);
            StartCoroutine("Cooldown");


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
            if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
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
        yield break;
    }

    void KnockBack()
    {
        
    }
   
}
