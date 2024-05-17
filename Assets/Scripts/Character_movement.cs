using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_movement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Animator animator;
    
    public float timeSpentIdle = 0.0f;
    public float maxTimeIdle = 5.0f;
    
    public bool facingRight = true;
    private bool facingLeft = false;
    private bool facingUpRight = false;
    private bool facingUpLeft = false;
    private bool facingDownRight = false;
    private bool facingDownLeft = false;


    public bool FacingLeft
    {
        get => facingLeft;
        set => facingLeft = value;
    }

    public bool FacingUpRight
    {
        get => facingUpRight;
        set => facingUpRight = value;
    }

    public bool FacingUpLeft
    {
        get => facingUpLeft;
        set => facingUpLeft = value;
    }

    public bool FacingDownRight
    {
        get => facingDownRight;
        set => facingDownRight = value;
    }

    public bool FacingDownLeft
    {
        get => facingDownLeft;
        set => facingDownLeft = value;
    }


    // Start is called before the first frame update
    void Start()
    {   
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        //Vector2 movement = new Vector2(horizontal, vertical);
        Transform transform = GetComponent<Transform>();
/*
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle) * Mathf.Rad2Deg);
        }

        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }*/

        if (facingRight)
        {
            if (vertical > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                facingRight = false;
                facingUpRight = true;
            }
            else if (vertical < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                facingRight = false;
                facingDownRight = true;
            }
            else if (horizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                facingRight = false;
                facingLeft = true;
            }
        }

        if (facingLeft)
        {
            if (vertical > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 90);
                facingLeft = false;
                facingUpLeft = true;
            }
            else if (vertical < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, -90);
                facingLeft = false;
                facingDownLeft = true;
            }
            else if (horizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                facingLeft = false;
                facingRight = true;
            }
        }
        

        if (facingUpRight)
        {
            if (horizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                facingUpRight = false;
                facingRight = true;
            }
            else if (horizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                facingUpRight = false;
                facingLeft = true;
            }
            else if (vertical < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, -90);
                facingUpRight = false;
                facingDownLeft = true;
            }
        }
        
        if (facingUpLeft)
        {
            if (horizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                facingUpLeft = false;
                facingRight = true;
            }
            else if (horizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                facingUpLeft = false;
                facingLeft = true;
            }
            else if (vertical < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                facingUpLeft = false;
                facingDownRight = true;
            }
        }
        
        if (facingDownRight)
        {
            if (horizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                facingDownRight = false;
                facingRight = true;
            }
            else if (horizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                facingDownRight = false;
                facingLeft = true;
            }
            else if (vertical > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 90);
                facingDownRight = false;
                facingUpLeft = true;
            }
        }
        
        if (facingDownLeft)
        {
            if (horizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                facingDownLeft = false;
                facingRight = true;
            }
            else if (horizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                facingDownLeft = false;
                facingLeft = true;
            }
            else if (vertical > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                facingDownLeft = false;
                facingUpRight = true;
            }
        }

        if (facingLeft || facingRight)
        {
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }
        else if (facingUpRight || facingUpLeft || facingDownRight || facingDownLeft)
        {
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.y));
        }
        
        if(Mathf.Abs(horizontal) > 0.01 || Mathf.Abs(vertical) > 0.01)
        {
            timeSpentIdle = 0.0f;
        }
        else
        {
            timeSpentIdle += Time.deltaTime;
        }
        
        if (timeSpentIdle > maxTimeIdle)
        {
            animator.SetTrigger("Bored");
            timeSpentIdle = 0.0f;
        }
        
        

    } 
    /*
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }*/
}
