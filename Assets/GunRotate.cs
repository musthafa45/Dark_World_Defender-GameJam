using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        Vector3 gunPos = Camera.main.ScreenToWorldPoint(transform.position);
        mousepos.x = mousepos.x - gunPos.x;
        mousepos.y = mousepos.y - gunPos.y;
        float GunAngle = Mathf.Atan2(mousepos.y, mousepos.x)* Mathf.Rad2Deg;
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(180f, 0f, -GunAngle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f,0f, GunAngle));
        }
    }
}
