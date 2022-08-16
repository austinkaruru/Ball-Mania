using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{   
    [SerializeField] private float spinSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, spinSpeed, 0f, Space.World);
    }
}
