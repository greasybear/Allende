using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFour : MonoBehaviour {

    bool close;
    public bool c4Aquired = false;

    void OnTriggerEnter()
    { close = true; }

    void OnTriggerExit()
    { close = false; }

    void Update()
    {
        if (close && Input.GetKeyDown(KeyCode.E))
        {
            c4Aquired = true;
            Destroy(gameObject);
        }
    }


}
