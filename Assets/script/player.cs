using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public float speed = 5f;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;

    public float jumpTime;
    private float counter;
    private bool isJumping;

    public LayerMask Ground;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;



        if (Input.GetKeyUp("a"))
        {
            animator.SetBool("walkingL", false);
        }
        else if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            animator.SetBool("walkingL", true);
        }


        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            animator.SetBool("walkingR", true);
        }

        if (Input.GetKeyUp("d"))
        {
            animator.SetBool("walkingR", false);
        }


        //jump
        if (isGrounded == true && Input.GetKeyDown("w"))
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            counter = jumpTime;
        }

        if (Input.GetKey("w") && isJumping == true)
        {
            if (counter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                counter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }


        transform.position = pos;



        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, Ground);
    }

    void FixedUpdate()
    {
        

    }
}
