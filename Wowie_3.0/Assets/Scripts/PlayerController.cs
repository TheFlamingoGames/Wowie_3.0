using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float tileSize = 1;

    GameObject _colliderChecker;
    Vector2 currentPos;
    Vector2 oldPos;


    void Start()
    {
        currentPos = transform.position;
        _colliderChecker = GameObject.Find("ColliderCheck");
        Debug.Log(_colliderChecker.name);
    }


    void Update()
    {

        if (GameManager.instance.player.name != gameObject.name)
        {
        }
        else
        {
            CheckInputs();
        }
        Move();
    } 

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, currentPos, speed * Time.deltaTime);

        if ((Vector2)transform.position == currentPos) 
        {
            oldPos = transform.position;
        }


    }
    private void CheckInputs() 
    {
        if (transform.position != _colliderChecker.transform.position) return;

        Vector2 newPos = _colliderChecker.transform.position;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) newPos.y+=tileSize;
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) newPos.y -= tileSize;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) newPos.x -= tileSize;
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) newPos.x += tileSize;
        _colliderChecker.transform.position = newPos;

        currentPos = newPos;
    }

    public void SetParentForColliderCheck() 
    {
        _colliderChecker.SendMessage("SetParent", gameObject);
    }

    public void CollisionDetected(GameObject collision) 
    {
        Debug.Log(collision.name);

        if (collision.name == "Walls") 
        {
            _colliderChecker.transform.position = oldPos;
            currentPos = oldPos;
        }
    }

}
