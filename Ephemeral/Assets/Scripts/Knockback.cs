using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float thrust = 0f;
   
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log(collision.gameObject.tag);
                Rigidbody2D entity = collision.gameObject.GetComponentInParent<Rigidbody2D>();
                if (entity != null)
                {
                    
                    StartCoroutine(KnockCoroutine(entity));
                }
            

            
        }
    }
    private IEnumerator KnockCoroutine(Rigidbody2D entity)
    {
        //Debug.Log("KNOCK");
        Vector2 forceDirection = entity.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * thrust;

        entity.velocity = force;
        yield return new WaitForSeconds(.3f);
        if(entity != null)
        entity.velocity = new Vector2();
    }
}

