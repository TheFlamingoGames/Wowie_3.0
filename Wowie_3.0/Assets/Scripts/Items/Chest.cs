using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Item
{
    [SerializeField] GameObject item;
    [SerializeField] ColorCode.Colors spawnColor = ColorCode.Colors.WHITE;

    public void OpenChest() 
    {
        GameObject newItem = Instantiate(item, transform);
        newItem.transform.parent = null;
        newItem.transform.localScale = new Vector3(5, 5, 5);
        newItem.GetComponent<ColorCode>().InitializeSpriteRendererIfYouForgotAboutItYouFool();
        newItem.GetComponent<ColorCode>().SetColor(spawnColor);
        Destroy(gameObject);
    }
}
