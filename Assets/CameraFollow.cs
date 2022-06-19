
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

     void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;

}
}
