using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] enemies;
    public float spawnOffsetX ;
    public float spawnOffsetY ;
    public float spawnOffsetZ;

    private int halfHealth;
    private Animator anim;

    public int damage;

    Animator cameraAnim;

    private Slider healthBar;

    private SceneTransition sceneTransitions;
    

    // Start is called before the first frame update
    void Start()
    {
        cameraAnim = Camera.main.GetComponent<Animator>();
        cameraAnim.SetTrigger("shake");
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        healthBar = FindAnyObjectByType<Slider>();
        healthBar.maxValue = health;
        healthBar.value = health;
        sceneTransitions = FindObjectOfType<SceneTransition>();

    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.value = health;
        if (health <= 0)
        {
            Destroy(gameObject);
            healthBar.gameObject.SetActive(false);
            sceneTransitions.LoadScene("Win");
        }

        if (health <= halfHealth)
        {
            anim.SetTrigger("stage2");
        }

        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy,transform.position  + new Vector3(spawnOffsetX, spawnOffsetY, spawnOffsetZ) ,transform.rotation);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Player>().TakeDamage(damage);
    }


}


