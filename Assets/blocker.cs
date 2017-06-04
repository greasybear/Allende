using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocker : MonoBehaviour {

    GameObject bullet;

	// Update is called once per frame
	void FixedUpdate () {
        bullet = GameObject.Find("bullet");

	}

    
        void OnCollisionEnter(Collision col)
    {
            if (col.gameObject.name == "bullet")
            { Destroy(bullet); }
        }
}
