using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour
{
    public static Color[] palette;
    public int activeColor;
    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(palette[activeColor]);
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (rend != null) { 
            rend.color = palette[activeColor];
        }
    }
}
