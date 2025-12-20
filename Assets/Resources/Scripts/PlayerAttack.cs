using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    public UnityEvent OnBatPickup;
    public UnityEvent OnAkmPickup;
    public UnityEvent OnShotGunPickup;

    public AudioSource PlayerAudio;
    public AudioClip PlayerPickGun;
    public AudioClip HomingHurt;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BAT"))
        {
            PlayerAudio.PlayOneShot(PlayerPickGun);
            OnBatPickup.Invoke();
        }
        else if (collision.gameObject.CompareTag("AKM"))
        {
            PlayerAudio.PlayOneShot(PlayerPickGun);
            OnAkmPickup.Invoke();
        }
        else if (collision.gameObject.CompareTag("SHOTGUN"))
        {
            PlayerAudio.PlayOneShot(PlayerPickGun);
            OnShotGunPickup.Invoke();
        }
       
    }
    
}
