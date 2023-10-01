using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SHOTGUN : MonoBehaviour
{
    public static int CurrentAmmo;
    public int MaxAmmo;
    public int ReloadAmmo;

    public float OffSet;
    public GameObject Bullet;
    public Transform ShotPoint;

    private float TimeBtwShots;
    public float StartBtwShot;
    public float bulletSpeed;

    public Text Ammotext;

    public AudioSource PlayerAudio;
    public AudioClip PlayerShotGunShotClip;
    public AudioClip OutOfAmmoClip;
    public static bool isRight;

    public SpriteRenderer ShotGun;
    public PlayerMovements playerMovements;
    private void Start()
    {
        CurrentAmmo = MaxAmmo;
        ShotGun = GetComponent<SpriteRenderer>();
        playerMovements = GetComponent<PlayerMovements>();
    }
    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + OffSet);

        if (rotationZ < 89f && rotationZ > -89)
        {
            Debug.Log("Right");
            ShotGun.flipY = false;
            isRight = true;
        }
        else
        {
            Debug.Log("Left");
            ShotGun.flipY = true;
            isRight = false;
        }
        Ammotext.text = CurrentAmmo.ToString();
        if (TimeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0) && CurrentAmmo > 0)
            {
                PlayerAudio.PlayOneShot(PlayerShotGunShotClip);
                Shoot();
                TimeBtwShots = StartBtwShot;
                CurrentAmmo--;
                Ammotext.text = CurrentAmmo.ToString();
            }
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && CurrentAmmo <= 0)
        {
            PlayerAudio.PlayOneShot(OutOfAmmoClip);
        }
    }
  




    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShotPoint.position, ShotPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * bulletSpeed);
    }

}