using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float movementSpeed;
    public float left;
    public float right;

    bool movingClockWise;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
            movingClockWise = true; 
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    public void move()
    {
        ChangeDir();
        if (movingClockWise)
        {
            rigidbody.angularVelocity = movementSpeed;
        }
        else
        {
            rigidbody.angularVelocity = movementSpeed * -1;

        }
    }
    public void ChangeDir()
    {
        if(transform.rotation.z > right)
        {
            movingClockWise = false;
        }
        if(transform.rotation.z < left)
        {
            movingClockWise = true;            
        }
    }

}
