using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float speed;
    public float damage;
    public Transform target;
    private List<GameObject> targetList = new List<GameObject>();
    private Animator animator;
    public bool locked = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!locked && target != null && animator.GetBool("Powered")) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, target.position) < 0.1f) {
                animator.Play("Attack");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "enemy") {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
