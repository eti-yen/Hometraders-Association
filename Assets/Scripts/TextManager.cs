using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
 
    public Camera mainCamera;
    public int restartSceneIndex;
    public int nextSceneIndex;
    public GameObject InfoText;
    public GameObject winText;
    public GameObject failText;
    public bool goal; //The goal from other class check
    bool win; //Whether the player can enter the next stage
    Text infoText;
    RaycastHit2D hit;
    Vector2 rayPos;
    Person person;
    float timer = 0; //Use to show win/fail
    public float timerMax = 300;
    bool showResult = false;

    // Start is called before the first frame update
    void Start()
    {
   
        infoText = InfoText.GetComponent<Text>();
        infoText.text = "Information";
    }

    // Update is called once per frame
    void Update()
    {
        rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        if (hit)
        {
            person = hit.transform.GetComponent<Person>();
            infoText.text = person.infoString;
        }
        else
        {
            infoText.text = "";
        }
        if (showResult == true)
        {
            timer += Time.deltaTime;
            
                
        }
        if (timer>= timerMax)
        {
            if (win)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                failText.SetActive(false);
            }
            timer = 0;
            showResult = false;
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(restartSceneIndex);
    }
    public void CheckButton()
    {
        win = goal;
        if (goal)
        {
            showResult = true;
            winText.SetActive(true);
        }
        else
        {
            showResult = true;
            failText.SetActive(true);
        }
    }
}
