using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerZone : MonoBehaviour
{
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "tower") {
            Animator towerAnimator = other.gameObject.GetComponent<Animator>();
            towerAnimator.SetBool("Powered", true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "tower") {
            Animator towerAnimator = other.gameObject.GetComponent<Animator>();
            towerAnimator.SetBool("Powered", false);
        }
    }
}
