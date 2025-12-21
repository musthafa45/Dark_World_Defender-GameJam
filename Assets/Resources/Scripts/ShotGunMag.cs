using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunMag : MonoBehaviour
{
    public int ShotGunAmmoToAdd;
    public AudioSource AmmoSource;
    public AudioClip Reload;
  
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            AmmoSource.PlayOneShot(Reload);
            AmmoManager.Instance.AddShotgunAmmo(ShotGunAmmoToAdd);
            Destroy(gameObject);
        }
    }
}
