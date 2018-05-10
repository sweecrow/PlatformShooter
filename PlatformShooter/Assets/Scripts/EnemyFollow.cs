using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.Networking;

public class EnemyFollow : NetworkBehaviour
{

    public GameObject target;
    public float EnemySpeed;

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player1");
    }

	void Update ()
    {
        Vector3 targetDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
        transform.Translate(Vector3.up * Time.deltaTime * EnemySpeed);
    }
}