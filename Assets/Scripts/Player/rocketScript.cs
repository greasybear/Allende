using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour {

    public int damage;
    float timer;
    public GameObject explosion;
    Renderer render;
    public float radius = 10f;
    public Collider[] damageRadius;
    bool exploded;


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            exploded = true;            
            col.gameObject.GetComponent<EnemyHealthSlowGun>().TakeDamageObject(damage);
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);

           

            Destroy(gameObject);

            Destroy(exp, 3);
                     
        }
                
        else if (col.gameObject.tag != "Player")
            {

            exploded = true;

            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            
            Destroy(exp, 3);
            Destroy(gameObject);
        }
    }
    void Update()
    {
            timer += Time.deltaTime;

            if (timer > 5)
            { Destroy(gameObject); }

        damageRadius = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider badGuy in damageRadius)
           
           { if (badGuy.tag == "Enemy")
            {
                badGuy.gameObject.GetComponent<EnemyHealthSlowGun>().TakeDamageObject(damage);
            }
           }

    }

}
