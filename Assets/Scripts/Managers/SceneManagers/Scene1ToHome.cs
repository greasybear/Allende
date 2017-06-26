using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1ToHome : MonoBehaviour {

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            
            SceneManager.LoadScene("HomeBase", LoadSceneMode.Single);
        }
    }
}
