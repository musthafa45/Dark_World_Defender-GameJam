using DG.Tweening;
using UnityEngine;

public class BatScript : MonoBehaviour {
    public int Damage;
    public AudioSource PlayerAudio;
    public AudioClip PlayerMeleeClip;
    public Animator animator;
    public Collider2D DamageCollider;

    [Header("Attack Settings")]
    public float AttackCooldown = 0.5f; // Time between attacks
    private float lastAttackTime;

    private void Awake() {
        DamageCollider = GetComponent<Collider2D>();
        DamageCollider.enabled = false;
        lastAttackTime = -AttackCooldown; // Allow immediate first attack
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }
    }

    private void Attack() {
        // Check if enough time has passed since last attack
        if (Time.time < lastAttackTime + AttackCooldown) {
            return; // Still on cooldown
        }

        lastAttackTime = Time.time; // Record this attack time

        if (animator != null) animator.enabled = false;

        transform.DOLocalRotate(new Vector3(0, 0, -55), 0.1f).OnComplete(() => {
            EnableDamageCollider();
            transform.DOLocalRotate(new Vector3(0, 0, 30), 0.1f).OnComplete(() => {
                DisableDamageCollider();
                if (animator != null) animator.enabled = true;
            });
        });
    }

    public void EnableDamageCollider() {
        DamageCollider.enabled = true;
    }

    public void DisableDamageCollider() {
        DamageCollider.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            if (collision.gameObject.TryGetComponent(out EnemyMovements enemyMovements)) {
                enemyMovements.TakeDamage(Damage);
                PlayerAudio.PlayOneShot(PlayerMeleeClip);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            if (collision.gameObject.TryGetComponent(out EnemyMovements enemyMovements)) {
                enemyMovements.TakeDamage(Damage);
                PlayerAudio.PlayOneShot(PlayerMeleeClip);
            }
        }
    }
}