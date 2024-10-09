using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator anim;
    private bool isFacingRight = true;
    public Transform weaponHolder;

    public int health;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator hurtAnim;

    private SceneTransition sceneTransitions;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        weaponHolder = transform.Find("Weapon Holder");
        sceneTransitions = FindObjectOfType<SceneTransition>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        //animation player di chuyen
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRuning", true);

            // Xoay player sang trai hoac phai
            if (moveInput.x > 0 && isFacingRight)
            {
                Flip();
            }
            else if (moveInput.x < 0 && !isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            anim.SetBool("isRuning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        weaponHolder.localScale = new Vector3(weaponHolder.localScale.x * -1, weaponHolder.localScale.y, weaponHolder.localScale.z);
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateHealthUI(health);
        hurtAnim.SetTrigger("hurt");
        if (health <= 0)
        {
            Destroy(gameObject);
            sceneTransitions.LoadScene("Lose");
        }

    }

    public void ChangeWeapon(Weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Weapon newWeapon = Instantiate(weaponToEquip, weaponHolder.position, weaponHolder.rotation, weaponHolder); // Gán vũ khí vào Weapon Holder
        newWeapon.playerScript = this; // Gán tham chiếu đến Player
    }

    void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    } 

  public void Heal(int healAmount)
    {
        if(health + healAmount >5)
        {
            health = 5; 
        }
        else
        {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }
}
