using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Character
{

    public override void CollisionDetected(GameObject collision)
    {

        if (collision.name == "Misc") 
        {
            Debug.Log("Misc");
            _colliderChecker.transform.position = oldPos;
            currentPos = oldPos;
        }
        base.CollisionDetected(collision);
    }
}
