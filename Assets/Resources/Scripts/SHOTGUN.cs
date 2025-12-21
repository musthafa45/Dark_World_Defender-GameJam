using UnityEngine;

public class SHOTGUN : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShotPoint;

    private float TimeBtwShots;
    public float StartBtwShot;
    public float bulletSpeed;

    public AudioSource PlayerAudio;
    public AudioClip PlayerShotGunShotClip;
    public AudioClip OutOfAmmoClip;

    private Vector3 difference;


    private void Update()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (difference.x > 0) { //Right side on Cursor
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ /*+ OffSet*/);
        }

        if (difference.x < 0) { //Leftside mouse point
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 180);
        }

        if (TimeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0) && AmmoManager.Instance.GetShotgunAmmoCount() > 0)
            {
                PlayerAudio.PlayOneShot(PlayerShotGunShotClip);
                Shoot();
                TimeBtwShots = StartBtwShot;
                AmmoManager.Instance.TryUseShotgunAmmo(1);
            }
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && AmmoManager.Instance.GetShotgunAmmoCount() <= 0)
        {
            PlayerAudio.PlayOneShot(OutOfAmmoClip);
        }
    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShotPoint.position, ShotPoint.rotation);
        if (difference.x > 0) {
            BulletIns.GetComponent<Rigidbody2D>().AddForce(ShotPoint.transform.right * bulletSpeed);
        }
        else if (difference.x < 0) {
            BulletIns.GetComponent<Rigidbody2D>().AddForce(-ShotPoint.transform.right * bulletSpeed);
        }
    }

}