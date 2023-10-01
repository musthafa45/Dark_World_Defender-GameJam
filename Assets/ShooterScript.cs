using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
  public GameObject Bullet;
    public Transform start;
    void Start()
    {
        
    }


    void Update()
    {
        Vector3 gunPos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(gunPos.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x,180,transform.rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }
   void Shooting()
    {
        GameObject shoot = Instantiate(Bullet, start.transform.position, start.transform.rotation);
        Destroy(shoot,5f);
    }
}
