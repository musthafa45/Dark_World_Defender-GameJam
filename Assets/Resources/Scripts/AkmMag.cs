using UnityEngine;

public class AkmMag : MonoBehaviour
{
    public int AkmAmmoToAdd;
    public AudioSource AmmoSource;
    public AudioClip Reload;
    void Start()
    {
       
    }

    
    void Update()
    {
        
    }
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            AmmoSource.PlayOneShot(Reload);
            AKM.CurrentAmmo += AkmAmmoToAdd;
            Destroy(gameObject);
        }
    }
}
