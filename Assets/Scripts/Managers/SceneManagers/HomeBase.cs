using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBase : MonoBehaviour {

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            SquadManger.alarmSounded = false;
            SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
        }
    }
}
