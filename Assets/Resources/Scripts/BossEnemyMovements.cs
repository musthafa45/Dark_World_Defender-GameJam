using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyMovements : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    Transform player;
    [SerializeField] private Animator EnemyAnim;
    [SerializeField] private Rigidbody2D BossEnemyRb;
    [SerializeField] float LineOffSite;
    [SerializeField] float ShootingRange;
    public GameObject Bullet;
    public GameObject BulletParent;
    public float FireRate = 1f;
    private float NextShoot;
    public int Health;
    [SerializeField] Transform House;
    public GameObject AttackBlood;
    public GameObject BloodStick;
    public GameObject Rip;

    public AudioSource EnemyAudio;
    public AudioClip HurtClip;
    void Start()
    {
        BossEnemyRb = GetComponent<Rigidbody2D>();
        EnemyAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        House = GameObject.FindGameObjectWithTag("House").transform;

    }

   
    void Update()
    {
        float DistanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (DistanceFromPlayer < LineOffSite && DistanceFromPlayer > ShootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (DistanceFromPlayer <= ShootingRange && NextShoot < Time.time)
        {
            Instantiate(Bullet, BulletParent.transform.position, Quaternion.identity);
            NextShoot = Time.time + FireRate;
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, House.position, moveSpeed * Time.deltaTime);
        }

        if (Health < 0)
        {
            Instantiate(BloodStick, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Instantiate(Rip, transform.position, Quaternion.identity);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("AttackBox"))
        {
            TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("ShotGunBullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(3);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyAnim.Play("attack");
        }
    }
   
    public void TakeDamage(int Damage)
    {
        EnemyAudio.PlayOneShot(HurtClip);
        Instantiate(AttackBlood, transform.position, Quaternion.identity);
        Health -= Damage;
       
    }
}
