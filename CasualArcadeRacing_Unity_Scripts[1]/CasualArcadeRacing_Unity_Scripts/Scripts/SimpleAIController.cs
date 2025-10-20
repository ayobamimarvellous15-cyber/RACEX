using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleAIController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 20f;
    public float turnSpeed = 3f;

    int currentWP = 0;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (waypoints == null || waypoints.Length == 0) enabled = false;
    }

    void FixedUpdate()
    {
        if (waypoints == null || waypoints.Length == 0) return;
        Transform target = waypoints[currentWP];
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion look = Quaternion.LookRotation(dir);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, look, turnSpeed * Time.fixedDeltaTime));
        rb.AddForce(transform.forward * speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, target.position) < 5f)
            currentWP = (currentWP + 1) % waypoints.Length;
    }
}
