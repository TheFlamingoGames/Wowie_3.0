using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColorCode : MonoBehaviour
{
    public enum Colors
    {
        WHITE,
        BLUE,
        RED,
        GREEN
    }

    [SerializeField] Colors _color = Colors.WHITE;

    SpriteRenderer _spriteRendered;

    private void Start()
    {
        _spriteRendered = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SetColor(Colors c) 
    {
        _color = c;
        RecolorSprite();
    }

    public Colors GetColor() 
    {
        return _color;
    }

    private void RecolorSprite() 
    {
        switch (_color) 
        {
            case Colors.BLUE:
                _spriteRendered.color = new Color(0f, 0f, 1f, 1f);
                break;
            case Colors.RED:
                _spriteRendered.color = new Color(1f, 0f, 0f, 1f);
                break;
            case Colors.GREEN:
                _spriteRendered.color = new Color(0f, 1f, 0f, 1f);
                break;
            case Colors.WHITE:
                _spriteRendered.color = new Color(1f, 1f, 1f, 1f);
                break;
        }
        
    }

    private void Update()
    {
        RecolorSprite();
    }

    public bool CompareColor(Colors firstColor, Colors secondColor) 
    {
        /*
         * False means firstColor won
         * True means secondColor won
         */

        if (firstColor == secondColor) return true;
        if (firstColor == Colors.WHITE) return true;
        if (secondColor == Colors.WHITE) return false;

        if (firstColor == Colors.BLUE) 
        {
            if (secondColor == Colors.RED) return false;
            if (secondColor == Colors.GREEN) return true;
        }

        if (firstColor == Colors.RED)
        {
            if (secondColor == Colors.GREEN) return false;
            if (secondColor == Colors.BLUE) return true;
        }

        if (firstColor == Colors.GREEN)
        {
            if (secondColor == Colors.BLUE) return false;
            if (secondColor == Colors.RED) return true;
        }

        return true;
    }
}
