using UnityEngine;
using System.Collections;

public class ThrusterScript : MonoBehaviour
{

    public float thrusterStrength;
    public float thrusterDistance;
    public Transform[] thrusters;
    public Rigidbody rigidbody;

    void start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        foreach (Transform thruster in thrusters)
        {
            Vector3 downwardForce;
            float distancePrecentage;
            if (Physics.Raycast(thruster.position, thruster.up * -1, out hit, thrusterDistance))
            {
                distancePrecentage = 1- (hit.distance / thrusterDistance);

                downwardForce = transform.up * thrusterStrength * distancePrecentage;

                downwardForce = downwardForce * Time.deltaTime * rigidbody.mass;

                rigidbody.AddForceAtPosition(downwardForce, thruster.position);
            }
        }
    }
}
