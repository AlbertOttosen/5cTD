using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTower : MonoBehaviour
{
    private List<GameObject> targetList = new List<GameObject>();
    private Hand hand;

    // Start is called before the first frame update
    void Start()
    {
        hand = transform.GetChild(2).GetComponent<Hand>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hand.target == null && targetList.Count != 0) {
            hand.target = targetList[0].transform;
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
            if (hand.target == other.transform) {
                hand.target = targetList[0].transform;
            }
        }
    }

    public void LockHand () {
        hand.locked = true;
    }
    public void UnlockHand() {
        hand.locked = false;
    }
}
