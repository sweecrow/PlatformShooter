using UnityEngine;
using System.Collections;

public class EnemyMotor : MonoBehaviour {

    public int healthMax = 30;
    public int healthCurrent;

    void Awake()
    {
        healthCurrent = healthMax;
    }

    void Update()
    {
        if (healthCurrent <= 0)
        {
            Destroy(gameObject);
            
        }

    }

    public void TakeEnemeDamage()
    {
        healthCurrent -= 10;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            Debug.Log("hit");
            FindObjectOfType<PlayerMotor>().TakeDamage();
        }
    }
}