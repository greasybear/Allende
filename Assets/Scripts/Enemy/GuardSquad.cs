using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSquad : MonoBehaviour {
    public GameObject[] guardSquad;



    void BreakPatrol()
    {
        foreach (GameObject enemy in guardSquad)
        {
            enemy.GetComponent<Patrol>().breakPatrol = true;            //null here
        }
    }


	void Update () {

        foreach (GameObject enemy in guardSquad)
        {
            if (enemy.GetComponent<Patrol>().breakPatrol)  //null here
            {
                BreakPatrol();
            }
        }

    }
}
