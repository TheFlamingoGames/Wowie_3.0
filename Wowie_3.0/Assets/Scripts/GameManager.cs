using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vc;
    [SerializeField] GameObject[] characters;
    int i = 0;

    public GameObject player;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        instance.player = characters[0];
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) 
        {
            i++;
            Debug.Log(i%2);

            player = characters[i % characters.Length];

            vc.Follow = player.transform;
            player.SendMessage("SetParentForColliderCheck");

        }
    }

    public GameObject GetPlayer() 
    {
        return player;
    }
}
