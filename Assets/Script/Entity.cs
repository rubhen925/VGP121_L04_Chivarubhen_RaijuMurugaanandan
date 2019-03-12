using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    public float speed;
    public float horizontal = 1;

    public float jumpForce = 100;
    protected bool isGrounded;
    protected int jump = 0;

    public Animator anim;
    public Rigidbody2D rb;

    public GameObject bomb;
    public float bombForce = 10;
    public Transform spawnPoint;


    public bool dead = false;

    float horizontalSpeed;
    float verticalSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public float GetHorizontalSpeed()
    {
        return horizontalSpeed;
    }

    public float GetVerticalSpeed()
    {
        return verticalSpeed;
    }

    public virtual void Move()
    {
        horizontalSpeed = speed * Time.deltaTime * horizontal;
        transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime * horizontal;

        if (horizontal > 0.1f)
        { transform.rotation = Quaternion.Euler(0, 0, 0); }

        else if (horizontal < -0.1f)
        { transform.rotation = Quaternion.Euler(0, 180, 0); }

        verticalSpeed = Time.deltaTime * rb.velocity.y;
    }

    public virtual void Jump()
    {
        isGrounded = false;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
        jump++;
    }

    public virtual void Dead()
    {
        dead = true;
    }
    public virtual void ShootProjectile()
    {
        GameObject spawnedProjectile = Instantiate(bomb, spawnPoint.position, Quaternion.identity);
        spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(bombForce * transform.right, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump = 0;
        isGrounded = true;
    }

}
