using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
{
    bool IsShaking = false;
    [SerializeField]float ShakeAmount;
    Vector2 StartPos;

    public int MaxHealth = 10;
    public int CurrentHealth;

    public Rigidbody2D Rigidbody;
    void Start()
    {
        CurrentHealth = MaxHealth;
        Rigidbody = GetComponent<Rigidbody2D>();
        StartPos = transform.position;
    }

   
    void Update()
    {
        if (IsShaking)
        {
            transform.position = StartPos + UnityEngine.Random.insideUnitCircle * ShakeAmount;
        }

        if(CurrentHealth <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IsShaking = true;
            Destroy(collision.gameObject);
            TakeDamage(1);
            Invoke("StopShaking", 0.3f);
        }
        else if(collision.gameObject.CompareTag("HomingBullet"))
        {
            IsShaking = true;
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IsShaking = true;
            Destroy(collision.gameObject);
            TakeDamage(1);
            Invoke("StopShaking", 0.3f);
        }
        else if (collision.gameObject.CompareTag("HomingBullet"))
        {
            IsShaking = true;
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
    }
    void StopShaking()
    {
        IsShaking = false;
        transform.position = StartPos;
;    }
    public void TakeDamage(int Damage)
    {
        
        CurrentHealth -= Damage;


    }
}
