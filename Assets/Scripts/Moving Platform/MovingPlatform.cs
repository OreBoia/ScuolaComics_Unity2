using Unity.Mathematics;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Transform[] waypoints;
    public float speed = 5f;
    public int currentWaypointIndex = 0;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (math.distance(waypoints[currentWaypointIndex].position, transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        _rigidbody.velocity = (waypoints[currentWaypointIndex].position - transform.position).normalized * speed;
    }
}
