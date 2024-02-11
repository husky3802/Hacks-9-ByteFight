using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchAttack : MonoBehaviour
{
    BoxCollider2D scratchCollider;
    Vector2 rightAttackOffset;
    bool lastwasright = true;

    // Start is called before the first frame update
    void Start()
    {
        rightAttackOffset = transform.position;
        scratchCollider = GetComponent<BoxCollider2D>();
        scratchCollider.enabled = false;
    }

    // Update is called once per frame
    public void AttackRight()
    {
        print("ATTACK RIGHT");
        scratchCollider.enabled = true;
        if (!lastwasright)
        {
            transform.position = new Vector3(transform.position.x + 3.5f, transform.position.y);
        }
        lastwasright = true;
    }
    public void AttackLeft()
    {
        print("ATTACK LEFT");
        scratchCollider.enabled = true;

        if (lastwasright)
        {
            transform.position = new Vector3(transform.position.x - 3.5f, transform.position.y);
        }
        lastwasright = false;
    }
    public void StopAttack()
    {
        scratchCollider.enabled = false;
    }
}
