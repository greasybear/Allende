using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SquadManger : MonoBehaviour {

    public GameObject[] squadMembers;
    public GameObject alarmer;
    public Transform alarm;
    public bool alarmSounded = false;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Image alarmImage;


    void BreakPatrol()
    {   if (!alarmSounded)
        {
            alarmer.GetComponent<Patrol>().breakPatrol = true;
            alarmer.GetComponent<EnemyMovmentSlow>().alarmSearch = false;
            alarmer.GetComponent<EnemyMovmentSlow>().nav.SetDestination(alarm.position);
        }
    foreach (GameObject enemy in squadMembers)
            {
             
                enemy.GetComponent<Patrol>().breakPatrol = true;            
            }
    }

    void Update()
    {
        if (alarmSounded)

        {
            alarmImage.color = flashColour;
        }
     
        if (alarmer !=null)
        {
            float dist = Vector3.Distance(alarm.position, alarmer.transform.position); //getting null reference here, MAYBE USE TRIGGER BOOL
            if (dist<3f)
            { alarmSounded = true; }
        }
        
        if (alarmSounded)
        {
            alarmer.GetComponent<EnemyMovmentSlow>().alarmSearch = true;
            alarmer.GetComponent<EnemyMovmentSlow>().FindPlayer();
        }


        foreach (GameObject enemy in squadMembers)
        {
            if (enemy.GetComponent<Patrol>().breakPatrol)
                {


                    BreakPatrol();
                }
            }
            

        

    }
}
