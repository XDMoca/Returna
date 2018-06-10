using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : MonoBehaviour {

    [SerializeField]
    private int Health;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ReceiveDamage(int damageReceived)
    {
        if (Health <= 0)
            return;

        Health -= damageReceived;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 1.5f);
    }
}
