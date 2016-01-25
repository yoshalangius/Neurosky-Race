using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float acceleration;
    public float rotationRate;
    public Rigidbody rigidbody;
    public Transform[] waypoints;
    public Transform Waypoint;

    public Transform objectToMoveTowards;
    public float speed;
    public float turnSpeed;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;

    private float rotationVelocity;
    private float groundAngleVelocity;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }


    void FixedUpdate()
    {
       
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.up * -1, 3f))
        {
            rigidbody.drag = 1;

            Vector3 forwardForce = transform.forward * acceleration ; /* make it work for the AI*/

            forwardForce = forwardForce * Time.deltaTime * rigidbody.mass ;

            rigidbody.AddForce(forwardForce);
        }
        else
        {
            rigidbody.drag = 0;
        }

        Vector3 turnTorque = Vector3.up * rotationRate; /* make it work for the AI*/

        turnTorque = turnTorque * Time.deltaTime * rigidbody.mass;
        rigidbody.AddTorque(turnTorque);

        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis("Horizontal") * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        transform.eulerAngles = newRotation;
    }

    void Update()
    {
        float ts = Mathf.Clamp01(turnSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(objectToMoveTowards.position - transform.position), ts);

        float s = Mathf.Clamp01(speed * Time.deltaTime);
        //transform.position += (objectToMoveTowards.position - transform.position).normalized * s;
        thrust();

        Debug.DrawLine(transform.position, objectToMoveTowards.position, Color.cyan);
    }

    void thrust()
    {
        Vector3 forwardForce = transform.forward * acceleration;

        forwardForce = forwardForce * Time.deltaTime * rigidbody.mass;

        rigidbody.AddForce(forwardForce);
    }
}
