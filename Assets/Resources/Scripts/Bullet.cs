using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject Target;
    public float BulletSpeed;
    Rigidbody2D BulletRb;

    public AudioSource BulletAudio;
    public AudioClip HurtClip;
    void Start()
    {

        BulletRb = GetComponent<Rigidbody2D>();
        Target = GameObject.FindGameObjectWithTag("Player");
        if(Target != null) {
            Vector2 MoveDir = (Target.transform.position - transform.position).normalized * BulletSpeed;
            BulletRb.linearVelocity = new Vector2(MoveDir.x, MoveDir.y);
        }
        
        Destroy(this.gameObject,2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
       else if (collision.gameObject.TryGetComponent(out PlayerMovements playerMovements))
        {
            BulletAudio.PlayOneShot(HurtClip);
            Destroy(gameObject);
            playerMovements.TakeDamage(1);   
        }
       
    }
}
