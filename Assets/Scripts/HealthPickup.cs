using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    Player playerSrcipt;
    public int healAmount;
    public float timeLife;


    void Start()
    {
        playerSrcipt = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerSrcipt.Heal(healAmount);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Destroy(gameObject, timeLife);
    }
}
