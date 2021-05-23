using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : MonoBehaviour
{
    private List<GameObject> targetList = new List<GameObject>();
    private float timeSinceShot = 0.0f;
    public float coolDown = 1.0f;
    public GameObject pellet;
    public Transform spawnPelletsFrom;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceShot += Time.deltaTime;
        if (timeSinceShot >= coolDown && targetList.Count != 0 && animator.GetBool("Powered")) {
            GameObject new_pellet = Instantiate(pellet, spawnPelletsFrom.position, Quaternion.identity);
            new_pellet.GetComponent<Pellet>().target = targetList[0].transform;
            timeSinceShot = 0.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "enemy") {
            targetList.Add(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (targetList.Contains(other.gameObject)) {
            targetList.Remove(other.gameObject);
        }
    }
}
