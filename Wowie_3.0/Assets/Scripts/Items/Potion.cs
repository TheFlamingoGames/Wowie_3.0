using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    public void UsePotion() 
    {
        FindObjectOfType<AudioManager>().Play("Poke");
        Destroy(gameObject);
    }
}
