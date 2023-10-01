using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovements : MonoBehaviour
{
   
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator PlayerAnim;
    bool isGrounded;

    public GameObject AttackBlood;
    public GameObject BloodStick;

    public GameObject DeadBody;

    public int MaxHealth = 10;
    public int CurrentHealth;

    public AudioSource BulletAudio;
    public AudioClip HurtClip;

    PlayerAttack playerAttack;
    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        CurrentHealth = MaxHealth;
        rb = GetComponent<Rigidbody2D>();
        PlayerAnim = GetComponent<Animator>();
        isGrounded = true;
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal == 0)
        {
            PlayerAnim.SetBool("isMoving", false);

        }
        else if (isGrounded)
        {
            PlayerAnim.SetBool("isMoving", true);
        }


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isGrounded = false;
            PlayerAnim.SetBool("isMoving", false);
            PlayerAnim.Play("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }
        else if (rb.velocity.y <= 7)
        {
            isGrounded = true;

        }
        if (AKM.isRight == false)
        {
            Flip();
        }

        Flip();
        if (CurrentHealth <= 0)
        {
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Destroy(gameObject);
            Instantiate(DeadBody, transform.position, Quaternion.identity);
            Destroy(DeadBody, 5f);
            //restart.

        }


       
    }
   
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed , rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            //Vector3 localScale = transform.localScale;
            //localScale.x *= -1f;
            //transform.localScale = localScale;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    public void PlayAttackAnim()
    {
        PlayerAnim.Play("Attack1");
    }
    public void TakeDamage(int Damage)
    {
        BulletAudio.PlayOneShot(HurtClip);
        Instantiate(AttackBlood, transform.position, Quaternion.identity);
        CurrentHealth -= Damage;
      
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HomingBullet"))
        {
            BulletAudio.PlayOneShot(HurtClip);
            TakeDamage(2);
        }
    }

}