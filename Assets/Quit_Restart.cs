using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_Restart : MonoBehaviour {

    void Update()
    {
        if (Input.GetButton("Cancel"))
        { Application.Quit(); }


        
        
    }
    public void RestartLevel()
    {
        if (Input.GetButton("Submit"))
          { SceneManager.LoadScene(0); }
    }



}
