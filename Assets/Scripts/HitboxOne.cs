using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class HitboxOne : MonoBehaviour
{



    //public AttackDirection attackDirection;

    Collider2D biteCollider;
    //Vector2 RightAttackOffset;
    bool lastwasright = true;

    private void Start()
    {
        biteCollider = GetComponent<Collider2D>();
        biteCollider.enabled = false;
        //RightAttackOffset = transform.position;
    }



    public void AttackRight()
    {
        Debug.Log("Right");
        biteCollider.enabled = true;

        if (!lastwasright)
        {
            transform.position = new Vector3(transform.position.x + 5.5f, transform.position.y);
        }


        lastwasright = true;
    }

    public void AttackLeft()
    {
        Debug.Log("Left");
        biteCollider.enabled = true;

        if (lastwasright)
        {
            transform.position = new Vector3(transform.position.x - 5.5f, transform.position.y);
        }

        lastwasright = false;
    }

    public void StopAttack()
    {
        biteCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided");
        if (other.tag == "Bug")
        {
            Debug.Log("if was true");
            PlayerMovement bug = other.GetComponent<PlayerMovement>();
            bug.percent += 77;
            //Debug.Log("root = " + Mathf.Sqrt(bug.percent));
            if (lastwasright)
            {
                bug.rigidbody2d.velocity = new Vector2(0.05f * bug.percent, 0.07f * bug.percent / 2f);
            } else
            {
                bug.rigidbody2d.velocity = new Vector2(-0.5f * bug.percent, 0.07f * bug.percent / 2f);
            }
        }
    }

}