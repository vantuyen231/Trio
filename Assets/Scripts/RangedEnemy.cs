using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public float stopDistance;

    private float attackTime;

    private Animator anim;

    public Transform shotPoint;

    public GameObject enemyBullet;
 


    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if(player != null)
        {
            if(Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            if (Time.time >= attackTime)
            {
                attackTime = Time.time + timeBetweenAttacks;
                anim.SetTrigger("Attack");
            }
        }
    }
    public void RangedAttack()
    {
        Vector2 direction = player.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
        shotPoint.rotation = rotation;

        Instantiate(enemyBullet, shotPoint.position, shotPoint.rotation);
    }
    
}
