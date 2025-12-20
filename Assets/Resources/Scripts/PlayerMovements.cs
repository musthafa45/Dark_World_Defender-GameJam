using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public static PlayerMovements Instance {  get; private set; }
   
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 12f;

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

    public bool IsPlayerDead = false;
    private float mouseDelta;

    private void Awake() {
        Instance = this;
    }

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
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mouseDelta = difference.x;

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
        if (horizontal > 0) //facing right
        {
            transform.localScale = new Vector2(0.25f, transform.localScale.y);
        }
        else if(horizontal < 0) { //facing left

            transform.localScale = new Vector2(-0.25f, transform.localScale.y);
        }

        if (mouseDelta > 0) {// mouse On right side
            transform.localScale = new Vector2(0.25f, transform.localScale.y);
        }
        else if(mouseDelta < 0) { // mouse On left side
            transform.localScale = new Vector2(-0.25f, transform.localScale.y);
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
            ForceDeath();
        }

    }

    public void ForceDeath() {
        rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        gameObject.SetActive(false);
        GameObject soulEffect = Instantiate(DeadBody, transform.position, Quaternion.identity);
        Destroy(soulEffect, 5f);

        IsPlayerDead = true;

        Invoke(nameof(Dead), 5f);
        Dead();
    }

    private void Dead() {
        GameManager.Instance.PlayerDead();
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