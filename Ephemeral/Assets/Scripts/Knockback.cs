using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float thrust = 0f;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log(collision.gameObject.tag);
            Rigidbody2D entity = collision.gameObject.GetComponent<Rigidbody2D>();
            if (entity != null)
            {
                StartCoroutine(KnockCoroutine(entity));

            }



        }
    }
    private IEnumerator KnockCoroutine(Rigidbody2D entity)
    {
        Debug.Log("KNOCK");
        Vector2 forceDirection = entity.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * thrust;

        entity.velocity = force;
        yield return new WaitForSeconds(.3f);
        if(entity != null)
        entity.velocity = new Vector2();

    }
}

