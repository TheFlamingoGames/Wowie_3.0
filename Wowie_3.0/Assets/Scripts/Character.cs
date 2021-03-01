using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float tileSize = 1;

    protected GameObject _colliderChecker;
    protected Vector2 _currentPos;
    protected Vector2 _oldPos;

    protected ColorCode _color;

    void Start()
    {
        _currentPos = transform.position;
        _colliderChecker = GameObject.Find("ColliderCheck");
        _color = gameObject.GetComponent<ColorCode>();
    }


    void Update()
    {
        if (GameManager.instance.player.name != gameObject.name)
        {
            PredeterminedMovement();
        }
        else
        {
            CheckInputs();
        }
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, _currentPos, speed * Time.deltaTime);

        

        if ((Vector2)transform.position == _currentPos)
        {
            _oldPos = transform.position;
        }
    }

    //Programmend Movement
    protected virtual void PredeterminedMovement() 
    {

    }

    //Player Controlled Movement
    protected virtual void CheckInputs()
    {
        if (transform.position != _colliderChecker.transform.position) return;

        Vector2 newPos = _colliderChecker.transform.position;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) newPos.y += tileSize;
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) newPos.y -= tileSize;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) newPos.x -= tileSize;
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) newPos.x += tileSize;
        _colliderChecker.transform.position = newPos;

        _currentPos = newPos;
    }

    public void SetParentForColliderCheck()
    {
        _colliderChecker.SendMessage("SetParent", gameObject);
    }

    public virtual void CollisionDetected(GameObject collision)
    {

        if (collision.name.Contains("Open"))
        {
            Debug.Log("Open Door");
            ColorCode c = collision.GetComponent<ColorCode>();
            if (_color.GetColor() == c.GetColor())
            {
                Debug.Log("Same Color");
                GameManager.instance.Win();
            }
            else
            {
                Debug.Log("Different Color");
                _colliderChecker.transform.position = _oldPos;
                _currentPos = _oldPos;
            }
            return;
        }

        if (collision.name.Contains("Potion"))
        {
            _color.SetColor(collision.GetComponent<ColorCode>().GetColor());
            collision.SendMessage("UsePotion");
            return;
        }

        if (collision.name == "Walls")
        {
            _colliderChecker.transform.position = _oldPos;
            _currentPos = _oldPos;
            return;
        }
    }

    public Vector2 GetCurrentPos() 
    {
        return _currentPos;
    }

    public virtual void Die() 
    {
        GameManager.instance.CheckPlayersDeath(gameObject);
    }
}
