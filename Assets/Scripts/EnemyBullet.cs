using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Player playerScript;

    private Vector2 targetPosition;

    public float speed;

    public int damage;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPosition = playerScript.transform.position;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, targetPosition) > .1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition,speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
