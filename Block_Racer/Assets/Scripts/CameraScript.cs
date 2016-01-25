using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float distanceUp;
    public float distanceBack;
    public float minimumHeight;

    private Vector3 positionVelocity;


    void FixedUpdate()
    {
        Vector3 newPosition = target.position + (target.forward * distanceBack);
        newPosition.y = Mathf.Max(newPosition.y + distanceUp, minimumHeight);

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref positionVelocity, 0.18f);

        Vector3 focalPoint = target.position + (target.forward * 5);
        transform.LookAt(focalPoint);
    }
}
