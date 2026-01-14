using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnClickSinglePlayer()
    {
        Debug.Log("Loading singleplayer game");
        SceneManager.LoadScene("SinglePlayer00");
    }

    public void OnClickMultiplayer()
    {
        Debug.Log("Loading multiplayer game");
        SceneManager.LoadScene("Multiplayer_Launcher");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
