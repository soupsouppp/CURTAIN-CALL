using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

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

    public GameObject clonePrefab;

    public Transform mylLeg;
    public Transform myrLeg;

    public GameObject playerControl;
    public Vector3 moveDir;

    public bool facingL;
    public bool facingR;

    //private Renderer rend;
    //[SerializeField]
    //private Color turnTo = Color.white;


    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<Renderer>();
        //rend.material.color = turnTo;
    }

    private void move()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.D)) moveX = +1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;

        moveDir = new Vector3(moveX, 0, moveZ).normalized;
        rb.velocity = moveDir * speed;


    }


    // Update is called once per frame
    void Update()
    {
        bool leftPresed = Input.GetKey(KeyCode.LeftArrow);
        bool rightPresed = Input.GetKey(KeyCode.RightArrow);
        bool upPressed = Input.GetKey(KeyCode.UpArrow);
        bool downPressed = Input.GetKey(KeyCode.DownArrow);

        


        //if (upPressed && downPressed)
        //{

        //}

        //if (leftPresed && rightPresed)
        //{

        //}

        move();
        Flip();

        
        //jump W
        if (Input.GetKeyDown("w"))
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            counter = jumpTime;
            animator.SetTrigger("jump");
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

        //isGrounded == true &&

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }


        
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, Ground);

        //clone
        if (facingR && Input.GetKeyDown(KeyCode.E))
        {
            CloneMe();

            float xPos = playerControl.transform.position.x;
            float yPos = playerControl.transform.position.y;

            xPos -= 2f;

            playerControl.transform.position = new Vector3(xPos, yPos, 0);
        }

        if (facingL && Input.GetKeyDown(KeyCode.E))
        {
            CloneMe();

            float xPos = playerControl.transform.position.x;
            float yPos = playerControl.transform.position.y;

            xPos += 2f;

            playerControl.transform.position = new Vector3(xPos, yPos, 0);
        }
    }

    
    private void CloneMe()
    {
        GameObject cloneCopy = Instantiate(this.gameObject, transform.position, Quaternion.identity);

        player playerCode = cloneCopy.GetComponent<player>();

        playerCode.enabled = false;
        playerCode.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    }

    private void Flip()
    {
        bool playerMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;



        bool leftPresed = Input.GetKey(KeyCode.LeftArrow);
        bool rightPresed = Input.GetKey(KeyCode.RightArrow);
        bool upPressed = Input.GetKey(KeyCode.UpArrow);
        bool downPressed = Input.GetKey(KeyCode.DownArrow);

       if (playerMoving)
        {
            animator.SetBool("walkingL", true);

            if (rb.velocity.x > 1f)
            {
                playerControl.transform.localScale = new Vector3(-1, 1, 1);
                

                //right


            }

            if (rb.velocity.x < -1f)
            {
                playerControl.transform.localScale = new Vector3(1, 1, 1);
                

            }

        }
        else
        {
            animator.SetBool("walkingL", false);
        }

        /////////////////////////
        ///

        if (playerControl.transform.localScale.x == -1 )
        {
            facingR = true;
            facingL = false;
        }

        if (playerControl.transform.localScale.x == 1)
        {
            facingR = false;
            facingL = true;
        }

        if (facingL && leftPresed && upPressed)
        {
            Debug.Log("kicking upleft");
            animator.SetBool("LeftUp", true);
        }
        else
        {
            animator.SetBool("LeftUp", false);
        }

        if (facingR && rightPresed && upPressed)
        {
            Debug.Log("kicking upright");
            animator.SetBool("LeftUp", true);
        }
        //else
        //{
        //    animator.SetBool("LeftUp", false);
        //}
    }

}

