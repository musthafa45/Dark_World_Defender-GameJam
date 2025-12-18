using UnityEngine;

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
    private bool isGrounded;

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


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            isGrounded = false;
            PlayerAnim.SetBool("isMoving", false);
            PlayerAnim.Play("Jump");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);

        }
        else if (rb.linearVelocity.y <= 7)
        {
            isGrounded = true;

        }
        if (AKM.isRight == false)
        {
            Flip();
        }

        Flip();

    }
   
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed , rb.linearVelocity.y);
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

        if (CurrentHealth <= 0) {
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            gameObject.SetActive(false);
            Instantiate(DeadBody, transform.position, Quaternion.identity);
            Destroy(DeadBody, 5f);

            //restart.
        }

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