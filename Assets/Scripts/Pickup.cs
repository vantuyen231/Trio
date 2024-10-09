using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Weapon weaponToEquip;
    public float timeLife;
    public GameObject upSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            Instantiate(upSound, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeLife);
    }
}
