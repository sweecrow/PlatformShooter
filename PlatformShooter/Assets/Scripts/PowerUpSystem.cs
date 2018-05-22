using UnityEngine;
using System.Collections;

public class PowerUpSystem : MonoBehaviour {

    public float multiplier = 1.1f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player1"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D player)
    {

        PlayerMotor stats = player.GetComponent<PlayerMotor>();
        stats.healthMax *= multiplier;

        Destroy(gameObject);
    }
}