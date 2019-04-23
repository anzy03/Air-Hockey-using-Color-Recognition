using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceanChanger : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject gameCanvas;
    Scene currentScene;
    int sceneBuildIndex;

    // Start is called before the first frame update
    void Start()
    {
        int width = 1080; 
        int height= 1920; 
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        Screen.SetResolution (width , height, isFullScreen );
        currentScene = SceneManager.GetActiveScene();
        sceneBuildIndex = currentScene.buildIndex;

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        /* currentScene = SceneManager.GetActiveScene();
        sceneBuildIndex = currentScene.buildIndex; */
        if(sceneBuildIndex == 1)
        {
            if(Input.GetKeyDown(KeyCode.Escape) && pauseCanvas.activeSelf == false )
            {
                Time.timeScale = 0;
                pauseCanvas.SetActive(true);
                gameCanvas.SetActive(false);
            }
            else if(Input.GetKeyDown(KeyCode.Escape) && pauseCanvas.activeSelf == true )
            {
                PauseExitButton();
            }
            else if(Input.GetKeyDown(KeyCode.Return) && pauseCanvas.activeSelf == true )
            {
                ResumeButton();
            }
        }
        else if(sceneBuildIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.Return) && sceneBuildIndex == 0)
            {
                StartButton();
            }

            if(Input.GetKeyDown(KeyCode.Escape)  && sceneBuildIndex == 0)
            {
                Application.Quit();
            }
        }
        
    }
    
    public void ResumeButton()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }
    public void PauseExitButton()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        SceneManager.LoadScene(0);
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
}
