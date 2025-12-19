using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour,IHealth
{
    [SerializeField] private float EnemySpeed = 1f;
    private Rigidbody2D enemyRb;
    private Animator EnemyAnim;

    public int Health;

    public GameObject AttackBlood;
    public GameObject BloodStick;
    public GameObject Rip;

    public AudioSource EnemyAudio;
    public AudioClip HurtClip;

    [Header("Attack Settings")]
    [SerializeField] private float attackDelay = 3f;
    private float nextAttackTime;


    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        EnemyAnim = GetComponent<Animator>();   
    }


    private void Update() {
        if (!PlayerMovements.Instance.IsPlayerDead) {
            enemyRb.linearVelocity = new Vector2(-EnemySpeed, enemyRb.linearVelocity.y);
        }
        
        EnemyAnim.SetBool("isMoving", enemyRb.linearVelocity.magnitude > 0 && !PlayerMovements.Instance.IsPlayerDead);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            if (collision.gameObject.TryGetComponent<PlayerMovements>(out PlayerMovements playerMovements)) {
                TryAttackPlayer(playerMovements);
            }
        }

        if (collision.gameObject.CompareTag("Bullet")) {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("ShotGunBullet")) {
            Destroy(collision.gameObject);
            TakeDamage(3);
        }
        else if (collision.gameObject.CompareTag("AttackBox")) {
            TakeDamage(1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player")) {
            if (collision.gameObject.TryGetComponent(out PlayerMovements playerMovements)) {
                TryAttackPlayer(playerMovements);
            }
        }

        //if (collision.gameObject.CompareTag("Bullet")) {
        //    Destroy(collision.gameObject);
        //    TakeDamage(1);
        //}
        //else if (collision.gameObject.CompareTag("ShotGunBullet")) {
        //    Destroy(collision.gameObject);
        //    TakeDamage(3);
        //}
        //else if (collision.gameObject.CompareTag("AttackBox")) {
        //    TakeDamage(1);
        //}
    }

    private void OnCollisionStay2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Player")) {
            if (collision.gameObject.TryGetComponent<PlayerMovements>(out PlayerMovements playerMovements)) {
                TryAttackPlayer(playerMovements);
            }
        }

        //if (collision.gameObject.CompareTag("Bullet")) {
        //    Destroy(collision.gameObject);
        //    TakeDamage(1);
        //}
        //else if (collision.gameObject.CompareTag("ShotGunBullet")) {
        //    Destroy(collision.gameObject);
        //    TakeDamage(3);
        //}
        //else if (collision.gameObject.CompareTag("AttackBox")) {
        //    TakeDamage(1);
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            if (collision.gameObject.TryGetComponent<PlayerMovements>(out PlayerMovements playerMovements)) {
                TryAttackPlayer(playerMovements);
            }
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("ShotGunBullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(3);
        }
        else if (collision.gameObject.CompareTag("AttackBox"))
        {
            TakeDamage(1);
        }
    }



    public void TakeDamage(int Damage)
    {
        EnemyAudio.PlayOneShot(HurtClip);
        Instantiate(AttackBlood, transform.position, Quaternion.identity);
        Health -= Damage;

        if (Health <= 0) {
            Instantiate(BloodStick, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Instantiate(Rip, transform.position, Quaternion.identity);
        }
    }

    private void TryAttackPlayer(PlayerMovements player) {
        if (Time.time < nextAttackTime) return;

        EnemyAnim.SetTrigger("attack");
        player.TakeDamage(1);

        nextAttackTime = Time.time + attackDelay;
    }


    public int GetMaxHealth() {
        return Health;
    }

    public int GetCurrentHealth() {
        return Health;
    }
}
