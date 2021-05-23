using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCcontroller : MonoBehaviour
{
    private Camera mainCam;
    public float speed; 
    private Vector3 targetPos;
    private float maxDist;
    public GameObject targetPosIndicator;
    bool facingLeft = false;
    Animator animator;

    Transform selected;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        targetPos = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RightClick();
        } 
        if (Input.GetMouseButtonDown(1)) {
            LeftClick();
        }

        // move towards target
        bool isMoving = (Vector2.Distance(transform.position, targetPos) > maxDist);
        animator.SetBool("Moving", isMoving);
        if (isMoving) {
            // flip
            if ((transform.position.x > targetPos.x) == facingLeft) {
                facingLeft = !facingLeft;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
    
    void RightClick() {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        int UImask = (LayerMask.GetMask("UI"));
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 20.0f, UImask);
        if (hit) {
            Transform objectHit = hit.transform;
            // get root tower / enemy
            while(!(objectHit.transform.tag == "tower" || objectHit.transform.tag == "enemy")) {
                objectHit = objectHit.parent;
            }
            Select(objectHit);
        }
    }

    void LeftClick() {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        SetTargetPos(mousePos, 0.1f);
        Instantiate(targetPosIndicator, targetPos, Quaternion.identity);
    }

    void SetTargetPos(Vector3 pos, float dist) {
        targetPos = pos;
        targetPos.z = 0.0f;
        maxDist = dist;
    }

    void Select(Transform newSelect) {
        if (selected != null) {
            Deselect(selected);
        }
        var highlight = newSelect.GetChild(0);
        highlight.GetComponent<SpriteRenderer>().enabled = true;
        if(newSelect.tag == "tower") {
            newSelect.GetChild(1).GetComponent<Canvas>().enabled = true;
        }
        selected = newSelect;
    }

    void Deselect(Transform selected) {
        var highlight = selected.GetChild(0);
        highlight.GetComponent<SpriteRenderer>().enabled = false;
        selected.GetChild(1).GetComponent<Canvas>().enabled = false;
    }
}
