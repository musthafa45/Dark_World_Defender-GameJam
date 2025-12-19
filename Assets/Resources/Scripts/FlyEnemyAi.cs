using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyAi : MonoBehaviour,IHealth
{
    [SerializeField] private Rigidbody2D EnemyRb;
    [SerializeField] float moveSpeed;
    [SerializeField] float LineOffSite;
    [SerializeField] float ShootingRange;
    public GameObject Bullet;
    public GameObject BulletParent;
    public float FireRate = 1f;
    private float NextShoot;

    [SerializeField] Transform player;
    [SerializeField] Transform House;
    [SerializeField] private Animator EnemyAnim;

    public int Health;

    public GameObject AttackBlood;
    public GameObject BloodStick;
    public GameObject Rip;

    public AudioSource EnemyAudio;
    public AudioClip HurtClip;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        House = GameObject.FindGameObjectWithTag("House").transform;
        EnemyAnim = GetComponent<Animator>();
        EnemyRb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        float DistanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (DistanceFromPlayer < LineOffSite && DistanceFromPlayer > ShootingRange)
        {
            transform.position =Vector2.MoveTowards(this.transform.position,player.position,moveSpeed * Time.deltaTime);
        }
        else if(DistanceFromPlayer <= ShootingRange && NextShoot < Time.time)
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, LineOffSite);
        Gizmos.DrawWireSphere(transform.position, ShootingRange);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
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
        else if (collision.gameObject.CompareTag("Player"))
        {
            EnemyAnim.SetTrigger("attack");
        }
        else if (collision.gameObject.CompareTag("House"))
        {
            Debug.Log("occupied");
        }
    }
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyAnim.SetTrigger("attack");
        }
    }
   
    public void TakeDamage(int Damage)
    {
        EnemyAudio.PlayOneShot(HurtClip);
        Instantiate(AttackBlood, transform.position, Quaternion.identity);
        Health -= Damage;
       
    }

    public int GetMaxHealth() {
        return Health;
    }

    public int GetCurrentHealth() {
        return Health;
    }
}
