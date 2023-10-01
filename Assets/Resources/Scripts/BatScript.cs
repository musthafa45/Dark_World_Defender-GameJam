using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BatScript : MonoBehaviour
{
   [SerializeField]GameObject AttackBox;
   
    public int Damage;
    public Animator PlayerAnimator;

    public AudioSource PlayerAudio;
    public AudioClip PlayerMeleeClip;
    void Start()
    {
        AttackBox.GetComponent<Collider2D>().enabled= false;
    }
    private void Attack()
    {
        PlayerAnimator.SetTrigger("Attack");
        StartCoroutine(DoAttack());
    }
    IEnumerator DoAttack()
    {
        PlayerAudio.PlayOneShot(PlayerMeleeClip);
        AttackBox.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(.5f);
        AttackBox.GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

    }
 

  
}
