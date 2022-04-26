using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    public float currentHealth;
    private Animator _animator;
    void Awake()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(7, 7);

    }

    public void takeDamage(float Damage)
    {
        currentHealth -= Damage;
        Debug.Log("enemy took damage");
        _animator.SetTrigger("getHit");
        if (currentHealth < 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Enemy Died");
        _animator.SetBool("Dead", true);
        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    // Update is called once per frame
    
}
