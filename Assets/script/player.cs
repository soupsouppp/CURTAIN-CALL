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
        bool leftPresed = Input.GetKey(KeyCode.LeftArrow);
        bool rightPresed = Input.GetKey(KeyCode.RightArrow);
        bool upPressed = Input.GetKey(KeyCode.UpArrow);
        bool downPressed = Input.GetKey(KeyCode.DownArrow);

        if (leftPresed && upPressed)
        {
            Debug.Log("kicking upleft");
            animator.SetBool("LeftUp", true);
        }
        else
        {
            animator.SetBool("LeftUp", false);
        }


        if (rightPresed && upPressed)
        {
            animator.SetBool("RightUp", true);
        }
        else
        {
            animator.SetBool("RightUp", false);
        }


        if (upPressed && downPressed)
        {

        }

        if (leftPresed && rightPresed)
        {

        }    
        
        
        
        
        
        Vector3 pos = transform.position;


        //movement A D
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


        //jump W
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

    private void MakeClone()
    {

    }
    
    
    
}
