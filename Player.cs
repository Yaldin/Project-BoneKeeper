using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;

    public float maxSpeed;
    public Transform groundCheck;
    public float jumpForce;
    public float fireRate;
    public ConsumableItem item;
    public int maxHealth;
    public int maxMana;

    private float speed;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool onGround;
    private bool jump = false;
    private bool doubleJump;
    private Weapon weaponEquipped;
    private Animator anim;
    private Attack attack;
    private float nextAttack;
    private int health;
    private int mana;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = maxSpeed;
        anim = GetComponent<Animator>();
        attack = GetComponentInChildren<Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (onGround)
            doubleJump = false;

        if (Input.GetButtonDown("Jump") && (onGround || doubleJump))
        {
            Jump();
            if (!onGround && !doubleJump)
                doubleJump = true;
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextAttack && weaponEquipped != null)
        {
            anim.SetTrigger("Attack");
            attack.PlayAnimation(weaponEquipped.animation);
            nextAttack = Time.time + fireRate;
        }

        if (Input.GetButtonDown("Fire3")) 
        {
            UseItem(item);
            Inventory.inventory.RemoveItem(item);
        }

        // Obtém a velocidade horizontal do seu input
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");
        // Atualiza o parâmetro "Speed" no Animator com a velocidade horizontal.
        anim.SetFloat("Speed", Mathf.Clamp01(Mathf.Abs(horizontalSpeed)));
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }

        if (jump)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
            jump = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Jump()
    {
        anim.SetBool("Jump", true);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("onGround"))
        {
            jump = false;
            anim.SetBool("Jump", false);
        }
    }

    public void AddWeapon(Weapon weapon)
    {
        weaponEquipped = weapon;
        attack.SetWeapon(weaponEquipped.damage);
    }

    public void UseItem(ConsumableItem item) 
    {
        health += item.healthGain;
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
        mana += item.manaGain;
        if (mana >= maxMana)
        {
            mana = maxMana;
        }
    }
}