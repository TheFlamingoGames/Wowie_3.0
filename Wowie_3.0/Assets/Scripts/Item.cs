using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected ColorCode _color;

    void Start()
    {
        _color = gameObject.GetComponent<ColorCode>();
    }

    void Update()
    {
        
    }
}
