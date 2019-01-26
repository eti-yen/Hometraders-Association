using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Camera mainCamera;
    public int restartSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        print("here");
    }

    // Update is called once per frame
    void Update()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.name);
        }
        else
        {

        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(restartSceneIndex);
    }
}
