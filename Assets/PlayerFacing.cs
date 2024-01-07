using UnityEngine;

public class PlayerFacing : MonoBehaviour
{
    public Camera camera;
    void Start()
    {
      
    }

    
    void Update()
    {
        Vector3 point = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,1));
        float t = camera.transform.position.y / (camera.transform.position.y - point.y);
        Vector3 finalPoint = new Vector3(t *(point.x - camera.transform.position.x) + camera.transform.position.x,1,t * (point.z - camera.transform.position.z) + camera.transform.position.z);
        transform.LookAt(finalPoint, Vector3.up);
    }
}
