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
    SquadManger squadManager;
    public GameObject alarmSpawners;
    public Transform alarmSpawnPosition;
    float spawnTimer;
    public float timeBetweenSpawns = 3f;

   
    void Awake()
    { spawnTimer = Time.time + timeBetweenSpawns; }

    void BreakPatrol()
    {   if (!alarmSounded)
        {
            alarmer.GetComponent<Patrol>().breakPatrol = true;
            alarmer.GetComponent<EnemyMovmentSlow>().alarmSearch = false;
            alarmer.GetComponent<EnemyMovmentSlow>().nav.SetDestination(alarm.position);
        }
    foreach (GameObject enemy in squadMembers)
            {
             
                enemy.GetComponent<Patrol>().breakPatrol = true;            //null here
            }
    }

    void Update()
    {
        if (alarmSounded && spawnTimer < Time.time)
        {
            Instantiate(alarmSpawners, alarmSpawnPosition.position, alarmSpawnPosition.rotation);
            spawnTimer = Time.time + timeBetweenSpawns;
        }


        if (alarmSounded)

        {
            alarmImage.color = flashColour;
        }
     
        if (alarmer !=null)
        {
            float dist = Vector3.Distance(alarm.position, alarmer.transform.position); //getting null reference here, MAYBE USE TRIGGER BOOL
            if (dist<2f)
            { alarmSounded = true; }
        }
        
        if (alarmSounded && alarmer !=null)
        {
            alarmer.GetComponent<EnemyMovmentSlow>().alarmSearch = true; //null here
            alarmer.GetComponent<EnemyMovmentSlow>().FindPlayer();
        }

      
        foreach (GameObject enemy in squadMembers)
        {
                if (enemy.GetComponent<Patrol>().breakPatrol || alarmer.GetComponent<Patrol>().breakPatrol)  //null here
                {


                    BreakPatrol();
                }           
        }
    }
}
