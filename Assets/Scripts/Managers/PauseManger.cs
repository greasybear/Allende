using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManger : MonoBehaviour {

    public GameObject PausePanel;
    public bool isPaused;
    public Button resumeGame;
    public Button exitGame;


    void Start()
    {
        
        isPaused = false;
        Button btn1 = resumeGame.GetComponent<Button>();
        Button btn2 = exitGame.GetComponent<Button>();
        btn1.onClick.AddListener(SwitchPause);
        btn2.onClick.AddListener(QuitGame);


    }
    void QuitGame()
    {  Application.Quit(); }

    void Update()
    {
        if (isPaused)
        {
            PauseGame(true);
        }
        else {
            PauseGame(false);
        }
        if (Input.GetButtonDown("Cancel"))
        {
            SwitchPause();
        }


    }
    void PauseGame(bool state)
    {
        if (state)
        {
            Time.timeScale = 0.0f; //paused
        }
        else {
            Time.timeScale = 1.0f; //unpaused
            PausePanel.SetActive(state);
        }
        PausePanel.SetActive(state);
    }
    public void SwitchPause()
    {
        if (isPaused)
        {
            isPaused = false; //Changes the value
        }
        else
        {
            isPaused = true;
        }
    }
}
