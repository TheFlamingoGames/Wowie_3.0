using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vc;


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
        player = GameObject.Find("Player");
        vc = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>(); ;
    }

    private void Start()
    {
        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            ReloadSceene();
        }
    }

    public GameObject GetPlayer() 
    {
        return player;
    }

    public void CheckPlayersDeath(GameObject dieded) 
    {
        if (dieded.name == player.name)
        {
            ReloadSceene();
        }
        else 
        {
            Destroy(dieded);
        }
    }

    private void ReloadSceene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetPlayerCharacter(GameObject newPlayer) 
    {
        player = newPlayer;
        vc.Follow = player.transform;
        player.SendMessage("SetParentForColliderCheck");
    }

    public void Win() 
    {
        Debug.Log("Win");
        ReloadSceene();
    }
}
