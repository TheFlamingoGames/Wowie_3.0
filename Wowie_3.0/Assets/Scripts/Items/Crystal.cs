using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private GameObject _parent;

    public void SetParent(GameObject newParent) 
    {
        _parent = newParent;
    }

    public void GemDestroyed() 
    {
        _parent.SendMessage("GemDestroyed", gameObject);
        Destroy(gameObject);
    }
}
