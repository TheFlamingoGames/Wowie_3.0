using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] List<GameObject> gems;
    [SerializeField] GameObject openDoor;

    void Start()
    {
        foreach (GameObject gem in gems) 
        {
            gem.SendMessage("SetParent", gameObject);
        }
    }

    public void GemDestroyed(GameObject gem) 
    {
        if (gems.Contains(gem))
        {
            gems.Remove(gem); 
        }

        if (gems.Count == 0) 
        {
            openDoor.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
