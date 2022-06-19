using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public BallMovement movement;
    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle") {
            movement.enabled = false;
        }
    }
}
