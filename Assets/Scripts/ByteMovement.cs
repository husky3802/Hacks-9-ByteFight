using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using TMPro;

public class ByteMovement : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    BoxCollider2D boxcollider2d;
    Animator animator;
    Animation anim;



    public TMP_Text percentDisplay;
    public LayerMask Ground_layermask;
    public float speed = 7.0f;
    public float jump = 7.0f;
    public int maxdoublejumps = 1;
    int doublejumps;
    bool isAttacking = false;
    float time = 0;
    public float attackDelay = 0.7f;
    int percent = 0;

    //bool prevDirectionFacing = false; //false = left
    //bool animationLocked = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        boxcollider2d = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime

        percentDisplay.text = percent - percent % 10 + "." + percent % 10 + "%";

        // Jump
        if (Input.GetKeyDown(KeyCode.W) && (isGrounded() || doublejumps >= 1))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jump);
            doublejumps--;
            //Debug.Log(doublejumps);
        }


    }


    // Update every fixed amount of times per second
    void FixedUpdate()
    {

        if (isAttacking)
        {
            time += Time.fixedDeltaTime;
            if (time >= attackDelay)
            {
                isAttacking = false;
                time = 0;
            }
        }

        //attack
        if (Input.GetKey(KeyCode.R) && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("attack");
        }
        animator.SetFloat("velocity", rigidbody2d.velocity.x);


        if (rigidbody2d.velocity == new Vector2(0, 0))
        {
            animator.SetBool("isMoving", false);
            //Debug.Log("idling");
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        //go left
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
            //prevDirectionFacing = false;
        }

        //go right
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
            //prevDirectionFacing = true;
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
            //Debug.Log(doublejumps);
        }

    }

    bool isGrounded()
    {
        RaycastHit2D raycasthit2d = Physics2D.BoxCast(rigidbody2d.position, boxcollider2d.bounds.size, 0f, Vector2.down, 1.7f, Ground_layermask);
        return raycasthit2d.collider != null;
    }

}

