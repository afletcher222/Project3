using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementWithAnim : MonoBehaviour
{
    public Transform[] waypoints;

    public int current = 0;

    public float speed = 7;
    public float waypointRadius = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(waypoints[current].position, transform.position) < waypointRadius)
        {
            current++;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].position, Time.deltaTime * speed);
    }
}
