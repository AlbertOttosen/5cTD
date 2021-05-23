using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateColorOnSpawn : MonoBehaviour
{
    void Start()
    {
        var palette = GameObject.FindGameObjectWithTag("palette").GetComponent<PaletteController>();
        GetComponent<SpriteRenderer>().color = palette.GetColor(gameObject.tag);
    }
}
