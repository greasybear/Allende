using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovmentSlow : MonoBehaviour {

    Transform player;
    PlayerHealth playerHealth;
    EnemyHealthSlowGun enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    EnemyAttackGun enemyAttack;
    public float waitingShots;
    UnityEngine.AI.NavMeshHit hit;   //this is saying its not used 
    public bool playerVisible;
    
    


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealthSlowGun>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttackGun>();
        waitingShots = Random.Range(2, 4);


    }
    void Start()
    {
        
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !enemyAttack.playerInRange)
        {
            nav.isStopped = false;
            nav.SetDestination(player.position);
         
        }

    }
    //IEnumerator waitIt()
    //{
    //    if (!enemyHealth.isDead)
    //    {
    //        yield return new WaitForSeconds(waitingShots);              TESTING W/OUT WAITING
    //        nav.isStopped = false;                             //error Here
    //        nav.SetDestination(player.position);          //error here
    //    }

    //}


    void Update()
    {   if (!enemyHealth.isDead)
        { UnityEngine.AI.NavMeshHit hit; }
        if (!nav.Raycast(player.position, out hit) && !enemyHealth.isDead)
        { playerVisible = true; }
        else {  playerVisible = false; }

        if (enemyAttack.playerInRange && !enemyHealth.isDead && playerVisible) //this is altered to include raycast condition
        {
            nav.isStopped = true;
            transform.LookAt(player);
            

        }
        else if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !enemyAttack.playerInRange)
        {
            //StartCoroutine(waitIt());   
            nav.isStopped = false;                             //error Here
            nav.SetDestination(player.position);
        }

        if (enemyHealth.isDead)
        {
            nav.enabled = false;
        }



    }

}


