using UnityEngine;

public class BallMovement : MonoBehaviour
{   
    public Rigidbody rb;

    public float forwardForce = 100f;
    public float sidewaysForce = 500f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        rb.AddForce(0,0,forwardForce*Time.deltaTime);
        if(Input.GetKey("d")) 
        {
            rb.AddForce(sidewaysForce*Time.deltaTime,0,0);

        }
         if(Input.GetKey("a")) 
        {
            rb.AddForce(-sidewaysForce*Time.deltaTime,0,0);

        }
        
    }
}
