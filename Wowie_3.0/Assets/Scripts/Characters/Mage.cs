using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
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

        if (collision.name.Contains("Chest"))
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

        if (collision.name.Contains("Gem"))
        {
            if (_color.GetColor() == c.GetColor())
            {
                FindObjectOfType<AudioManager>().Play("Poke");
                collision.SendMessage("GemDestroyed");
                _colliderChecker.transform.position = _oldPos;
                _currentPos = _oldPos;
            }
            else
            {
                _colliderChecker.transform.position = _oldPos;
                _currentPos = _oldPos;
            }
            return;
        }
    }
}
