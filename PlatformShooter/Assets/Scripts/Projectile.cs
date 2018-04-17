using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy1")
        {
            var target = other.gameObject;
            target.GetComponent<EnemyMotor>().TakeEnemeDamage();
        }

        Destroy(gameObject);
    }
}

