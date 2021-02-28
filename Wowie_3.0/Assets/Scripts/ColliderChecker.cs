using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderChecker : MonoBehaviour
{
    GameObject _parent;
    void Start()
    {
        SetParent(GameManager.instance.player);
    }

    void Update()
    {
        
    }

    public void SetParent(GameObject newParent) 
    {
        _parent = newParent;
        transform.position = _parent.GetComponent<Character>().GetCurrentPos();
        _parent.transform.position = _parent.GetComponent<Character>().GetCurrentPos();

        //_parent.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _parent.SendMessage("CollisionDetected", collision.gameObject);
    }
}
