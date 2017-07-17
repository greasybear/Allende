using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRockets : MonoBehaviour {

    public int damage;
    float timer;
    public GameObject explosion;
    public float radius = 5f;
    public Collider[] damageRadius;

    void splashDamage()
    {
        damageRadius = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider guy in damageRadius)
        {
            if (guy.tag == "Player")
            {
                guy.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage / 2);
            }
            if (guy.tag == "Enemy")
            {
                guy.gameObject.GetComponent<EnemyHealthSlowGun>().TakeDamageObject(damage / 2);
            }
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            splashDamage();
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(exp, 3);
        }

        else if (col.gameObject.tag != "Player")
        {
            splashDamage();
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
    }
}
