using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    private Rigidbody2D rb;
    private Animator animator;
    private Transform currentTarget;
    public float speed = 1f;
    public bool facingRight = false;
    //private bool facingLeft = true;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (facingRight)
        {
            currentTarget = point2.transform;
            rb.velocity = new Vector2(speed, 0.0f);
        }
        else
        {
            currentTarget = point1.transform;
            rb.velocity = new Vector2(-speed, 0.0f);
        }
        animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == point1.transform )
        {
            rb.velocity = new Vector2(-speed, 0.0f);
        }
        else if (currentTarget == point2.transform )
        {
            rb.velocity = new Vector2(speed, 0.0f);
        }
       
        if (Vector2.Distance(currentTarget.position, transform.position) < 1f && currentTarget == point1.transform)
        {
            Flip();
            currentTarget = point2.transform;
        }
        else if (Vector2.Distance(currentTarget.position, transform.position) < 1f && currentTarget == point2.transform)
        {
            Flip();
            currentTarget = point1.transform;
        }
        
        /*
        if (facingLeft && Vector2.Distance(currentTarget.position, transform.position) < 0.5f)
        {
            Flip();
            currentTarget = point2.transform;
            rb.velocity = new Vector2(speed, 0.0f);
        }
        else if (facingLeft && currentTarget.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-speed, 0.0f);
        }
        if (facingRight && Vector2.Distance(currentTarget.position, transform.position) < 0.5f)
        {
            Flip();
            currentTarget = point1.transform;
            rb.velocity = new Vector2(-speed, 0.0f);
        }
        else if (facingRight && currentTarget.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, 0.0f);
        }
        */
    }
    
    void Flip()
    {
        //facingLeft = !facingLeft;
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
