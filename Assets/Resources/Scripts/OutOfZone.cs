using UnityEngine;

public class OutOfZone : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Bullet")) {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ShotGunBullet")) {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ghost")) {
            Destroy(collision.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Bullet")) {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ShotGunBullet")) {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ghost")) {
            Destroy(collision.gameObject);
        }
    }
}
