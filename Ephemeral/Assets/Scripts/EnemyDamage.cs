using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : Alive
{
    public int damage = 1;
    private bool isCooldown = false;
    private Collider2D col;
    private GameObject player;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");

    }
    protected override void TakeDamageAndDie()
    {
        if (currentHitPoints <= 0)
        {
            player.GetComponent<Player>().xpCurrent += (int)xpWorth;
            Destroy(gameObject);
            currentHitPoints = 0;
            

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.transform.name);
        if (collision.gameObject.tag == "Player" && isCooldown == false)
        {
            isCooldown = true;            
            //Player player = collision.gameObject.GetComponent<Player>();
            //player.currentHitPoints -= damage * (int)Mathf.Sqrt(level);
            collision.gameObject.GetComponentInParent<Player>().currentHitPoints -= damage * (int)Mathf.Sqrt(level);
            StartCoroutine("Cooldown");


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
