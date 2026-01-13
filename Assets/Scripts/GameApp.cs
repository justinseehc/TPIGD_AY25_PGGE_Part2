using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE.Patterns;
using UnityEngine.SceneManagement;

public class GameApp : Singleton<GameApp>
{
    public AmbientSound mAmbientSound;
    
    void Start()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        
    }
}
