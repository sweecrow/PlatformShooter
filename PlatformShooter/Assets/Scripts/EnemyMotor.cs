using UnityEngine;
using System.Collections;


public class EnemyMotor : MonoBehaviour
{

    public int healthMax = 30;
    public int healthCurrent;

    private Rigidbody2D rigidbody2d;

    public GameObject powerUpPrefab;
    public int powerUpNumer;

    void Awake()
    {
        healthCurrent = healthMax;
    }

    void Update()
    {
        if (healthCurrent <= 0)
        {
            powerUpNumer = Random.Range(1, 10);

            if(powerUpNumer < 3 || powerUpNumer > 8)
            {
                Instantiate(powerUpPrefab, transform.position + (transform.forward * 2), transform.rotation);
            }

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