using UnityEngine;

public class AkmMag : MonoBehaviour
{
    public int AkmAmmoToAdd;
    public AudioSource AmmoSource;
    public AudioClip Reload;

   
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            AmmoSource.PlayOneShot(Reload);
            AmmoManager.Instance.AddAkmAmmo(AkmAmmoToAdd);
            Destroy(gameObject);
        }
    }
}
