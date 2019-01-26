using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public int startSceneIndex;
    public int stageSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton()
    {
        SceneManager.LoadScene(stageSceneIndex);
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
