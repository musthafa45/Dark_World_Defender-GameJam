using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float Speed;
    Transform Player;

    public AudioSource BulletAudio;
    public AudioClip SpawnClip;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   
    void Update()
    {
        BulletAudio.PlayOneShot(SpawnClip);
        transform.position = Vector2.MoveTowards(transform.position,Player.position,Speed * Time.deltaTime);
        Destroy(gameObject, 5);
    }
}
