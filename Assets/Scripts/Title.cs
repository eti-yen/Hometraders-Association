using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public int startSceneIndex;
    public int stageSceneIndex;
    public GameObject insturction;
    bool startGame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(stageSceneIndex);
            }
                
        }
    }
    public void StartButton()
    {
        insturction.SetActive(true);
        startGame = true;
       
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void BackToStartButton()
    {
        SceneManager.LoadScene(startSceneIndex);
    }
}
