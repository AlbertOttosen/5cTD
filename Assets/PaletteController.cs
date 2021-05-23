using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaletteController : MonoBehaviour
{
    public Color testColorValue;
    public Color[] palette;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            string tag = "col_"+i.ToString();
            palette[i].a = 1F;
            Color new_color = palette[i];
            //new_color.a = 1F;
            SetColor(tag, new_color);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        testColorValue.a = 1;
        SetColor("col_3", testColorValue);
    }

    void SetColor(string tag, Color color)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject item in objects)
        {
            SpriteRenderer renderer = item.GetComponent<SpriteRenderer>();
            Image image = item.GetComponent<Image>();
            Text text = item.GetComponent<Text>();
            LineRenderer line = item.GetComponent<LineRenderer>();
            if (renderer != null) {
                renderer.color = color;
            } else if (image != null) {
                image.color = color;
            } else if (text != null) {
                text.color = color;
            } else if (line != null) {
                line.startColor = color;
                line.endColor = color;
            }
            
        }
        if (tag == "col_2") {
            Camera.main.backgroundColor = color;
        }
        int idx = tag[4]-'0';
        palette[idx] = color;
    }

    public Color GetColor(string tag) {
        int idx = tag[4]-'0';
        return palette[idx];
    }
}
