using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour {

    public int damage;
    float timer;
    public GameObject explosion;
    bool exploding;
    Renderer render;

    
    void OnCollisionEnter(Collision col)
    {
      //  render = GetComponent<Renderer>();

        if (col.gameObject.tag == "Enemy")
        {
            exploding = true;
            col.gameObject.GetComponent<EnemyHealthSlowGun>().TakeDamageObject(damage);
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp, 3);
            //render.enabled = false;
            Destroy(gameObject);
            //spawn particle system
        }
        
        
        
        
        else if (col.gameObject.tag != "Player")
            {
            exploding = true;
            Destroy(gameObject);
            //spawn particle sysetem
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            //render.enabled = false;
            Destroy(exp, 3);
            Destroy(gameObject, 3);
        }
    }


    //void OnTriggerEnter(Collider enemy)
    //{
    //    if (enemy.gameObject.tag == "Enemy")
    //    {
    //        if (exploding)
    //        { enemy.gameObject.GetComponent<EnemyHealthSlowGun>().TakeDamageObject(damage); }

    //    }

    //}



    void Update()
    {
            timer += Time.deltaTime;

            if (timer > 5)
            { Destroy(gameObject); }
        
    }

}
