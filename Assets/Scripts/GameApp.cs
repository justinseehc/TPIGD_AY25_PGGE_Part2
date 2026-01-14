using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE.Patterns;
using UnityEngine.SceneManagement;
using System;

public class GameApp : Singleton<GameApp>
{
    public AmbientSound mAmbientSound;
    public bool mPause;
    public Action<bool> mOnPause;
    
    void Start()
    {
        //SceneManager.LoadScene(1);
        GamePaused = false;
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePaused = !GamePaused;
        }
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded - Scene Index: " + scene.buildIndex + " Scene Name: " + scene.name);
        Debug.Log(mode);
    }

    public bool GamePaused
    {
        get { return mPause; }
        set
        {
            mPause = value;
            mOnPause?.Invoke(GamePaused);
            if (GamePaused)
            {
                Time.timeScale = 0;
            } else
            {
                Time.timeScale = 1;
            }
        }
    }
}
