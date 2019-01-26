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
    RaycastHit2D hit;
    Vector2 rayPos;
    Person person;

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
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(restartSceneIndex);
    }
}
