using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    public float FireSpeed;

    void Awake()
    {
      
    }

    void Update()
    {
       transform.Translate(Vector2.right * FireSpeed * Time.deltaTime,Space.Self);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject,.5f);
    }
}
