using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Character
{

    public override void CollisionDetected(GameObject collision)
    {
        if (collision.name == gameObject.name) return;
        base.CollisionDetected(collision);    

        if (collision.name.Contains("Spike")) 
        {
            Die();
            return;
        }

        ColorCode c;
        try
        {
            c = collision.GetComponent<ColorCode>();
        }
        catch 
        {
            return;
        }
        if (collision.CompareTag("Character"))
        {
            if (_color.CompareColor(_color.GetColor(), c.GetColor()))
            {
                GameManager.instance.SetPlayerCharacter(collision);
                Die();
            }
            else 
            {
                collision.SendMessage("Die");
            }
        }
    }
}
