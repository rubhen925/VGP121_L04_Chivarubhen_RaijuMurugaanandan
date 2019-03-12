using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
   
    
    public int maxJumps = 2;

   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Move();



        anim.SetBool("Idle", Mathf.Abs(horizontal) < 0.1f);
        anim.SetBool("Jump", !isGrounded);

        if (Input.GetButtonDown("Jump") && jump < maxJumps)
        {
            Jump();
        }

        if (Input.GetButtonDown("bomb"))
        {
            ShootProjectile();
        }
    }

    public override void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        base.Move();
    }

}

