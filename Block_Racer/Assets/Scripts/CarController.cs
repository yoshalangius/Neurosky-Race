using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
    public float acceleration;
    public float rotationRate;
    public Rigidbody rigidbody;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;

    private float rotationVelocity;
    private float groundAngleVelocity;
	
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	
	void FixedUpdate ()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.up * -1, 3f))
        {
            rigidbody.drag = 1;

            // Vector3 forwardForce = transform.forward * acceleration * Input.GetAxis("Vertical");
            if (Input.GetButton("Fire1"))
            {
                Vector3 forwardForce = transform.forward * acceleration;

            forwardForce = forwardForce * Time.deltaTime * rigidbody.mass;

            rigidbody.AddForce(forwardForce);
            }
        }
        else
        {
            rigidbody.drag = 0;
        }

        Vector3 turnTorque = Vector3.up * rotationRate * Input.GetAxis("Horizontal");

        turnTorque = turnTorque * Time.deltaTime * rigidbody.mass;
        rigidbody.AddTorque(turnTorque);

        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis("Horizontal") * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        transform.eulerAngles = newRotation;
    }
}
