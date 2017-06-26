using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2Enter : MonoBehaviour {
    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            SquadManger.alarmSounded = false;
            SceneManager.LoadScene("Scene2", LoadSceneMode.Single);
        }
    }
    
}
