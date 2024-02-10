using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    // Update every fixed amount of times per second
    void FixedUpdate()
    {
        //go left
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
        }

        //go right
        if (Input.GetKey(KeyCode.D))
        {

            rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
        }


        //stops the sliding
        if ((rigidbody2d.velocity.x < speed && rigidbody2d.velocity.x > 0) || (rigidbody2d.velocity.x > -speed && rigidbody2d.velocity.x < 0))
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }
    }

}
