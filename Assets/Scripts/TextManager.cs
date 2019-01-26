using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
 
    public Camera mainCamera;
    public int restartSceneIndex;
    public GameObject InfoText;
    Text infoText;

    // Start is called before the first frame update
    void Start()
    {
   
        infoText = InfoText.GetComponent<Text>();
        infoText.text = "Information";
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(restartSceneIndex);
    }
}
