using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFour : MonoBehaviour {

    bool close;
    public static bool c4Aquired = false;
    Transform player;

    void Awake()
    { player = GameObject.FindGameObjectWithTag("Player").transform; }
    

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist < 2f)
        { close = true; }
        else { close = false; }

        if (close && Input.GetKeyDown(KeyCode.E))
        {
            c4Aquired = true;
            Destroy(gameObject);
        }
    }


}
