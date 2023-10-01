using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunMag : MonoBehaviour
{
    public int ShotGunAmmoToAdd;
    public AudioSource AmmoSource;
    public AudioClip Reload;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            AmmoSource.PlayOneShot(Reload);
            SHOTGUN.CurrentAmmo += ShotGunAmmoToAdd;
            Destroy(gameObject);
        }
    }
}
