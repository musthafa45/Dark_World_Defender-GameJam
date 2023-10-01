using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesColourControl : MonoBehaviour
{
    [SerializeField] private Color ChildrensColor;

    // Start is called before the first frame update
    void Start()
    {
        ChangeColour();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void ChangeColour()
    {
        foreach (SpriteRenderer c in GetComponents<Renderer>())
        {
            c.material.color = ChildrensColor;
        }
    }
}
