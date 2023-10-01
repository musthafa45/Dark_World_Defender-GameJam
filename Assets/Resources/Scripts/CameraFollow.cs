using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //public Vector3 offset;
    [SerializeField] private Transform player;
    //private Vector3 offset = new Vector3(0f,0f,-10f);
    [SerializeField]private Vector3 offset;
    private float SmoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] float LeftLimit;
    [SerializeField] float RightLimit;
    [SerializeField] float BottomLimit;
    [SerializeField] float TopLimit;


    void Start()
    {

    }


    void Update()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, LeftLimit, RightLimit),
            Mathf.Clamp(transform.position.y, BottomLimit, TopLimit),
            transform.position.z
        );
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //top Boundary
        Gizmos.DrawLine(new Vector2(LeftLimit, TopLimit), new Vector2(RightLimit, TopLimit));
        //Right Boundary
        Gizmos.DrawLine(new Vector2(RightLimit, TopLimit), new Vector2(RightLimit, BottomLimit));
        //Bottom Boundary
        Gizmos.DrawLine(new Vector2(RightLimit, BottomLimit), new Vector2(LeftLimit, BottomLimit));
        //Left Boundary
        Gizmos.DrawLine(new Vector2(LeftLimit, BottomLimit), new Vector2(LeftLimit, TopLimit));
    }

}
