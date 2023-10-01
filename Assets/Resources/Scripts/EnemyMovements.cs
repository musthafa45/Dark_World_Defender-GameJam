using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    [SerializeField]private Rigidbody2D EnemyRb;
    [SerializeField] private float EnemySpeed =1f;
    [SerializeField] private Animator EnemyAnim;

    public int Health;

    public GameObject AttackBlood;
    public GameObject BloodStick;
    public GameObject Rip;

    public AudioSource EnemyAudio;
    public AudioClip HurtClip;
    void Start()
    {
        EnemyRb =GetComponent<Rigidbody2D>();
        EnemyAnim = GetComponent<Animator>();   
    }

    void Update()
    {
        EnemyRb.velocity = new Vector2(-EnemySpeed , EnemyRb.velocity.y);
        if(EnemySpeed !=0)
        {
            EnemyAnim.SetBool("isMoving",true);
        }
       if(Health < 0)
        {
            Instantiate(BloodStick,transform.position,Quaternion.identity);
            Destroy(gameObject);
            Instantiate(Rip, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<PlayerMovements>(out PlayerMovements playerMovements))
            {
                EnemyAnim.SetTrigger("attack");
                playerMovements.TakeDamage(1);

            }
        }
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
    }
    public void TakeDamage(int Damage)
    {
        EnemyAudio.PlayOneShot(HurtClip);
        Instantiate(AttackBlood, transform.position, Quaternion.identity);
        Health -= Damage;
       
    }
}
