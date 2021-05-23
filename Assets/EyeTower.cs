using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTower : MonoBehaviour
{
    public float baseDamage;
    public float baseThickness;
    public float damage;
    private Transform source;
    private LineRenderer laser;
    private List<GameObject> targetList = new List<GameObject>();
    private Transform currentTarget;
    private Animator animator;

    private float timeSinceShot = 0.0f;
    public float coolDown = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject prefab = transform.GetChild(2).gameObject;
        GameObject laserObject = Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
        laser = laserObject.GetComponent<LineRenderer>();
        source = transform.GetChild(3);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetList.Count != 0 && animator.GetBool("Powered")) {
            if (currentTarget == null) {
                SetNewTarget(targetList[0].transform);
            }
            laser.enabled = true;
            laser.SetPosition(0, source.position);
            laser.SetPosition(1, currentTarget.position);
        } else {
            laser.enabled = false;
        }

        timeSinceShot += Time.deltaTime;
        if (timeSinceShot >= coolDown && targetList.Count != 0 && animator.GetBool("Powered")) {
            // apply damage
            currentTarget.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            IncreaseDamage();
            timeSinceShot = 0.0f;
        }
    }
    
    void SetNewTarget(Transform newTarget) {
        damage = baseDamage;
        currentTarget = newTarget;
        laser.widthMultiplier = baseThickness;
    }

    void IncreaseDamage() {
        damage *= 1.1f;
        laser.widthMultiplier += 0.01f;
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
