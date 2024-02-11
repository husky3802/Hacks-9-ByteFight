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

    private void Start ()
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

}
