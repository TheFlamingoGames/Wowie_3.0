using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

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

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            ReloadSceene();
        }

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
        player.SendMessage("SetParentForColliderCheck");
    }

    public void Win() 
    {
        Debug.Log("Win");
        ReloadSceene();
    }
}
