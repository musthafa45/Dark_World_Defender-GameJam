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
    public float OffSet;
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

    public SpriteRenderer Gun;
    //[SerializeField]Transform Gun;
    //public float Gun_OffSet ;
    //Vector3 StartingSize;
    //Vector3 ArmStartingSize;
    public PlayerMovements playerMovements;
    public static bool isRight;
    private void Start()
    {
        CurrentAmmo = MaxAmmo;
        Gun = GetComponent<SpriteRenderer>();
        playerMovements = GetComponent<PlayerMovements>();  

    }
    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + OffSet);

        if(rotationZ < 89f && rotationZ > -89)//Flipping Gun
        {
            Debug.Log("Right");
            Gun.flipY = false;
            isRight = true;
        }
        else
        {
            Debug.Log("Left");
            Gun.flipY = true;
            isRight = false;
        }
       
        Ammotext.text = CurrentAmmo.ToString();

        if (TimeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0) && CurrentAmmo > 0)
                {
                    PlayerAudio.PlayOneShot(PlayerAkmShotClip);
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
        if(Input.GetMouseButtonDown(0) && CurrentAmmo <= 0)
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