using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AKM: MonoBehaviour
{
    //Ammo
    public static int CurrentAmmo;
    public int MaxAmmo;
    
    //Bullet
    public GameObject Bullet;
    public Transform ShotPoint;

    //TimeBtw
    private float TimeBtwShots;
    public float StartBtwShot;
    public float bulletSpeed;
    //Ammo Text
    public Text Ammotext;

    //Audio
    public AudioSource PlayerAudio;
    public AudioClip PlayerAkmShotClip;
    public AudioClip OutOfAmmoClip;

    private Vector3 difference;

    private void Start()
    {
        CurrentAmmo = MaxAmmo;
    }
    private void Update()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if(difference.x > 0){ //Right side on Cursor
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ /*+ OffSet*/);
        }
       
        if (difference.x < 0) { //Leftside mouse point
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 180);
        }

        Ammotext.text = CurrentAmmo.ToString();

        if (TimeBtwShots <= 0) {

            if (Input.GetMouseButtonDown(0) && CurrentAmmo > 0) {

                PlayerAudio.PlayOneShot(PlayerAkmShotClip);

                Shoot();

                TimeBtwShots = StartBtwShot;
                CurrentAmmo--;

                Ammotext.text = CurrentAmmo.ToString();
            }

            if(Input.GetMouseButtonDown(0) && CurrentAmmo <= 0) {
                PlayerAudio.PlayOneShot(OutOfAmmoClip);
            }

        }
        else {
            TimeBtwShots -= Time.deltaTime;
        }

    }
 
    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShotPoint.position, ShotPoint.rotation);
        if(difference.x > 0) {
            BulletIns.GetComponent<Rigidbody2D>().AddForce(ShotPoint.transform.right * bulletSpeed);
        }
        else if (difference.x < 0) {
            BulletIns.GetComponent<Rigidbody2D>().AddForce(-ShotPoint.transform.right * bulletSpeed);
        }
        
    }
    
}