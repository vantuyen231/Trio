using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public Player playerScript;

    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;
    public GameObject EffectWeapon;
    public float timeEf;
    public Transform effectPoint;


    private float shotTime;
    
        void Update()
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position;
            float angle = Mathf.Atan2 (direction.y, direction.x)*Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle-180,Vector3.forward);
            transform.rotation = rotation;

            if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
                transform.localScale = new Vector3(1, -1, 0);
            else
                transform.localScale = new Vector3(1, 1, 0);

            if (Input.GetMouseButton(0))
                if(Time.time >= shotTime)
                {
                    Instantiate(projectile, shotPoint.position,transform.rotation);
                    GameObject effectInstance = Instantiate(EffectWeapon, effectPoint.position, transform.rotation);
                    Destroy(effectInstance, timeEf);
                    shotTime = Time.time+timeBetweenShots;
                }
        }
    }
    
    /*
    void Update()
    {
        // Xoay theo hướng chuột
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 180)); // Xoay vũ khí theo chuột

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(1, -1, 0);
        else
            transform.localScale = new Vector3(1, 1, 0);

        if (Input.GetMouseButton(0) && Time.time >= shotTime)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectile, shotPoint.position, transform.rotation);
        GameObject effectInstance = Instantiate(EffectWeapon, shotPoint.position, transform.rotation);
        Destroy(effectInstance, timeEf);
        shotTime = Time.time + timeBetweenShots;
    }
}*/