using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    private float SmoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] float LeftLimit;
    [SerializeField] float RightLimit;
    [SerializeField] float BottomLimit;
    [SerializeField] float TopLimit;

    void LateUpdate() // Changed from Update to LateUpdate
    {
        Vector3 targetPosition = player.position + offset;

        // Clamp the target position BEFORE smoothing
        targetPosition = new Vector3
        (
            Mathf.Clamp(targetPosition.x, LeftLimit, RightLimit),
            Mathf.Clamp(targetPosition.y, BottomLimit, TopLimit),
            targetPosition.z
        );

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
    }
}