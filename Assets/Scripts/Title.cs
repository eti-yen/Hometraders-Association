﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public int startSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startButton()
    {
        SceneManager.LoadScene(startSceneIndex);
    }
    public void exitButton()
    {
        Application.Quit();
    }
}