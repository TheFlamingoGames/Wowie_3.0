using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] GameObject deathButton;

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
        virtualCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>(); ;
        deathButton = GameObject.Find("DeathButton");
            
    }

    private void Start()
    {
        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            ReloadScene();
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
            AudioManager.instance.Play("PlayerDeath");
            //FindObjectOfType<AudioManager>().Play("PlayerDeath");
            Destroy(dieded);
            deathButton.GetComponent<Animator>().SetTrigger("Show");
        }
        else 
        {
            AudioManager.instance.Play("CharacterDeath");
            //FindObjectOfType<AudioManager>().Play("CharacterDeath");
            Destroy(dieded);
        }
    }

    public void ReloadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetPlayerCharacter(GameObject newPlayer) 
    {
        player = newPlayer;
        virtualCamera.Follow = player.transform;
        player.SendMessage("SetParentForColliderCheck");
    }

    public void Win() 
    {
        NextScene();
    }

    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
