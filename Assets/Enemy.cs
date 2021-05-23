using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startingHp;
    private float hp;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hp = startingHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage) {
        hp -= damage;
        if (hp <= 0.0f) {
            Die();
        }
    }

    void Die() {
        GetComponent<MoveAlongPath>().speed = 0;
        GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("HealthAndEnergy").GetComponent<HealthAndEnergy>().GainEnergy(15);
        animator.Play("DeathAnimation");
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("DeathAnimationEnded"))
        {
            Destroy(gameObject);
        }
    }
}
