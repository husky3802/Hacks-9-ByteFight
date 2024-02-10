using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    BoxCollider2D boxcollider2d;

    public LayerMask Ground_layermask;
    public float speed = 7.0f;
    public float jump = 7.0f;
    public int maxdoublejumps = 1;
    int doublejumps;
    float time = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        boxcollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime

        // Jump
        if (Input.GetKeyDown(KeyCode.W) && (isGrounded() || doublejumps >= 1))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jump);
            doublejumps--;
            Debug.Log(doublejumps);
        }


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

        //stops the sliding a bit on ground
        if (isGrounded() && (rigidbody2d.velocity.x < 1f && rigidbody2d.velocity.x > 0) || (rigidbody2d.velocity.x > -1f && rigidbody2d.velocity.x < 0))
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }

        //stops momentum in the air if you dont hold a direction
        if (!isGrounded() && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x * 0.98f, rigidbody2d.velocity.y);
        }

        // limit the number of jumps
        if (isGrounded() && doublejumps != maxdoublejumps)
        {            
            doublejumps = maxdoublejumps;
            Debug.Log(doublejumps);
        }
        
    }

    bool isGrounded()
    {
        RaycastHit2D raycasthit2d = Physics2D.BoxCast(rigidbody2d.position, boxcollider2d.bounds.size, 0f, Vector2.down, 0.3f, Ground_layermask);        
        return raycasthit2d.collider != null;
    }


}
