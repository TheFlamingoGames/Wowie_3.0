using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Character
{
    int zigzag = 0;
    protected override void PredeterminedMovement()
    {
        if ((Vector2)transform.position == _currentPos)
        {
            zigzag *= -1;
            Vector2 newPos = new Vector2(zigzag, 0);
            _currentPos += newPos;
        }
    }

    public override void CollisionDetected(GameObject collision)
    {
        if (collision.name == gameObject.name) return;
        Debug.Log(collision.name);
        base.CollisionDetected(collision);

        if (collision.name.Contains("Gem"))
        {
            _colliderChecker.transform.position = _oldPos;
            _currentPos = _oldPos;
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
